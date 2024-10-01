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

        //felhasználó frissítése és módosítása
        [HttpPut]
        [Route("{id}")]
        public async Task<ActionResult<List<User>>>UpdateUser(int id, [FromBody] User updateUser)
        {
            var selectUser = await _dbContext.users.FindAsync(id);
            if (selectUser == null)
            {
                return NotFound("The user was not found!");
            }
            else
            {
                selectUser.FName = updateUser.FName;
                selectUser.LName = updateUser.LName;
                selectUser.Email = updateUser.Email;
                selectUser.Password = updateUser.Password;
            }
            await _dbContext.SaveChangesAsync();
            return Ok(await _dbContext.users.ToListAsync());
        }

        //felhasználó törlése
        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult<List<User>>> DeleteUser(int id) 
        {
            var deleteUser = await _dbContext.users.FindAsync(id);  //megkeresem az első találatot a DB-ben id alapján
            if (deleteUser == null)
            {
                return NotFound("the usei was not found!"); //ha hiba van akkor visszatérek ezzel az üzenettel!
            }
            _dbContext.users.Remove(deleteUser); //fogom és kitörlöm
            await _dbContext.SaveChangesAsync(); //menti a DB-t
            return Ok(await _dbContext.users.ToListAsync()); //visszatérünk az adattal hogy megjelenjen

        }



    }
}
