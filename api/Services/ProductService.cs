using Api.Context;
using Api.DTOs;
using Api.Entities;
using Api.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Api.Services;

public class ProductService : IProductService
{
    private readonly DatabaseContext _context;
    public ProductService(DatabaseContext context) =>
        _context = context;

    public async Task<IEnumerable<ProductDto>> GetAllProducts()
    {
        IEnumerable<ProductDto> products = await _context.Products.Select(p => new ProductDto(p.Id, p.Name, p.Price, p.Stock)).AsNoTracking().ToListAsync();
        return products;
    }

    public async Task<ProductDto> GetProduct(int id)
    {
        Product? product = await _context.Products.AsNoTracking().FirstOrDefaultAsync(p => p.Id == id);

        if (product is null)
            throw new KeyNotFoundException();

        return new ProductDto(product.Id, product.Name, product.Price, product.Stock);
    }

    public async Task<ProductDto> CreateProduct(CreateProductRequest request)
    {
        Product product = new Product()
            {
                Name = request.Name,
                Price = request.Price,
                Stock = request.Stock
            };

        _context.Products.Add(product);
        await _context.SaveChangesAsync();

        return new ProductDto(product.Id, product.Name, product.Price, product.Stock);
    }

    public async Task DeleteProduct(int id)
    {
        Product? product = _context.Products.FirstOrDefault(p => p.Id == id);

        if (product is null)
            throw new KeyNotFoundException();

        _context.Products.Remove(product);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateProduct(int id, UpdateProductRequest request)
    {
        Product? product = _context.Products.FirstOrDefault(p => p.Id == id);

        if (product is null)
            throw new KeyNotFoundException();
        
        product.Name = request.Name;
        product.Price = request.Price;
        product.Stock = request.Stock;
        await _context.SaveChangesAsync();
    }
}