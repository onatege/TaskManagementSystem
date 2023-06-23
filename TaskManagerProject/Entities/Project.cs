using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace TaskManagerProject.Entities
{
	public class Project
	{
		public int Id { get; set; }
		//[Required]
        public string ProjectName { get; set; }
		//[Required]
		public string ProjectContent { get; set; }
        public string ProjectDescription { get; set; }
        public bool ProjectStatus { get; set; }
		public DateTime StartDate { get; set; }
		public DateTime? EndDate { get; set; }
		public bool isDeleted { get; set; }
		public  ICollection<Duty>? Duties { get; set; }

	}
}
