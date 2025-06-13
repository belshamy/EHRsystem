using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EHRsystem.Data;
using EHRsystem.Models.Entities;
using System.Threading.Tasks;
using System;

namespace EHRsystem.Controllers
{
    [Authorize(Roles = "Doctor")]
    public class PrescriptionController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PrescriptionController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult AddPrescription()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddPrescription(Prescription model)
        {
            if (ModelState.IsValid)
            {
                model.DoctorId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value ?? string.Empty;
                model.CreatedAt = DateTime.Now;
                _context.Prescriptions.Add(model);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "Home");
            }
            return View(model);
        }
    }
}