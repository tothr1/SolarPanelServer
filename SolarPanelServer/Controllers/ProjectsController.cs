using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.VisualBasic.Syntax;
using Microsoft.EntityFrameworkCore;
using SolarPanelServer.Models;
using SolarPanelServer.Models.SolarPanel;
using System.Text.Json;

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

        [HttpPost]
        public async Task<ActionResult<Project>> AddNewProject(Project newProject)
        {
            if (newProject == null)
            {
                return BadRequest("Invalid request body");
            }

            // set default values for status and creation time
            newProject.status = "New";
            newProject.row_updated = DateTime.Now;

            _context.Projects.Add(newProject);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetProject), new { id = newProject.project_id }, newProject);
        }
        [HttpPost("End Project")]
        public async Task<ActionResult<Project>> EndProject(int id, string status)
        {

            var mat = await _context.Projects.FirstOrDefaultAsync(u => u.project_id == id);
            if (mat != null)
            {


                mat.status = status;

                await _context.SaveChangesAsync();

                return CreatedAtAction("GetProject", new { id = mat.project_id }, mat);


            }
            else
            {
                return BadRequest();
            }
        }
            [HttpPost("WorkHour and Fee")]
            public async Task<ActionResult<Project>> Hourfee(int id,DateTime date, int fees)
            {

                var mat = await _context.Projects.FirstOrDefaultAsync(u => u.project_id == id);
                if (mat != null)
                {


                mat.deadline = date;
                mat.fee = fees;
                    mat.row_updated = DateTime.Now;

                    await _context.SaveChangesAsync();

                    return CreatedAtAction("GetProject", new { id = mat.project_id }, mat);


                }
                else
                {
                    return BadRequest();
                }

            }
        [HttpPost("Add Components to Project")]
        public async Task<IActionResult> AddComponentsToProject(int projectId, List<int> componentIds)
        {
            var project = await _context.Projects.FindAsync(projectId);

            if (project == null)
            {
                return NotFound();
            }

            var components = await _context.Components
                .Where(c => componentIds.Contains(c.component_id))
                .ToListAsync();

            if (components.Count != componentIds.Count)
            {
                return BadRequest("One or more components were not found.");
            }

            foreach (var component in components)
            {
                component.project = projectId;
            }

            await _context.SaveChangesAsync();

            return Ok();
        }
        [HttpPost("Calculate Fee for Project")]
        public async Task<ActionResult<Project>> CalculateFeeForProject(int projectId)
        {
            var project = await _context.Projects.FindAsync(projectId);

            if (project == null)
            {
                return NotFound();
            }

            var components = await _context.Components
                .Where(c => c.project == projectId)
                .ToListAsync();

            if (components.Count == 0)
            {
                return BadRequest("No components found for this project.");
            }

            var materials = await _context.Materials
                .Where(m => components.Select(c => c.material).Contains(m.material_id))
                .ToListAsync();

            var sum = materials.Sum(m => m.price);

            // Calculate the total price for all the components in the project
            var componentsTotalPrice = components.Sum(c => _context.Materials.Single(m => m.material_id == c.material).price);

            project.fee = componentsTotalPrice + sum;
            project.row_updated = DateTime.Now;

            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProject", new { id = project.project_id }, project);
        }
    
    [HttpGet("ListMaterials")]
    public async Task<string> ListMaterials(int projectId)
    {
        if (_context.Projects == null)
        {
            return "No material added to this project";
        }
        var project = await _context.Projects.FindAsync(projectId);
            var components = await _context.Components
                .Where(c => c.project == projectId)
                .ToListAsync();
            List<string> shelves = new List<string>();
            foreach (var component in components)
            {
                var she = await _context.Shelves.FirstOrDefaultAsync(s => s.shelf_id == component.shelf);
                if (she != null)
                    shelves.Add($"{she.shelf_row}_{she.shelf_column}_{she.shelf_level}");
                shelves = shelves.Distinct().ToList();
            }


            return JsonSerializer.Serialize(shelves);
        }

}
}
