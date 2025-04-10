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

namespace Demo03.Controllers
{
    [Authorize]
    public class StudentController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public StudentController(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Student
        [Authorize(Policy = "TeacherOrManagerPolicy")]
        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(User);
            var isManager = await _userManager.IsInRoleAsync(user, "Manager");
            
            IQueryable<Student> studentsQuery = _context.Students
                .Include(s => s.StudentClasses)
                    .ThenInclude(sc => sc.Class)
                        .ThenInclude(c => c.Course);

            if (isManager)
            {
                // Managers can see all students
                return View(await studentsQuery.ToListAsync());
            }
            else
            {
                // Teachers can only see students in their classes
                var teacher = await _context.Teachers.FindAsync(user.Id);
                if (teacher != null)
                {
                    studentsQuery = studentsQuery.Where(s => s.StudentClasses
                        .Any(sc => sc.Class.TeacherId == teacher.Id));
                }
                return View(await studentsQuery.ToListAsync());
            }
        }

        // GET: Student/Details/5
        [Authorize(Policy = "TeacherOrManagerPolicy")]
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _userManager.GetUserAsync(User);
            var isManager = await _userManager.IsInRoleAsync(user, "Manager");

            var student = await _context.Students
                .Include(s => s.StudentClasses)
                    .ThenInclude(sc => sc.Class)
                        .ThenInclude(c => c.Course)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (student == null)
            {
                return NotFound();
            }

            if (!isManager)
            {
                var teacher = await _context.Teachers.FindAsync(user.Id);
                if (teacher != null && !student.StudentClasses
                    .Any(sc => sc.Class.TeacherId == teacher.Id))
                {
                    return Forbid();
                }
            }

            return View(student);
        }

        // GET: Student/Create
        [Authorize(Policy = "ManagerPolicy")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Student/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Policy = "ManagerPolicy")]
        public async Task<IActionResult> Create([Bind("FullName,Email,Password")] Student student)
        {
            if (ModelState.IsValid)
            {
                student.UserName = student.Email;
                student.EmailConfirmed = true;
                
                var result = await _userManager.CreateAsync(student, student.Password);
                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(student, "Student");
                    return RedirectToAction(nameof(Index));
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }
            return View(student);
        }

        // GET: Student/Edit/5
        [Authorize(Policy = "ManagerPolicy")]
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await _context.Students.FindAsync(id);
            if (student == null)
            {
                return NotFound();
            }
            return View(student);
        }

        // POST: Student/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Policy = "ManagerPolicy")]
        public async Task<IActionResult> Edit(string id, [Bind("Id,FullName,Email")] Student student)
        {
            if (id != student.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var existingStudent = await _context.Students.FindAsync(id);
                    existingStudent.FullName = student.FullName;
                    existingStudent.Email = student.Email;
                    existingStudent.UserName = student.Email;

                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StudentExists(student.Id))
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
            return View(student);
        }

        // GET: Student/Delete/5
        [Authorize(Policy = "ManagerPolicy")]
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await _context.Students
                .Include(s => s.StudentClasses)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        // POST: Student/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Policy = "ManagerPolicy")]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var student = await _context.Students.FindAsync(id);
            _context.Students.Remove(student);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StudentExists(string id)
        {
            return _context.Students.Any(e => e.Id == id);
        }
    }
} 