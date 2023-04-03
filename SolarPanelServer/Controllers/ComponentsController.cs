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
          if (_context.Components == null)
          {
              return NotFound();
          }
            return await _context.Components.ToListAsync();
        }

        // GET: api/Components/5
        //[HttpGet("material")]
        //public async Task<ActionResult<Component>> GetComponent(int project, string material, int db)
        //{
        //    ///*var cmop = await _context.Components.FirstOrDefaultAsync(u => u.project == project*/);
        //    if (_context.Components != null)
        //  {
        //      return NotFound();
        //  }
        //    var component = await _context.Components.FindAsync(id);

        //    if (component == null)
        //    {
        //        return NotFound();
        //    }

        //    return component;
        //}

        //[HttpPut("GetComponent")]
        //public ActionResult<List<Component>> GetComponent(int project, string _material, int db)
        //{
        //    //List<Component> customers = new List<Component>();


        //    DataTable dt = Connection.runQuery($"SELECT TOP {db} component_id FROM Components WHERE material = '{_material}' AND project is NULL");

        //    List<Component> components = new List<Component>();

        //    foreach (DataRow dr in dt.Rows)
        //    {
        //        Component component = new Component
        //        {
        //            component_id = Convert.ToInt32(dr["component_id"]),
        //            material = dr["material"].ToString(),
        //            shelf = dr["shelf"].ToString(),
        //            project = Convert.ToInt32(dr["project"]),
        //            row_updated = Convert.ToDateTime(dr["row_updated"])
        //        };

        //        components.Add(component);
        //    }
        //    return Ok();
        //}
        // PUT: api/Components/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPut("List Component")]
        //public async Task<IActionResult> AssignComponent(int id)
        //{
        //    if (id != component.component_id)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(component).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!ComponentExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        // POST: api/Components
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Component>> PostComponent(Component component)
        {
          if (_context.Components == null)
          {
              return Problem("Entity set 'ComponentContext.Components'  is null.");
          }
            _context.Components.Add(component);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetComponent", new { id = component.component_id }, component);
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
    }
}
