using ASPNET_Core.Models;
using Microsoft.EntityFrameworkCore;

namespace ASPNET_Core.Data
{
    public class ApplicationDbContext : DbContext
    {
        // what we doing here is creating a database context class that inherits from EntityFrameworkCore's DbContext class
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
        {
        }

        public virtual DbSet<Kitaplar> Kitaplars { get; set; } // this is a property that represents a table in the database
        public virtual DbSet<Turler> Turlers { get; set; } // this is a property that represents a table in the database
    }
}
