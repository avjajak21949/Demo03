using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Demo03.Data;
using Demo03.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace Demo03.Controllers
{
    [Authorize]
    public class ClassesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public ClassesController(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Classes
        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(User);
            var classes = await _context.Classes
                .Include(c => c.Course)
                .Include(c => c.Teacher)
                .ToListAsync();

            if (User.IsInRole("Teacher"))
            {
                classes = classes.Where(c => c.TeacherId == user.Id).ToList();
            }

            return View(classes);
        }

        // GET: Classes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var @class = await _context.Classes
                .Include(c => c.Course)
                .Include(c => c.Teacher)
                .Include(c => c.StudentClasses)
                    .ThenInclude(sc => sc.Student)
                .Include(c => c.Schedules)
                .FirstOrDefaultAsync(m => m.ClassID == id);

            if (@class == null)
            {
                return NotFound();
            }

            return View(@class);
        }

        // GET: Classes/Create
        [Authorize(Roles = "Administrator,Employer")]
        public async Task<IActionResult> Create()
        {
            ViewData["CourseID"] = new SelectList(_context.Courses, "CourseID", "Name");
            var teachers = await _userManager.GetUsersInRoleAsync("Teacher");
            ViewData["TeacherId"] = new SelectList(teachers, "Id", "UserName");
            return View();
        }

        // POST: Classes/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator,Employer")]
        public async Task<IActionResult> Create([Bind("ClassID,CourseID,TeacherId,Name,ScheduleInfo,MaxCapacity")] Class @class)
        {
            if (ModelState.IsValid)
            {
                _context.Add(@class);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CourseID"] = new SelectList(_context.Courses, "CourseID", "Name", @class.CourseID);
            var teachers = await _userManager.GetUsersInRoleAsync("Teacher");
            ViewData["TeacherId"] = new SelectList(teachers, "Id", "UserName", @class.TeacherId);
            return View(@class);
        }

        // GET: Classes/Edit/5
        [Authorize(Roles = "Administrator,Employer,Teacher")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var @class = await _context.Classes
                .Include(c => c.Course)
                .Include(c => c.Teacher)
                .FirstOrDefaultAsync(m => m.ClassID == id);
                
            if (@class == null)
            {
                return NotFound();
            }

            var user = await _userManager.GetUserAsync(User);
            if (User.IsInRole("Teacher") && @class.TeacherId != user.Id)
            {
                return Forbid();
            }

            ViewData["CourseID"] = new SelectList(_context.Courses, "CourseID", "Name", @class.CourseID);
            var teachers = await _userManager.GetUsersInRoleAsync("Teacher");
            ViewData["TeacherId"] = new SelectList(teachers, "Id", "UserName", @class.TeacherId);
            return View(@class);
        }

        // POST: Classes/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator,Employer,Teacher")]
        public async Task<IActionResult> Edit(int id, [Bind("ClassID,CourseID,TeacherId,Name,ScheduleInfo,MaxCapacity")] Class @class)
        {
            if (id != @class.ClassID)
            {
                return NotFound();
            }

            var user = await _userManager.GetUserAsync(User);
            if (User.IsInRole("Teacher") && @class.TeacherId != user.Id)
            {
                return Forbid();
            }

            // Add debugging information
            foreach (var modelState in ModelState.Values)
            {
                foreach (var error in modelState.Errors)
                {
                    // Log the error message
                    System.Diagnostics.Debug.WriteLine($"Model Error: {error.ErrorMessage}");
                }
            }

            // Ensure MaxCapacity is set
            if (@class.MaxCapacity <= 0)
            {
                @class.MaxCapacity = 30; // Default value
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(@class);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClassExists(@class.ClassID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["CourseID"] = new SelectList(_context.Courses, "CourseID", "Name", @class.CourseID);
            var teachers = await _userManager.GetUsersInRoleAsync("Teacher");
            ViewData["TeacherId"] = new SelectList(teachers, "Id", "UserName", @class.TeacherId);
            return View(@class);
        }

        // GET: Classes/Delete/5
        [Authorize(Roles = "Administrator,Employer")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var @class = await _context.Classes
                .Include(c => c.Course)
                .Include(c => c.Teacher)
                .FirstOrDefaultAsync(m => m.ClassID == id);

            if (@class == null)
            {
                return NotFound();
            }

            return View(@class);
        }

        // POST: Classes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator,Employer")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var @class = await _context.Classes.FindAsync(id);
            _context.Classes.Remove(@class);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClassExists(int id)
        {
            return _context.Classes.Any(e => e.ClassID == id);
        }
    }
}
