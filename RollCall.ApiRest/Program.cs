using CodigosPostales.Repositories;
using RollCall.BusinessLayer.Extensor;
using RollCall.Core.Mappers;
using RollCall.Repositories.Extensor;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRollCall();
builder.Services.AddMappers();
builder.Services.AddRepository();
builder.Services.AddCodigosPostalesRepository();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(options => options.AddPolicy("AllowWebApp", builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod()));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowWebApp");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();