using Microsoft.EntityFrameworkCore;

namespace EdgeLiotAssessment.Models
{
    public class UserDbContext : DbContext 
    {
        public UserDbContext(DbContextOptions<UserDbContext> options) : base(options) { }
        public DbSet<User>? User { get; set; }
        public DbSet<Messages>? Messages { get; set; }
    }
}
