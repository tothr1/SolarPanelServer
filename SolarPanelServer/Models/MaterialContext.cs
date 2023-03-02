using Microsoft.EntityFrameworkCore;

namespace SolarPanelServer.Models
{
    public class MaterialContext : DbContext
    {
        public MaterialContext(DbContextOptions<MaterialContext> options) : base(options) { }

        public DbSet<Material> Materials { get; set; } = null;
    }
}
