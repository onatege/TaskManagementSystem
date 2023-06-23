using TaskManagerProject.Contracts;

namespace TaskManagerProject.DTOs
{
    public class DutyUpdateDto : IDutyUpdateContract
    {
        public string TaskName { get; set; }
        public string TaskType { get; set; }

        public string TaskDescription { get; set; }
        public int AssignedTo { get; set; }
        public bool IsActive { get; set; }
    }
}
