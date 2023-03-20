using Microsoft.EntityFrameworkCore;

namespace SolarPanelServer.Models
{
    public class ProjectContext
    {
        /*
          public MaterialContext(DbContextOptions<MaterialContext> options) : base(options) { }

        public DbSet<Material> Materials { get; set; } = null;
         */

        public ProjectContext(DbContextOptions<ProjectContext> options) : base(options) { }
        public DbSet<Project> Projects { get; set; } = null;
    }
}
