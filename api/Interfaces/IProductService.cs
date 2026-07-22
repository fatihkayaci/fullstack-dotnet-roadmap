using Api.DTOs;

namespace Api.Interfaces;

public interface IProductService
    {
    Task<IEnumerable<ProductDto>> GetAllProducts();
    Task<ProductDto> GetProduct(int id);
    Task<ProductDto> CreateProduct(CreateProductRequest request);
    Task UpdateProduct(int id, UpdateProductRequest request);
    Task DeleteProduct(int id);
}