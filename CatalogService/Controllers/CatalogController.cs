using CatalogService.CatalogDBContext;
using CatalogService.Modesl;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CatalogService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CatalogController : ControllerBase
    {
        private readonly CatalogDbContext dbContext;

        public CatalogController(CatalogDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Product>> GetProducts()
        {
            return dbContext.Products;
        }

        [HttpGet("{productId:int}")]
        public async Task<ActionResult<Product>> GetProduct(int productId)
        {
            var product = await dbContext.Products.FindAsync(productId);
            return product;
        }

        [HttpPost]
        public async Task<ActionResult> AddProduct(Product product)
        {
            await dbContext.Products.AddAsync(product);
            await dbContext.SaveChangesAsync();
            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult> UpdateProduct(Product product)
        {
            dbContext.Products.Update(product);
            await dbContext.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{productId:int}")]
        public async Task<ActionResult> DeleteProduct(int productId)
        {
            var product = await dbContext.Products.FindAsync(productId);
            dbContext.Products.Remove(product);
            await dbContext.SaveChangesAsync();
            return Ok();
        }
    }
}
