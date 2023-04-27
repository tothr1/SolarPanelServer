﻿using Microsoft.EntityFrameworkCore;
using SolarPanelServer.Models.SolarPanel;

namespace SolarPanelServer.Models
{
    public class ProjectContext : DbContext
    {
        /*
          public MaterialContext(DbContextOptions<MaterialContext> options) : base(options) { }

        public DbSet<Material> Materials { get; set; } = null;
         */

        public ProjectContext(DbContextOptions<ProjectContext> options) : base(options) { }
        public DbSet<Project> Projects { get; set; } = null;
        public DbSet<Component> Components { get; set; }
        public DbSet<Material> Materials { get; set; }
        public DbSet<Shelves> Shelves { get; set; }

    }
}
