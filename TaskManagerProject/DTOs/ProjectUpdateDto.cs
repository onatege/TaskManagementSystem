using TaskManagerProject.Contracts;

namespace TaskManagerProject.DTOs
{
	public class ProjectUpdateDto : IProjectUpdateContract
	{
		public string ProjectContent { get; set; }
		public string ProjectDescription { get; set; }
		public bool ProjectStatus { get; set; }

	}
}
