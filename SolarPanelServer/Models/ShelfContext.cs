using Microsoft.EntityFrameworkCore;
using SolarPanelServer.Models.SolarPanel;

namespace SolarPanelServer.Models
{
    public class ShelfContext : DbContext
    {
        public ShelfContext(DbContextOptions<ShelfContext> options) : base(options) { }

        public DbSet<Shelves> Shelf { get; set; } = null;
    }
}
