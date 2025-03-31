using api.Data;
using api.Interfaces;
using api.Repository;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddOpenApi();

builder.Services.AddDbContext<ApplicationDBContext>(options => {
    options.UseSqlServer("Password=Passw0rd;Persist Security Info=True;User ID=sa;Initial Catalog=master;Data Source=localhost;TrustServerCertificate=True");
});

builder.Services.AddScoped<IStockRepo, StockRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwaggerUi(options => {
        options.DocumentPath = "/openapi/v1.json";
    });
    }

//app.UseHttpsRedirection();

//app.UseAuthorization();

app.MapControllers();

app.Run();
