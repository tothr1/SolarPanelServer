using Microsoft.EntityFrameworkCore;

namespace SolarPanelServer.Models
{
    public class ComponentContext : DbContext
    {
        /*
         public UserContext(DbContextOptions<UserContext> options) : base(options) { }

        public DbSet<User> Users { get; set; } = null!;
         */

        public ComponentContext(DbContextOptions<ComponentContext> options) : base(options) { }

        public DbSet<Component> Components { get; set; } = null;
    }
}
