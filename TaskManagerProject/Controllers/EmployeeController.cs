using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskManagerProject.Context;
using TaskManagerProject.Entities;

namespace TaskManagerProject.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class EmployeeController : ControllerBase
	{
		#region new emp
		//     private static List<Employee> employee = new List<Employee>
		//{
		//	new Employee
		//	{
		//		Id = 1,
		//		EmployeeName = "TEST",
		//		StartDate = DateTime.Today,
		//		JobTitle = "TEST",
		//		EmailAdress = "TEST@mobven.com",
		//		isDeleted = false,
		//		EmployeeStatus = true,
		//		Password = "1"
		//	},
		//	new Employee
		//	{
		//		Id = 2,
		//		EmployeeName = "TEST2",
		//		StartDate = DateTime.Today,
		//		JobTitle = "TEST2",
		//		EmailAdress = "test@mobven.com",
		//		isDeleted=false,
		//		EmployeeStatus = true,
		//		Password = "1"
		//	}
		//};
		#endregion

		private readonly TaskManagementContext _context;
		public EmployeeController(TaskManagementContext context)
		{
			_context = context;
		}

		[HttpGet]
		public async Task<ActionResult> GetAllEmployees()

		// public async Task<ActionResult<List<Employee>>> GetAllEmployees()
		//public async Task<IActionResult> GetAllEmployees() - farkı: IActionResult olan metot genel bir dönüş tipi sağlar, ikinci metot daha belirli bir dönüş tipi sağlar yani ikici metot List tipinde döndürür. İlk metot ise çeşitli dönüş tiplerini desteklemekte.
		{
			#region Add Employee
			//var employee = new List<Employee>
			//{
			//	new Employee
			//	{
			//		Id = 1,
			//		EmployeeName = "TEST",
			//		StartDate = DateTime.Today,
			//		JobTitle = "TEST",
			//		EmailAdress = "TEST@mobven.com",
			//		isDeleted = false,
			//		EmployeeStatus = true,
			//		Password = "1"
			//	},
			//	new Employee
			//	{
			//		Id = 2,
			//		EmployeeName = "TEST2",
			//		StartDate = DateTime.Today,
			//		JobTitle = "TEST2",
			//		EmailAdress = "test@mobven.com",
			//		isDeleted=false,
			//		EmployeeStatus = true,
			//		Password = "1"
			//	}
			//};
			#endregion

			var employees = await _context.Employees.ToListAsync();
			return Ok(employees);
		}
		[HttpGet("{id}")] // url belirtme

		public async Task<ActionResult> GetSingleEmployee(int id)
		{
			var employee = await _context.Employees.FindAsync(id);
			return Ok(employee);
		}
		[HttpPost]
		public async Task<ActionResult> AddEmployee(Employee employee)
		{
			await _context.Employees.AddAsync(employee);
			await _context.SaveChangesAsync();
			return Ok(employee);
		}

		[HttpPost("{id}")]
		public async Task<ActionResult> DeleteEmployee(int id)
		{
			var employee = await _context.Employees.FindAsync(id);
			if (employee != null)
			{
				employee.isDeleted = true;
                _context.Employees.Update(employee);
                await _context.SaveChangesAsync();
                return Ok(employee);
			}
			return NotFound();
		}

		[HttpPut("{id}")]
		public async Task<ActionResult> UpdateEmployee(int id, Employee reworkEmp)
		{
			var employee = await _context.Employees.FindAsync(id);
			if (employee == null)
			{ return NotFound(); }

			employee.EmployeeName = reworkEmp.EmployeeName;
			employee.EmployeeStatus = reworkEmp.EmployeeStatus;
			employee.EmailAdress = reworkEmp.EmailAdress;
			employee.Password = reworkEmp.Password;
			employee.JobTitle = reworkEmp.JobTitle;
			_context.Employees.Update(employee);
			await _context.SaveChangesAsync();
			return Ok(reworkEmp);

		}




	}
}