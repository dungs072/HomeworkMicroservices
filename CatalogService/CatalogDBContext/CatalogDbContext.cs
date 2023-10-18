using CatalogService.Modesl;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;

namespace CatalogService.CatalogDBContext
{
    public class CatalogDbContext: DbContext
    {
        public CatalogDbContext(DbContextOptions<CatalogDbContext> dbContextOptions) : base(dbContextOptions)
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
        public DbSet<Product> Products { get; set; }
    }
}
