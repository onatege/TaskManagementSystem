using Microsoft.EntityFrameworkCore;
using TaskManagerProject.Entities;

namespace TaskManagerProject.Context
{
	public class TaskManagementContext : DbContext
	{
        public TaskManagementContext(DbContextOptions<TaskManagementContext> options) : base(options)
        {
            
        }

        public DbSet<Duty> Duties { get; set;}
        public DbSet<Comment> Comments { get; set;}
        public DbSet<Project> Projects { get; set;}
        public DbSet<Employee> Employees { get; set;}
    }
}
