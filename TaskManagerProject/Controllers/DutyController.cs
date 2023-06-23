using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient.DataClassification;
using Microsoft.EntityFrameworkCore;
using TaskManagerProject.Context;
using TaskManagerProject.DTOs;
using TaskManagerProject.Entities;


namespace TaskManagerProject.Controllers
{
        [Route("api/[controller]")]
        [ApiController]
        public class DutyController : ControllerBase
        {
            private readonly TaskManagementContext _context;
            public DutyController(TaskManagementContext context)
            {
                _context = context;
            }
            [HttpGet]
            public async Task<ActionResult> GetAllDuties()
            {
                var duties = await _context.Duties.ToListAsync();
                return Ok(duties);
            }
        [HttpGet("{id}")]
        public async Task<ActionResult> GetSingleDuty(int id)
        {
            var duty = await _context.Duties.FindAsync(id);
            return Ok(duty);
        }
        [HttpPost]
        public async Task<ActionResult> AddDuty(Duty duty)
        {
            await _context.Duties.AddAsync(duty);
            await _context.SaveChangesAsync();
            return Ok(duty);    
        }
        [HttpPost("{id}")]
        public async Task<ActionResult> DeleteDuty(int id)
        {
            var duty = await _context.Duties.FindAsync(id);
            if (duty == null) 
            {
                duty.IsDeleted = true;
                _context.Duties.Update(duty);
                await _context.SaveChangesAsync();
                return Ok(duty);
            }
            return NotFound();
        }
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateDuty(int id, DutyUpdateDto reworkDuty)
        {
            var duty = await _context.Duties.FindAsync(id);
            if (duty == null)
            {
                return NotFound();
            }
            duty.TaskName = reworkDuty.TaskName;
            duty.TaskDescription = reworkDuty.TaskDescription;
            duty.AssignedTo = reworkDuty.AssignedTo;
            duty.IsActive = reworkDuty.IsActive;

            _context.Duties.Update(duty);
            await _context.SaveChangesAsync();

            return Ok(reworkDuty);
        }
    }
}
