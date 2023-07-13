using System.Reflection;
using System.Runtime.CompilerServices;
using Microsoft.EntityFrameworkCore;
using Services.PlayerRating.BLL;
using Services.PlayerRating.Models.BLL;
using Services.PlayerRating.Models.DAL;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var defaultDbType = "Postgres";
var dbType = builder.Configuration.GetSection("DbType")?.Value ?? defaultDbType;
//if (dbType?.ToLower() == defaultDbType)
{
    var connectionString = builder.Configuration.GetConnectionString("Db");
    builder.Services.AddDbContext<PgContext>(x=>x.UseNpgsql(connectionString));
}

builder.Services.AddScoped<IScoreService, ScoreService>();
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<DbContext, PgContext>();

builder.Services.AddAutoMapper(x=>x.AddMaps(Assembly.GetExecutingAssembly()));
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