using System.Reflection;
using MassTransit;
using Microsoft.EntityFrameworkCore;
using Services.PlayerRating.BLL;
using Services.PlayerRating.Models.BLL;
using Services.PlayerRating.Models.DAL;
using Services.PlayerRating.Models.Presentation;
using Services.PlayerRating.Models.Presentation.Rabbit;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var serviceCollection = builder.Services;

serviceCollection.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
serviceCollection.AddEndpointsApiExplorer();
serviceCollection.AddSwaggerGen();
var configuration = builder.Configuration;

serviceCollection.AddMassTransit(x =>
{
    x.AddBus(x=>Bus.Factory.CreateUsingRabbitMq(sbc =>
    {
        sbc.Host(new Uri(configuration["rmqAddress"]), h =>
        {
            h.Username(configuration["rmqLogin"]);
            h.Password(configuration["rmqPassword"]);
        });
    
    }));
    x.AddConsumer<ScoreModelConsumer>();
});
serviceCollection.AddScoped<ScoreModelConsumer>();

var connectionString = configuration.GetConnectionString("Db");
serviceCollection.AddDbContext<PgContext>(x=>x.UseNpgsql(connectionString));


serviceCollection.AddScoped<IScoreService, ScoreService>();
serviceCollection.AddScoped(typeof(IRepository<>), typeof(Repository<>));
serviceCollection.AddScoped<IUnitOfWork, UnitOfWork>();
serviceCollection.AddScoped<DbContext, PgContext>();
serviceCollection.AddScoped<IRabbitMQRepository, RabbitMqRepository>();

serviceCollection.AddAutoMapper(x=>x.AddMaps(Assembly.GetExecutingAssembly()));
var app = builder.Build();



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();



app.Run();