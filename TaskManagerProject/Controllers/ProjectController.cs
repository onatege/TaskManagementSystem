using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskManagerProject.Context;
using TaskManagerProject.Entities;

namespace TaskManagerProject.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ProjectController : ControllerBase
	{
		private readonly TaskManagementContext _context;
		public ProjectController(TaskManagementContext context)
		{
			_context = context;
		}

		[HttpGet]

		public async Task<ActionResult> GetAllProjects() {

			var projects = await _context.Projects.ToListAsync();
			return Ok(projects);
		}

		[HttpGet("{id}")]
		public async Task<ActionResult> GetProjectsById(int id)
		{
			var projects = await _context.Projects.FindAsync(id);
			return Ok(projects);
		}
		[HttpPost]
		public async Task<ActionResult> AddProject(Project project)
		{
			await _context.Projects.AddAsync(project);
			await _context.SaveChangesAsync();
			return Ok(project);
		}
    }
}
