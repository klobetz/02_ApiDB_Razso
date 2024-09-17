using API_DB.DAL.Model;
using Microsoft.EntityFrameworkCore;

namespace API_DB.DAL.Data
{
    public class MysqlDBContext : DbContext
    {
        public MysqlDBContext(DbContextOptions<MysqlDBContext> options):base(options) { }

        public DbSet<User> users { get; set; }
    }
}
