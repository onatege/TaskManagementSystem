using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace TaskManagerProject.Entities
{
	public class Employee
	{
		public int Id { get; set; }
		public string EmployeeName { get; set; }
		public DateTime StartDate { get; set; }
		//public DateTime? EndDate { get; set; }
		//[Required]
		public string EmailAdress { get; set; }
		public string JobTitle { get; set; }
		//[Required]
		public string Password { get; set; }
		public bool isDeleted { get; set; }
        public bool EmployeeStatus { get; set; }
		[JsonIgnore]
		public  ICollection<Duty>? Duties { get; set; }
		[JsonIgnore]
		public  ICollection<Project>? Projects { get; set; }
		[JsonIgnore]
		public  ICollection<Comment>? Comments { get; set; }
		

	}
}
