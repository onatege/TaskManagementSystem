using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskManagerProject.Context;
using TaskManagerProject.DTOs;
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

		public async Task<ActionResult> GetAllProjects()
		{

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
		[HttpPut("{id}")]
		public async Task<ActionResult> UpdateProject(int id, ProjectUpdateDto projectUpdate)
		{
			var project = await _context.Projects.FindAsync(id);
			if (project == null)
			{
				return NotFound();
			}

			project.ProjectContent = projectUpdate.ProjectContent;
			project.ProjectDescription = projectUpdate.ProjectDescription;
			project.ProjectStatus = projectUpdate.ProjectStatus;

			if(project.ProjectStatus == true)
			{
				project.EndDate = null;
			}
			else
			{
				project.EndDate = DateTime.Now;
				project.ProjectStatus = projectUpdate.ProjectStatus;
			}
			_context.Projects.Update(project);
			await _context.SaveChangesAsync();
			return Ok(projectUpdate);
		}

		[HttpPost("{id}")]

		public async Task<ActionResult> DeleteProjectById(int id)
		{
			var project = await _context.Projects.FindAsync(id);

			if (project != null)
			{
				project.isDeleted = true;
				project.EndDate = DateTime.Now;
				_context.Projects.Update(project);
				await _context.SaveChangesAsync();
				return Ok(project);
			}

			return NotFound();

		}
	}
}
