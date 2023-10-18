using CatalogService.CatalogDBContext;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderingService.Models;

namespace OrderingService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly OrderingDbContext dbContext;

        public OrderController(OrderingDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Ordering>> GetOrderings()
        {
            return dbContext.Orderings;
        }

        [HttpGet("{orderingId:int}")]
        public async Task<ActionResult<Ordering>> GetOrdering(int orderingId)
        {
            var ordering = await dbContext.Orderings.FindAsync(orderingId);
            return ordering;
        }

        [HttpPost]
        public async Task<ActionResult> AddOrdering(Ordering ordering)
        {
            await dbContext.Orderings.AddAsync(ordering);
            await dbContext.SaveChangesAsync();
            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult> UpdateProduct(Ordering ordering)
        {
            dbContext.Orderings.Update(ordering);
            await dbContext.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{orderingId:int}")]
        public async Task<ActionResult> DeleteProduct(int orderingId)
        {
            var product = await dbContext.Orderings.FindAsync(orderingId);
            dbContext.Orderings.Remove(product);
            await dbContext.SaveChangesAsync();
            return Ok();
        }
    }
}
