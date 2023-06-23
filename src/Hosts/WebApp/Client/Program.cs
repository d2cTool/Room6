using System.Net.Http.Headers;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.JSInterop;
using WebApp.Client;
using WebApp.Client.Services;
using WebApp.Shared.Defaults;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
var services = builder.Services;

services.AddOptions();
services.AddAuthorizationCore();
services.TryAddSingleton<AuthenticationStateProvider, HostAuthenticationStateProvider>();
services.TryAddSingleton(sp => (HostAuthenticationStateProvider)sp.GetRequiredService<AuthenticationStateProvider>());
services.AddTransient<AuthorizedHandler>();

services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

var jsInterop = builder.Build().Services.GetRequiredService<IJSRuntime>();

services.AddHttpClient("default", client =>
{
    client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress);
    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
});

services.AddHttpClient(AuthDefaults.AuthorizedClientName, client =>
{
    client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress);
    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
}).AddHttpMessageHandler<AuthorizedHandler>();

services.AddTransient(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient("default"));

await builder.Build().RunAsync();
