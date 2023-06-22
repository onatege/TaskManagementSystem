using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaskManagerProject.Entities
{
	public class Comment
	{
		
		public int Id { get; set; }
        public string CommentTitle { get; set; }
        public string CommentContent { get; set; }
        public bool Status { get; set; }
		public bool isDeleted { get; set; }
		public DateTime CreatedDate { get; set; }
		public DateTime UpdatedDate { get; set; }
		public int DutyId { get; set; }
		public Duty? Duty { get; set; }
    }
}
