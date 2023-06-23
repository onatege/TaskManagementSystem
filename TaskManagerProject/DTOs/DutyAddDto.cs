namespace TaskManagerProject.DTOs
{
    public class DutyAddDto : IDutyAddContract
    {
        public int EmployeeId { get; set; }
        public string TaskName { get; set; }
        public string TaskType { get; set; }
        public string TaskDescription { get; set; }
        public int ProjectId { get; set; }
    }
}
