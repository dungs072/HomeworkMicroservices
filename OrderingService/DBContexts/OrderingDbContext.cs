using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using OrderingService.Models;

namespace CatalogService.CatalogDBContext
{
    public class OrderingDbContext: DbContext
    {
        public OrderingDbContext(DbContextOptions<OrderingDbContext> dbContextOptions) : base(dbContextOptions)
        {
            try
            {
                var databaseCreator = Database.GetService<IDatabaseCreator>() as RelationalDatabaseCreator;
                if (databaseCreator != null)
                {
                    if (!databaseCreator.CanConnect()) databaseCreator.Create();
                    if (!databaseCreator.HasTables()) databaseCreator.CreateTables();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public DbSet<Ordering> Orderings { get; set; }
    }
}
