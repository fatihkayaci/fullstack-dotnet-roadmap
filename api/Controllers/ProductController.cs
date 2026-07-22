using Api.DTOs;
using Api.Entities;
using Api.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[Route("api/product")]
[ApiController]
public class ProductController : ControllerBase
{
    private readonly IProductService _productService;

    public ProductController(IProductService productService)
    {
        _productService = productService;
    }
    [HttpGet]
    public async Task<ActionResult<IEnumerable<ProductDto>>> AllProducts()
    {
        IEnumerable<ProductDto> products = await _productService.GetAllProducts();
        return Ok(products);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Product>> Product([FromRoute]int id)
    {
        ProductDto product = await _productService.GetProduct(id);
        return Ok(product);
    }
    [HttpPost]
    public async Task<IActionResult> CreateProduct([FromBody]CreateProductRequest request)
    {
        ProductDto newProduct = await _productService.CreateProduct(request);
        return CreatedAtAction(nameof(Product), new { id = newProduct.Id }, newProduct); 
    }
    
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateProduct([FromRoute] int id, [FromBody]UpdateProductRequest product)
    {
        await _productService.UpdateProduct(id, product);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteProduct([FromRoute]int id)
    {
        await _productService.DeleteProduct(id);
        return NoContent();
    }
}
