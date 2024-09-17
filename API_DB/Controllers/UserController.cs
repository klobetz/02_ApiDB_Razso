using API_DB.DAL.Data;
using API_DB.DAL.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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

        [HttpGet]
        public async Task<ActionResult<List<User>>> GetAllUser()
        {
            var users = _dbContext.users.ToList();
            return Ok(users);
        }
    }
}
