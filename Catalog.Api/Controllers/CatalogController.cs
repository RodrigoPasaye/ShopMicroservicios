using Catalog.Api.Entities;
using Catalog.Api.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.Api.Controllers
{
  [ApiController]
  [Route("api/v1/[controller]")]
  public class CatalogController : ControllerBase
  {
    private readonly IProductRepository productRepository;

    public CatalogController(IProductRepository productRepository)
    {
      this.productRepository = productRepository;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
    {
      return Ok(await productRepository.GetProducts());
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Product>> GetProduct(string id)
    {
      var product = await productRepository.GetProduct(id);

      if (product is null)
        return NotFound();

      return Ok(product);
    }

    [HttpPost]
    public async Task<ActionResult> CreateProduct([FromBody] Product product)
    {
      await productRepository.CreateProduct(product);
      return Ok();
    }    

    [HttpPut]
    public async Task<ActionResult> UpdateProduct([FromBody] Product product)
    {
      return Ok(await productRepository.UpdateProduct(product));
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteProduct(string id)
    {
      return Ok(await productRepository.DeleteProduct(id));
    }
  }
}
