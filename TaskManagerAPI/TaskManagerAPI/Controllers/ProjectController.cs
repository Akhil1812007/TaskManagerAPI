using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskManager.API.Core.Model;
using TaskManagerAPI.Data;

namespace TaskManagerAPI.Controllers
{
   
    public class ProjectController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ProjectController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Projects
        [HttpGet("api/Projects")]
        public async Task<ActionResult<IEnumerable<Project>>> GetProjects()
        {
            return await _context.Projects.ToListAsync();
        }

        // GET: api/Projects/5

        [HttpGet("api/Project/{id}")]
        public async Task<ActionResult<Project>> GetProject(int id)
        {
            var project = await _context.Projects.FindAsync(id);

            if (project == null)
            {
                return NotFound();
            }

            return project;
        }

        // POST: api/Projects

        [HttpPost("api/Project")]
        public async Task<ActionResult<Project>> PostProject([FromBody] Project project)
        {
            _context.Projects.Add(project);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProject", new { id = project.ProjectID }, project);
        }

        // PUT: api/Projects/5
        [HttpPut("api/Project/{id}")]
        public async Task<IActionResult> PutProject([FromRoute]int id,[FromBody] Project project)
        {
            if (id != project.ProjectID)
            {
                return BadRequest();
            }

            _context.Entry(project).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProjectExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            var updatedProject = await _context.Projects.FindAsync(id);

            if (updatedProject == null)
            {
                return NotFound();
            }

            return Ok(updatedProject);
        }

        // DELETE: api/Projects/5
        [HttpDelete("api/Project/{id}")]
        public async Task<IActionResult> DeleteProject(int id)
        {
            var project = await _context.Projects.FindAsync(id);
            if (project == null)
            {
                return NotFound();
            }
            else
            {
                _context.Projects.Remove(project);
                await _context.SaveChangesAsync();
                return Ok(new { ProjectId = id });

            }

            

            return NoContent();
        }
        [HttpGet("api/project/search")]
        public async Task<IActionResult> SearchProject(string searchBy,string searchText )
        {
            List<Project> projects = null;
            if (searchBy == "ProjectID")
                projects = await  _context.Projects.Where(temp => temp.ProjectID.ToString().Contains(searchText)).ToListAsync();
            else if (searchBy == "ProjectName")
                projects = await _context.Projects.Where(temp => temp.ProjectName.Contains(searchText)).ToListAsync();
            if (searchBy == "DateOfStart")
                projects = await  _context.Projects.Where(temp => temp.DateOfStart.ToString().Contains(searchText)).ToListAsync();
            if (searchBy == "TeamSize")
                projects = await _context.Projects.Where(temp => temp.TeamSize.ToString().Contains(searchText)).ToListAsync();


            return Ok(projects);
        }


        private bool ProjectExists(int id)
        {
            return _context.Projects.Any(e => e.ProjectID == id);
        }
    }
}
