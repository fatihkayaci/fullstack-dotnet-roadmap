using Api.Context;
using Api.Interfaces;
using Api.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddDbContext<DatabaseContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"))
);
builder.Services.AddControllers();

var app = builder.Build();
app.MapControllers();


app.UseHttpsRedirection();

app.Run();
