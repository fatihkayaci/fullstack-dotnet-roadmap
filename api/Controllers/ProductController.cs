using Api.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[Route("api/product")]
[ApiController]
public class ProductController : ControllerBase
{
    List<Product> productsdb = new List<Product>()
    {
        new Product() {Id = 1, Name = "Product-01", Price = 100, Stock = 10},
        new Product() {Id = 2, Name = "Product-02", Price = 200, Stock = 20},
        new Product() {Id = 3, Name = "Product-03", Price = 300, Stock = 30},
        new Product() {Id = 4, Name = "Product-04", Price = 400, Stock = 40},
        new Product() {Id = 5, Name = "Product-05", Price = 500, Stock = 50},
        new Product() {Id = 6, Name = "Product-06", Price = 600, Stock = 60},        
    };

    [HttpGet]
    public ActionResult<List<Product>> AllProducts()
    {
        IEnumerable<Product> products = productsdb.ToList();

        return Ok(products);
    }

    [HttpGet("{id}")]
    public ActionResult<Product> Product([FromRoute]int id)
    {
        Product? product = productsdb.FirstOrDefault(p => p.Id == id);
        
        if (product is null)
            return NotFound("böyle bir ürün yok");
            
        return Ok(product);
    }
    [HttpPost]
    public IActionResult CreateProduct([FromBody]Product product)
    {
        productsdb.Add(product);
        return CreatedAtAction(nameof(Product), new { id = product.Id }, product); 
    }
    
    [HttpPut("{id}")]
    public IActionResult UpdateProduct([FromRoute] int id, [FromBody]Product newProduct)
    {
        Product? product = productsdb.FirstOrDefault(p => p.Id == id);

        if (product is null)
            return NotFound("böyle bir ürün yok");
        
        product.Name = newProduct.Name;
        product.Price = newProduct.Price;
        product.Stock = newProduct.Stock;
        
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteProduct([FromRoute]int id)
    {
        Product? product = productsdb.FirstOrDefault(p => p.Id == id);

        if (product is null)
            return NotFound("böyle bir ürün yok");

        productsdb.Remove(product);
        return NoContent();
    }
}
