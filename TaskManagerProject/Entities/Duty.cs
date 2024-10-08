﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace TaskManagerProject.Entities
{
	public class Duty
	{
		public int Id { get; set; }
		public int EmployeeId { get; set; }
		public Employee Employee { get; set; }
		public string CreatedBy { get; set; }
		public int AssignedTo { get; set; }
		//[Required]
		public string TaskName { get; set; }
		//[Required]
		public string TaskType { get; set; }
		public string TaskDescription { get; set; }
		public DateTime CreatedDate { get; set; }
		public DateTime UpdatedDate { get; set; }
		public int ProjectId { get; set; }
		public Project Project { get; set; }
		public bool IsActive { get; set; }
		public bool IsDeleted { get; set; }
		public ICollection<Comment>? Comments { get; set; }
	}
}
