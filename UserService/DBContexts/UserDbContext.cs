
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using UserService.Models;

namespace UserService.DbContexts
{
    public class UserDbContext:DbContext
    {
        public UserDbContext(DbContextOptions<UserDbContext> dbContextOptions):base(dbContextOptions) 
        {
            try
            {
                var databaseCreator = Database.GetService<IDatabaseCreator>() as RelationalDatabaseCreator;
                if(databaseCreator != null)
                {
                    if (!databaseCreator.CanConnect()) databaseCreator.Create();
                    if (!databaseCreator.HasTables()) databaseCreator.CreateTables();
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public DbSet<UserAccount> Users { get; set; }

    }
}
