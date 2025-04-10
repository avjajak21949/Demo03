using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Demo03.Models;
using Demo03.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;

namespace Demo03.Controllers
{
    [Authorize]
    public class CoursesController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ApplicationDbContext _context;
        private readonly ILogger<CoursesController> _logger;

        public CoursesController(UserManager<IdentityUser> userManager, ApplicationDbContext context, ILogger<CoursesController> logger)
        {
            _userManager = userManager;
            _context = context;
            _logger = logger;
        }

        // GET: Courses
        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(User);
            var isEmployer = await _userManager.IsInRoleAsync(user, "Employer");
            
            IQueryable<Course> coursesQuery = _context.Courses
                .Include(c => c.Classes)
                .Include(c => c.Teachers);
            
            if (isEmployer)
            {
                coursesQuery = coursesQuery.Where(c => c.CreatedByEmployerId == user.Id);
            }
            
            var courses = await coursesQuery.ToListAsync();
            return View(courses);
        }

        // GET: Courses/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _userManager.GetUserAsync(User);
            var isEmployer = await _userManager.IsInRoleAsync(user, "Employer");
            
            var course = await _context.Courses
                .Include(c => c.Classes)
                .Include(c => c.Teachers)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (course == null)
            {
                return NotFound();
            }

            if (isEmployer && course.CreatedByEmployerId != user.Id)
            {
                return Forbid();
            }

            return View(course);
        }

        // GET: Courses/Create
        [Authorize(Roles = "Employer")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Courses/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Employer")]
        public async Task<IActionResult> Create([Bind("Name,Description,Duration,Price")] Course course)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.GetUserAsync(User);
                course.CreatedByEmployerId = user.Id;
                
                _context.Add(course);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(course);
        }

        // GET: Courses/Edit/5
        [Authorize(Roles = "Employer")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _userManager.GetUserAsync(User);
            var course = await _context.Courses.FindAsync(id);
            
            if (course == null)
            {
                return NotFound();
            }

            if (course.CreatedByEmployerId != user.Id)
            {
                return Forbid();
            }

            return View(course);
        }

        // POST: Courses/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Employer")]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,Duration,Price")] Course course)
        {
            if (id != course.Id)
            {
                return NotFound();
            }

            var user = await _userManager.GetUserAsync(User);
            var existingCourse = await _context.Courses.FindAsync(id);
            if (existingCourse.CreatedByEmployerId != user.Id)
            {
                return Forbid();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    existingCourse.Name = course.Name;
                    existingCourse.Description = course.Description;
                    existingCourse.Duration = course.Duration;
                    existingCourse.Price = course.Price;

                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CourseExists(course.Id))
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
            return View(course);
        }

        // GET: Courses/Delete/5
        [Authorize(Roles = "Employer")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _userManager.GetUserAsync(User);
            var course = await _context.Courses
                .FirstOrDefaultAsync(m => m.Id == id);
            
            if (course == null)
            {
                return NotFound();
            }

            if (course.CreatedByEmployerId != user.Id)
            {
                return Forbid();
            }

            return View(course);
        }

        // POST: Courses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Employer")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var user = await _userManager.GetUserAsync(User);
            var course = await _context.Courses.FindAsync(id);
            
            if (course.CreatedByEmployerId != user.Id)
            {
                return Forbid();
            }

            _context.Courses.Remove(course);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CourseExists(int id)
        {
            return _context.Courses.Any(e => e.Id == id);
        }
    }
}
