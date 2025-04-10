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
            var isManager = await _userManager.IsInRoleAsync(user, "Manager");
            
            IQueryable<Class> classesQuery = _context.Classes
                .Include(c => c.Course)
                .Include(c => c.Teacher)
                .Include(c => c.StudentClasses)
                    .ThenInclude(sc => sc.Student);

            if (isManager)
            {
                // Managers can see all classes
                return View(await classesQuery.ToListAsync());
            }
            else
            {
                // Teachers can only see their classes
                var teacher = await _context.Teachers.FindAsync(user.Id);
                if (teacher != null)
                {
                    classesQuery = classesQuery.Where(c => c.TeacherId == teacher.Id);
                }
                return View(await classesQuery.ToListAsync());
            }
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
