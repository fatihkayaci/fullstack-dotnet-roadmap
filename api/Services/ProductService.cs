using Api.Data;
using Api.DTOs;
using Api.Entities;
using Api.Interfaces;

namespace Api.Services;

public class ProductService : IProductService
{
    private readonly ProductStore _store;
    public ProductService(ProductStore store) =>
        _store = store;

    public IEnumerable<ProductDto> GetAllProducts()
    {
        IEnumerable<ProductDto> products = _store.Products.Select(p => new ProductDto(p.Id, p.Name, p.Price, p.Stock)).ToList();
        return products;
    }

    public ProductDto GetProduct(int id)
    {
        Product? product = _store.Products.FirstOrDefault(p => p.Id == id);

        if (product is null)
            throw new KeyNotFoundException();
        return new ProductDto(product.Id, product.Name, product.Price, product.Stock);
    }

    public ProductDto CreateProduct(CreateProductRequest request)
    {
        Product product = new Product()
            {
                Id = 7,
                Name = request.Name,
                Price = request.Price,
                Stock = request.Stock
            };

        _store.Products.Add(product);

        return new ProductDto(product.Id, product.Name, product.Price, product.Stock);
    }

    public void DeleteProduct(int id)
    {
        Product? product = _store.Products.FirstOrDefault(p => p.Id == id);

        if (product is null)
            throw new KeyNotFoundException();

        _store.Products.Remove(product);
    }

    public void UpdateProduct(int id, UpdateProductRequest request)
    {
        Product? product = _store.Products.FirstOrDefault(p => p.Id == id);

        if (product is null)
            throw new KeyNotFoundException();
        
        product.Name = request.Name;
        product.Price = request.Price;
        product.Stock = request.Stock;
        
    }
}