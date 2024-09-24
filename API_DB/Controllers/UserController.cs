using API_DB.DAL.Data;
using API_DB.DAL.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mysqlx;

namespace API_DB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly MysqlDBContext _dbContext;

        public UserController(MysqlDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet] //lekérem a DB-ből az öszes adatot és egy listába beleteszem
        public async Task<ActionResult<List<User>>> GetAllUser()
        {
            var users = _dbContext.users.ToList();
            return Ok(users);
        }
        //egy bizonyos ID alapján kiszűröm a user-t
        [HttpGet]
        [Route("{id}")] //[HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUserName(int id)
        {
            var userSearch = await _dbContext.users.FindAsync(id);
            if (userSearch == null)
            {
                return NotFound("the user is not found");
            }
            return Ok(userSearch);
        }

        //a felhasználó létrehozás
        [HttpPost]
        public async Task<ActionResult<List<User>>> AddUser(User user)
        {
            _dbContext.users.Add(user);
            await _dbContext.SaveChangesAsync(); //mentem a DB-be az adatokat
            return Ok(await _dbContext.users.ToListAsync()); //ezzel a kapott eredményt látni fogom!! egyből
        }




    }
}
