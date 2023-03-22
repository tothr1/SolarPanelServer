using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.VisualBasic.Syntax;
using Microsoft.EntityFrameworkCore;
using SolarPanelServer.Models;

namespace SolarPanelServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectsController : ControllerBase
    {
        private readonly ProjectContext _context;

        public ProjectsController(ProjectContext context)
        {
            _context = context;
        }

        // GET: api/Projects
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Project>>> GetProjects()
        {
          if (_context.Projects == null)
          {
              return NotFound();
          }
            return await _context.Projects.ToListAsync();
        }

        // GET: api/Projects/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Project>> GetProject(int id)
        {
          if (_context.Projects == null)
          {
              return NotFound();
          }
            var project = await _context.Projects.FindAsync(id);

            if (project == null)
            {
                return NotFound();
            }

            return project;
        }

        [HttpPost("New Project")]
        public async Task<ActionResult<Material>> CreateProject(string _address, string _description, DateTime _deadline, int _fee, string _owner)
        {
            //var mat = await _context.Projects.FirstOrDefaultAsync(u => u. == materialname);
            //if (mat == null)
            
                var project = new Project
                {
                    address = _address,
                    description = _description,
                    deadline = _deadline,
                    fee = _fee,
                    status = "New",
                    owner = _owner,
                    row_updated = DateTime.Now
                };

                _context.Projects.Add(project);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetProject", new { id = project.project_id }, project);
           
            
        }
        [HttpPost("End Project")]
        public async Task<ActionResult<Project>> EndProject(int id, string status)
        {

            var mat = await _context.Projects.FirstOrDefaultAsync(u => u.project_id == id);
            if (mat != null)
            {
                
                
                    var project = new Project
                    {
                        status = status,
                        row_updated = DateTime.Now
                    };
                
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetProject", new { id = project.project_id }, mat);
                
               
            }
            else
            {
                return BadRequest();
            }


        }
        // PUT: api/Projects/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutProject(string nev, Project project)
        //{
        //    if (nev != project.)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(project).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!ProjectExists(id))
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

        // POST: api/Projects
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPost]
        //public async Task<ActionResult<Project>> PostProject(Project project)
        //{
        //  if (_context.Projects == null)
        //  {
        //      return Problem("Entity set 'ProjectContext.Projects'  is null.");
        //  }
        //    _context.Projects.Add(project);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetProject", new { id = project.project_id }, project);
        //}

        // DELETE: api/Projects/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteProject(int id)
        //{
        //    if (_context.Projects == null)
        //    {
        //        return NotFound();
        //    }
        //    var project = await _context.Projects.FindAsync(id);
        //    if (project == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Projects.Remove(project);
        //    await _context.SaveChangesAsync();

        //    return NoContent();
        //}

        //private bool ProjectExists(int id)
        //{
        //    return (_context.Projects?.Any(e => e.project_id == id)).GetValueOrDefault();
        //}
    }
}
