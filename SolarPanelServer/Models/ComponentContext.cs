using Microsoft.EntityFrameworkCore;
using SolarPanelServer.Models.SolarPanel;

namespace SolarPanelServer.Models
{
    public class ComponentContext : DbContext
    {
        public ComponentContext(DbContextOptions<ComponentContext> options) : base(options) { }

        public DbSet<Component> Components { get; set; } = null;
        public DbSet<Shelves> Shelves { get; set; }
        public DbSet<Material> Materials { get; set; }
    }
}
