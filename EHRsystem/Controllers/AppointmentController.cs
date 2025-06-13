using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EHRsystem.Data;
using EHRsystem.Models.Entities;
using EHRsystem.Models.Entities.Users;
using System.Threading.Tasks;
using System;

namespace EHRsystem.Controllers
{
    [Authorize]
    public class AppointmentController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AppointmentController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult BookAppointment()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> BookAppointment(Appointment model)
        {
            if (ModelState.IsValid)
            {
                model.PatientId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value ?? string.Empty;
                model.CreatedAt = DateTime.Now;
                _context.Appointments.Add(model);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "Home");
            }
            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = "Doctor")]
        public async Task<IActionResult> UpdateStatus(int id, string status)
        {
            var appointment = await _context.Appointments.FindAsync(id);
            if (appointment == null)
            {
                return NotFound();
            }

            if (!Enum.TryParse<AppointmentStatus>(status, true, out var parsedStatus))
            {
                ModelState.AddModelError("Status", "Invalid status value.");
                return BadRequest(ModelState);
            }

            appointment.Status = parsedStatus;
            appointment.UpdatedAt = DateTime.Now;
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}