using Microsoft.EntityFrameworkCore;
using CAFERT.Models;

namespace CAFERT.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<MenuItem> MenuItems { get; set; } = null!;
        public DbSet<TeamMember> TeamMembers { get; set; } = null!;
    }
}
