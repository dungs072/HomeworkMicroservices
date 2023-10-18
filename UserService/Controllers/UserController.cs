using UserService.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserService.DbContexts;

namespace UserService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserDbContext dbContext;

        public UserController(UserDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public ActionResult<IEnumerable<UserAccount>> GetUsers()
        {
            return dbContext.Users;
        }

        [HttpGet("{userId:int}")]
        public async Task<ActionResult<UserAccount>> GetUser(int userId)
        {
            var user = await dbContext.Users.FindAsync(userId);
            return user;
        }

        [HttpPost]
        public async Task<ActionResult> AddUser(UserAccount user)
        {
            await dbContext.Users.AddAsync(user);
            await dbContext.SaveChangesAsync();
            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult> UpdateUser(UserAccount user)
        {
            dbContext.Users.Update(user);
            await dbContext.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{userId:int}")]
        public async Task<ActionResult> DeleteUser(int userId)
        {
            var user = await dbContext.Users.FindAsync(userId);
            dbContext.Users.Remove(user);
            await dbContext.SaveChangesAsync();
            return Ok();
        }
    }
}
