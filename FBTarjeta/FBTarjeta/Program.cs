using FBTarjeta;
using FBTarjeta.Models.Data;
using static FBTarjeta.Models.Data.TarjetaCredito;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;



var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options => options.AddPolicy("AllowWebApp",
                                builder => builder.AllowAnyOrigin().
                                                   AllowAnyHeader().
                                                   AllowAnyMethod()));






// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AplicationDbContext>(
    options =>
    {
#pragma warning disable CS8604 // Posible argumento de referencia nulo
        options.UseSqlServer(builder.Configuration.GetConnectionString("DevConnetion"));
#pragma warning restore CS8604 // Posible argumento de referencia nulo
    });

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
