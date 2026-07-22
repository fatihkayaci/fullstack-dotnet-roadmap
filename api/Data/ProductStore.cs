using Api.Entities;

namespace Api.Data;

public class ProductStore
{
    public List<Product> Products { get; } = new()
    {
        new Product() {Id = 1, Name = "Product-01", Price = 100, Stock = 10},
        new Product() {Id = 2, Name = "Product-02", Price = 200, Stock = 20},
        new Product() {Id = 3, Name = "Product-03", Price = 300, Stock = 30},
        new Product() {Id = 4, Name = "Product-04", Price = 400, Stock = 40},
        new Product() {Id = 5, Name = "Product-05", Price = 500, Stock = 50},
        new Product() {Id = 6, Name = "Product-06", Price = 600, Stock = 60},        
    };

}