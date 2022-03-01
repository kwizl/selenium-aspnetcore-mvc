using Microsoft.EntityFrameworkCore;
using Selenium.Models;

namespace Selenium.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Currency> Currencies { get; set; }
    }
}
