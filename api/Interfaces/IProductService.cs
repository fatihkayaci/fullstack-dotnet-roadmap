using Api.DTOs;

namespace Api.Interfaces;

public interface IProductService
    {
    public IEnumerable<ProductDto> GetAllProducts();
    public ProductDto GetProduct(int id);
    public ProductDto CreateProduct(CreateProductRequest request);
    public void UpdateProduct(int id, UpdateProductRequest request);
    public void DeleteProduct(int id);
}