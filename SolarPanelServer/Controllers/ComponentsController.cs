using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using SolarPanelServer.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using SolarPanelServer.Data;
using SolarPanelServer.Models.SolarPanel;
using System.Security.Cryptography.X509Certificates;
using System.Text.Json;

namespace SolarPanelServer.Controllers
{
    [Route("api/Components")]
    [ApiController]
    public class ComponentsController : ControllerBase
    {
        private readonly ComponentContext _context;

        public ComponentsController(ComponentContext context)
        {
            _context = context;
        }

        // GET: api/Components
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Component>>> GetComponents()
        {
            var components = await _context.Components.ToListAsync();

            if (components == null || components.Count == 0)
            {
                return NotFound();
            }

            return components;
        }


        [HttpPost("AddComponent")]
        public async Task<ActionResult<Component>> PostComponent(int material, int db)
        {
            var mat = await _context.Materials.FirstOrDefaultAsync(u => u.material_id == material);
            
            string result = await FindShelves(material, db);
            await _context.SaveChangesAsync();

            return Ok(result);
        }

        // DELETE: api/Components/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteComponent(int id)
        {
            if (_context.Components == null)
            {
                return NotFound();
            }
            var component = await _context.Components.FindAsync(id);
            if (component == null)
            {
                return NotFound();
            }

            _context.Components.Remove(component);
            await _context.SaveChangesAsync();

            return NoContent();
        }
            private bool ComponentExists(int id)
        {
            return (_context.Components?.Any(e => e.component_id == id)).GetValueOrDefault();
        }

        private async Task<string> FindShelves(int matid, int db)
        {
            var material = await _context.Materials.FirstOrDefaultAsync(m => m.material_id == matid);
            // Find components with the specified material ID
            var components = await _context.Components
                .Where(c => c.material == matid)
                .ToListAsync();

            // Get a list of unique shelf IDs from the components
            var shelfIds = components
                .Select(c => c.shelf)
                .Distinct()
                .ToList();

            List<Shelves> shelves = new List<Shelves>();
            Dictionary<int, int> shelfAssign = new Dictionary<int, int>();
            foreach (var shelf in shelfIds) {
                var she = await _context.Shelves.FirstOrDefaultAsync(s => s.shelf_id == shelf);
                shelves.Add(she);
            }
            foreach (var shelf in shelves) {
                if (material.shelf_limit > shelf.part_count && db > 0)
                {
                    int darab = db;
                    db = incrementShelf(shelf, db, material);
                    shelfAssign.Add(shelf.shelf_id, darab-db);
                }
            }
            while (db != 0) {
                var she = await _context.Shelves.FirstOrDefaultAsync(z => z.part_count==0);
                int darab = db;
                db = incrementShelf(she, db, material);
                shelfAssign.Add(she.shelf_id, darab-db);
            }
            return JsonSerializer.Serialize(shelfAssign);
        }
        int incrementShelf(Shelves s, int db,Material m) {
            var tarhely = m.shelf_limit - s.part_count;
            if (tarhely >= db)
            {
                s.part_count += db;
                for (int i = 0; i < db; i++)
                {
                    Component c = new Component();
                    c.material = m.material_id;
                    c.shelf = s.shelf_id;
                }
                db = 0;
            }
            else
            {
                s.part_count = m.shelf_limit;
                for (int i = 0; i < tarhely; i++)
                {
                    Component c = new Component();
                    c.material = m.material_id;
                    c.shelf = s.shelf_id;
                }
                db -= tarhely;
            }
            return db;
        }

    }
}
