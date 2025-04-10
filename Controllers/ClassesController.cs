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
            var isEmployer = await _userManager.IsInRoleAsync(user, "Employer");
            
            IQueryable<Class> classesQuery = _context.Classes
                .Include(c => c.Course)
                .Include(c => c.Teacher);
            
            if (isEmployer)
            {
                classesQuery = classesQuery.Where(c => c.CreatedByEmployerId == user.Id);
            }
            
            var classes = await classesQuery.ToListAsync();
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
        [Authorize(Roles = "Employer")]
        public IActionResult Create()
        {
            ViewData["CourseID"] = new SelectList(_context.Courses, "Id", "Name");
            ViewData["TeacherId"] = new SelectList(_context.Teachers, "Id", "FullName");
            return View();
        }

        // POST: Classes/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Employer")]
        public async Task<IActionResult> Create([Bind("Name,ScheduleInfo,MaxCapacity,CourseID,TeacherId")] Class @class)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.GetUserAsync(User);
                @class.CreatedByEmployerId = user.Id;
                
                _context.Add(@class);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CourseID"] = new SelectList(_context.Courses, "Id", "Name", @class.CourseID);
            ViewData["TeacherId"] = new SelectList(_context.Teachers, "Id", "FullName", @class.TeacherId);
            return View(@class);
        }

        // GET: Classes/Edit/5
        [Authorize(Roles = "Employer")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _userManager.GetUserAsync(User);
            var @class = await _context.Classes
                .Include(c => c.Course)
                .Include(c => c.Teacher)
                .FirstOrDefaultAsync(m => m.ClassID == id);

            if (@class == null)
            {
                return NotFound();
            }

            if (@class.CreatedByEmployerId != user.Id)
            {
                return Forbid();
            }

            ViewData["CourseID"] = new SelectList(_context.Courses, "Id", "Name", @class.CourseID);
            ViewData["TeacherId"] = new SelectList(_context.Teachers, "Id", "FullName", @class.TeacherId);
            return View(@class);
        }

        // POST: Classes/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Employer")]
        public async Task<IActionResult> Edit(int id, [Bind("ClassID,Name,ScheduleInfo,MaxCapacity,CourseID,TeacherId")] Class @class)
        {
            if (id != @class.ClassID)
            {
                return NotFound();
            }

            var user = await _userManager.GetUserAsync(User);
            var existingClass = await _context.Classes.FindAsync(id);
            if (existingClass.CreatedByEmployerId != user.Id)
            {
                return Forbid();
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
            ViewData["CourseID"] = new SelectList(_context.Courses, "Id", "Name", @class.CourseID);
            ViewData["TeacherId"] = new SelectList(_context.Teachers, "Id", "FullName", @class.TeacherId);
            return View(@class);
        }

        // GET: Classes/Delete/5
        [Authorize(Roles = "Employer")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _userManager.GetUserAsync(User);
            var @class = await _context.Classes
                .Include(c => c.Course)
                .Include(c => c.Teacher)
                .FirstOrDefaultAsync(m => m.ClassID == id);

            if (@class == null)
            {
                return NotFound();
            }

            if (@class.CreatedByEmployerId != user.Id)
            {
                return Forbid();
            }

            return View(@class);
        }

        // POST: Classes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Employer")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var user = await _userManager.GetUserAsync(User);
            var @class = await _context.Classes.FindAsync(id);
            
            if (@class.CreatedByEmployerId != user.Id)
            {
                return Forbid();
            }

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
