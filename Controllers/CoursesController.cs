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
using Microsoft.Extensions.Logging;

namespace Demo03.Controllers
{
    [Authorize]
    public class CoursesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<CoursesController> _logger;

        public CoursesController(ApplicationDbContext context, ILogger<CoursesController> logger)
        {
            _context = context;
            _logger = logger;
        }

        // GET: Courses
        public async Task<IActionResult> Index()
        {
            var courses = await _context.Courses
                .Include(c => c.Category)
                .ToListAsync();
            return View(courses);
        }

        // GET: Courses/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var course = await _context.Courses
                .Include(c => c.Category)
                .FirstOrDefaultAsync(m => m.CourseID == id);

            if (course == null)
            {
                return NotFound();
            }

            return View(course);
        }

        // GET: Courses/Create
        [Authorize(Roles = "Administrator,Employer")]
        public IActionResult Create()
        {
            ViewData["CategoryID"] = new SelectList(_context.Categories, "CategoryID", "Name");
            return View();
        }

        // POST: Courses/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Employer")]
        public async Task<IActionResult> Create([Bind("Name,Description,CourseCode,CreditHours,Place,Time,Price,CategoryID")] Course course)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _logger.LogInformation($"Creating course: {course.Name} ({course.CourseCode})");
                    _context.Add(course);
                    await _context.SaveChangesAsync();
                    _logger.LogInformation($"Course created successfully with ID: {course.CourseID}");
                    return RedirectToAction(nameof(Index));
                }

                // Log validation errors
                foreach (var modelState in ModelState.Values)
                {
                    foreach (var error in modelState.Errors)
                    {
                        _logger.LogWarning($"Validation error: {error.ErrorMessage}");
                    }
                }

                // If we got this far, something failed, redisplay form
                ViewData["CategoryID"] = new SelectList(_context.Categories, "CategoryID", "Name", course.CategoryID);
                return View(course);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error creating course: {ex.Message}");
                ModelState.AddModelError("", "An error occurred while creating the course. Please try again.");
                ViewData["CategoryID"] = new SelectList(_context.Categories, "CategoryID", "Name", course.CategoryID);
                return View(course);
            }
        }

        // GET: Courses/Edit/5
        [Authorize(Roles = "Administrator,Employer")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var course = await _context.Courses
                .Include(c => c.Category)
                .FirstOrDefaultAsync(m => m.CourseID == id);

            if (course == null)
            {
                return NotFound();
            }

            // Add debugging information
            System.Diagnostics.Debug.WriteLine($"Loading course: ID={course.CourseID}, Name={course.Name}, Code={course.CourseCode}");

            ViewData["CategoryID"] = new SelectList(_context.Categories, "CategoryID", "Name", course.CategoryID);
            return View(course);
        }

        // POST: Courses/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Employer")]
        public async Task<IActionResult> Edit(int id, [Bind("CourseID,Name,Description,CourseCode,CreditHours,Place,Time,Price,CategoryID")] Course course)
        {
            if (id != course.CourseID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _logger.LogInformation($"Updating course: {course.Name} ({course.CourseCode})");
                    _context.Update(course);
                    await _context.SaveChangesAsync();
                    _logger.LogInformation($"Course updated successfully");
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CourseExists(course.CourseID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            }

            // Log validation errors
            foreach (var modelState in ModelState.Values)
            {
                foreach (var error in modelState.Errors)
                {
                    _logger.LogWarning($"Validation error: {error.ErrorMessage}");
                }
            }

            ViewData["CategoryID"] = new SelectList(_context.Categories, "CategoryID", "Name", course.CategoryID);
            return View(course);
        }

        // GET: Courses/Delete/5
        [Authorize(Roles = "Administrator,Employer")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var course = await _context.Courses
                .Include(c => c.Category)
                .FirstOrDefaultAsync(m => m.CourseID == id);

            if (course == null)
            {
                return NotFound();
            }

            return View(course);
        }

        // POST: Courses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator,Employer")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var course = await _context.Courses.FindAsync(id);
            _context.Courses.Remove(course);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CourseExists(int id)
        {
            return _context.Courses.Any(e => e.CourseID == id);
        }
    }
}
