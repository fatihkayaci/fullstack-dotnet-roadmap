using Api.Data;
using Api.Interfaces;
using Api.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSingleton<ProductStore>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddControllers();
var app = builder.Build();
app.MapControllers();


app.UseHttpsRedirection();

app.Run();
