using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EHRsystem.Data;         // Fixed missing reference
using Microsoft.AspNetCore.Authorization;  // Fixed missing reference

namespace EHRsystem.Controllers
{
    [Authorize(Roles = "Patient")]  // Now works with added namespace
    public class PatientController : Controller
    {
        private readonly ApplicationDbContext _context;

        // Fixed constructor (no return type)
        public PatientController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Patient
        public async Task<IActionResult> Index()
        {
            return View(await _context.Patients.ToListAsync());
        }
        
        // ... other controller methods ...
    }
}