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
    public class StudentClassesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public StudentClassesController(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: StudentClasses
        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(User);
            var isManager = await _userManager.IsInRoleAsync(user, "Manager");
            
            IQueryable<StudentClass> studentClassesQuery = _context.StudentClasses
                .Include(s => s.Class)
                    .ThenInclude(c => c.Course)
                .Include(s => s.Student);

            if (isManager)
            {
                // Managers can see all student classes
                return View(await studentClassesQuery.ToListAsync());
            }
            else
            {
                // Teachers can only see student classes in their classes
                var teacher = await _context.Teachers.FindAsync(user.Id);
                if (teacher != null)
                {
                    studentClassesQuery = studentClassesQuery.Where(sc => sc.Class.TeacherId == teacher.Id);
                }
                return View(await studentClassesQuery.ToListAsync());
            }
        }

        // GET: StudentClasses/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _userManager.GetUserAsync(User);
            var isManager = await _userManager.IsInRoleAsync(user, "Manager");

            var studentClass = await _context.StudentClasses
                .Include(s => s.Class)
                    .ThenInclude(c => c.Course)
                .Include(s => s.Student)
                .FirstOrDefaultAsync(m => m.StudentClassID == id);

            if (studentClass == null)
            {
                return NotFound();
            }

            if (!isManager)
            {
                var teacher = await _context.Teachers.FindAsync(user.Id);
                if (teacher != null && studentClass.Class.TeacherId != teacher.Id)
                {
                    return Forbid();
                }
            }

            return View(studentClass);
        }

        // GET: StudentClasses/Create
        [Authorize(Roles = "Manager")]
        public IActionResult Create()
        {
            ViewData["ClassID"] = new SelectList(_context.Classes, "ClassID", "Name");
            ViewData["StudentId"] = new SelectList(_context.Students, "Id", "FullName");
            return View();
        }

        // POST: StudentClasses/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Manager")]
        public async Task<IActionResult> Create([Bind("StudentClassID,StudentID,ClassID")] StudentClass studentClass)
        {
            if (ModelState.IsValid)
            {
                _context.Add(studentClass);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClassID"] = new SelectList(_context.Classes, "ClassID", "Name", studentClass.ClassID);
            ViewData["StudentId"] = new SelectList(_context.Students, "Id", "FullName", studentClass.StudentId);
            return View(studentClass);
        }

        // GET: StudentClasses/Edit/5
        [Authorize(Roles = "Manager")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studentClass = await _context.StudentClasses.FindAsync(id);
            if (studentClass == null)
            {
                return NotFound();
            }
            ViewData["ClassID"] = new SelectList(_context.Classes, "ClassID", "Name", studentClass.ClassID);
            ViewData["StudentId"] = new SelectList(_context.Students, "Id", "FullName", studentClass.StudentId);
            return View(studentClass);
        }

        // POST: StudentClasses/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Manager")]
        public async Task<IActionResult> Edit(int id, [Bind("StudentClassID,StudentID,ClassID")] StudentClass studentClass)
        {
            if (id != studentClass.StudentClassID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(studentClass);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StudentClassExists(studentClass.StudentClassID))
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
            ViewData["ClassID"] = new SelectList(_context.Classes, "ClassID", "Name", studentClass.ClassID);
            ViewData["StudentId"] = new SelectList(_context.Students, "Id", "FullName", studentClass.StudentId);
            return View(studentClass);
        }

        // GET: StudentClasses/Delete/5
        [Authorize(Roles = "Manager")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studentClass = await _context.StudentClasses
                .Include(s => s.Class)
                .Include(s => s.Student)
                .FirstOrDefaultAsync(m => m.StudentClassID == id);
            if (studentClass == null)
            {
                return NotFound();
            }

            return View(studentClass);
        }

        // POST: StudentClasses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Manager")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var studentClass = await _context.StudentClasses.FindAsync(id);
            _context.StudentClasses.Remove(studentClass);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StudentClassExists(int id)
        {
            return _context.StudentClasses.Any(e => e.StudentClassID == id);
        }
    }
}
