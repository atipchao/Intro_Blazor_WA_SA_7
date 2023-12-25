using Intro_Blazor_WA_SA_7.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace Intro_Blazor_WA_SA_7.Server.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) :base(options) 
        {
                        
        }

        public DbSet<Person> People { get; set; }
    }
}
