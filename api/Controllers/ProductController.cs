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
    public ActionResult<IEnumerable<ProductDto>> AllProducts()
    {
        IEnumerable<ProductDto> products = _productService.GetAllProducts();
        return Ok(products);
    }

    [HttpGet("{id}")]
    public ActionResult<Product> Product([FromRoute]int id)
    {
        ProductDto product = _productService.GetProduct(id);
        return Ok(product);
    }
    [HttpPost]
    public IActionResult CreateProduct([FromBody]CreateProductRequest request)
    {
        ProductDto newProduct = _productService.CreateProduct(request);
        return CreatedAtAction(nameof(Product), new { id = newProduct.Id }, newProduct); 
    }
    
    [HttpPut("{id}")]
    public IActionResult UpdateProduct([FromRoute] int id, [FromBody]UpdateProductRequest product)
    {
        _productService.UpdateProduct(id, product);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteProduct([FromRoute]int id)
    {
        _productService.DeleteProduct(id);
        return NoContent();
    }
}
