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

            // Check if the user is a student
            if (User.IsInRole("Student"))
            {
                // Get the classes the student is enrolled in
                var studentClasses = await _context.StudentClasses
                    .Include(sc => sc.Class) // Include the Class entity first
                        .ThenInclude(c => c.Course) // Include the Course entity
                    .Include(sc => sc.Class.StudentClasses) // Include StudentClasses for student count
                    .Where(sc => sc.StudentId == user.Id)
                    .Select(sc => sc.Class) // Select the Class entity
                    .ToListAsync();

                return View(studentClasses);
            }

            // For other roles, show all classes
            var classes = await _context.Classes
                .Include(c => c.Course)
                .Include(c => c.StudentClasses) // Include StudentClasses for student count
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

            var user = await _userManager.GetUserAsync(User);
            var isManager = await _userManager.IsInRoleAsync(user, "Manager");

            var @class = await _context.Classes
                .Include(c => c.Course)
                .Include(c => c.Teacher)
                .Include(c => c.StudentClasses)
                    .ThenInclude(sc => sc.Student)
                .FirstOrDefaultAsync(m => m.ClassID == id);

            if (@class == null)
            {
                return NotFound();
            }

            if (!isManager)
            {
                var teacher = await _context.Teachers.FindAsync(user.Id);
                if (teacher != null && @class.TeacherId != teacher.Id)
                {
                    return Forbid();
                }
            }

            return View(@class);
        }

        // GET: Classes/Create
        [Authorize(Roles = "Manager")]
        public IActionResult Create()
        {
            ViewData["CourseID"] = new SelectList(_context.Courses, "Id", "Name");
            ViewData["TeacherId"] = new SelectList(_context.Teachers, "Id", "FullName");
            return View();
        }

        // POST: Classes/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Manager")]
        public async Task<IActionResult> Create([Bind("Name,CourseID,TeacherId,StartDate,EndDate,ScheduleInfo,MaxCapacity")] Class @class)
        {
            if (ModelState.IsValid)
            {
                // Add debug information
                foreach (var state in ModelState)
                {
                    if (state.Value.Errors.Count > 0)
                    {
                        Console.WriteLine($"Field {state.Key} has errors: {string.Join(", ", state.Value.Errors.Select(e => e.ErrorMessage))}");
                    }
                }
                
                _context.Add(@class);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            
            // Log all model state errors
            foreach (var state in ModelState)
            {
                if (state.Value.Errors.Count > 0)
                {
                    Console.WriteLine($"Field {state.Key} has errors: {string.Join(", ", state.Value.Errors.Select(e => e.ErrorMessage))}");
                }
            }
            
            ViewData["CourseID"] = new SelectList(_context.Courses, "Id", "Name", @class.CourseID);
            ViewData["TeacherId"] = new SelectList(_context.Teachers, "Id", "FullName", @class.TeacherId);
            return View(@class);
        }

        // GET: Classes/Edit/5
        [Authorize(Roles = "Manager")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var @class = await _context.Classes.FindAsync(id);
            if (@class == null)
            {
                return NotFound();
            }
            ViewData["CourseID"] = new SelectList(_context.Courses, "Id", "Name", @class.CourseID);
            ViewData["TeacherId"] = new SelectList(_context.Teachers, "Id", "FullName", @class.TeacherId);
            return View(@class);
        }

        // POST: Classes/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Manager")]
        public async Task<IActionResult> Edit(int id, [Bind("ClassID,Name,CourseID,TeacherId,ScheduleInfo,MaxCapacity")] Class @class)
        {
            if (id != @class.ClassID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    // Get the original class to preserve certain values
                    var originalClass = await _context.Classes.AsNoTracking().FirstOrDefaultAsync(c => c.ClassID == id);
                    if (originalClass != null)
                    {
                        // Preserve the CreatedByEmployerId
                        @class.CreatedByEmployerId = originalClass.CreatedByEmployerId;
                    }

                    _context.Update(@class);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
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
                catch (Exception ex)
                {
                    // Log the exception
                    Console.WriteLine($"Error updating class: {ex.Message}");
                    ModelState.AddModelError("", $"Unable to save changes: {ex.Message}");
                }
            }

            // Log validation errors
            foreach (var state in ModelState)
            {
                if (state.Value.Errors.Count > 0)
                {
                    Console.WriteLine($"Field {state.Key} has errors: {string.Join(", ", state.Value.Errors.Select(e => e.ErrorMessage))}");
                }
            }

            ViewData["CourseID"] = new SelectList(_context.Courses, "Id", "Name", @class.CourseID);
            ViewData["TeacherId"] = new SelectList(_context.Teachers, "Id", "FullName", @class.TeacherId);
            return View(@class);
        }

        // GET: Classes/Delete/5
        [Authorize(Roles = "Manager")]
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
        [Authorize(Roles = "Manager")]
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
