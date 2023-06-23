namespace TaskManagerProject.Contracts
{
    public interface IDutyUpdateContract
    {
        string TaskName { get; set; }
        public string TaskType { get; set; }

        string TaskDescription { get; set; }
        int AssignedTo { get; set; }
        bool IsActive { get; set; }
    }
}
