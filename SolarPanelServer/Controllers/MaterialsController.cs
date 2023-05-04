using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.DiaSymReader;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using SolarPanelServer.Models;

namespace SolarPanelServer.Controllers
{
    [Route("api/Materials")]
    [ApiController]
    public class MaterialsController : ControllerBase
    {
        private readonly MaterialContext _context;

        public MaterialsController(MaterialContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Material>>> GetMaterial()
        {
          if (_context.Materials == null)
          {
              return NotFound();
          }
            return await _context.Materials.ToListAsync();
        }

        public async Task<ActionResult<Material>> CreateMaterial(string materialname, int shelflimit, int price_)
        {
            var mat = await _context.Materials.FirstOrDefaultAsync(u => u.material_name == materialname);
            if(mat == null)
            {
                var material = new Material
                {
                    material_name = materialname,
                    shelf_limit = shelflimit,
                    price = price_,
                    row_updated = DateTime.Now
                };

                _context.Materials.Add(material);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetMaterial", new { materialname = material.material_name }, material);
            }
            else
            {
                return BadRequest();
            }
        }
        [HttpPost ("editprice")]
        public async Task<ActionResult<Material>> Editprice(string materialname,int price_)
        {
            var mat = await _context.Materials.FirstOrDefaultAsync(u => u.material_name == materialname);
            if (mat != null)
            {
                mat.price = price_;

                
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetMaterial", new { materialname = mat.material_name }, mat);
            }
            else
            {
                return BadRequest();
            }
        }
        [HttpPost("editlimit")]
        public async Task<ActionResult<Material>> EditLimit(string materialname, int limit)
        {
            var mat = await _context.Materials.FirstOrDefaultAsync(u => u.material_name == materialname);
            if (mat != null)
            {
                if (limit >= mat.shelf_limit)
                {
                    mat.shelf_limit = limit;

                    await _context.SaveChangesAsync();
                }
                else
                {
                    return BadRequest("HIBA, A megadott érték nem lehet kisebb a jelenlegi értéknél!");
                }

                return CreatedAtAction("GetMaterial", new { materialname = mat.material_name }, mat);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMaterial(string id)
        {
            if (_context.Materials == null)
            {
                return NotFound();
            }
            var material = await _context.Materials.FindAsync(id);
            if (material == null)
            {
                return NotFound();
            }

            _context.Materials.Remove(material);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MaterialExists(string id)
        {
            return (_context.Materials?.Any(e => e.material_name == id)).GetValueOrDefault();
        }
    }
}
