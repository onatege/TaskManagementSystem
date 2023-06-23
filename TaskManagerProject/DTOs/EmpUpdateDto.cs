using TaskManagerProject.Contracts;

namespace TaskManagerProject.DTOs
{
    public class EmpUpdateDto : IEmpUpdateContract
    {
        public string EmployeeName { get; set; }
        public string JobTitle { get; set; }
        public string Password { get; set; }
    }
}
