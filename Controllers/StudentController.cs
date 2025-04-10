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
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ApplicationDbContext _context;

        public StudentController(UserManager<IdentityUser> userManager, ApplicationDbContext context)
        {
            _userManager = userManager;
            _context = context;
        }

        // GET: Student
        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(User);
            var isEmployer = await _userManager.IsInRoleAsync(user, "Employer");
            
            IQueryable<Student> studentsQuery = _context.Students
                .Include(s => s.StudentClasses)
                    .ThenInclude(sc => sc.Class)
                        .ThenInclude(c => c.Course);
            
            if (isEmployer)
            {
                studentsQuery = studentsQuery.Where(s => s.CreatedByEmployerId == user.Id);
            }
            else if (await _userManager.IsInRoleAsync(user, "Student"))
            {
                studentsQuery = studentsQuery.Where(s => s.Id == user.Id);
            }
            
            var students = await studentsQuery.ToListAsync();
            return View(students);
        }

        // GET: Student/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _userManager.GetUserAsync(User);
            var isEmployer = await _userManager.IsInRoleAsync(user, "Employer");
            
            var student = await _context.Students
                .Include(s => s.StudentClasses)
                    .ThenInclude(sc => sc.Class)
                        .ThenInclude(c => c.Course)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (student == null)
            {
                return NotFound();
            }

            if (isEmployer && student.CreatedByEmployerId != user.Id)
            {
                return Forbid();
            }

            return View(student);
        }

        // GET: Student/Create
        [Authorize(Roles = "Employer")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Student/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Employer")]
        public async Task<IActionResult> Create([Bind("FullName,StudentNumber,Department,Password,Email")] Student student)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.GetUserAsync(User);
                student.CreatedByEmployerId = user.Id;
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
        [Authorize(Roles = "Employer")]
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _userManager.GetUserAsync(User);
            var student = await _context.Students.FindAsync(id);
            
            if (student == null)
            {
                return NotFound();
            }

            if (student.CreatedByEmployerId != user.Id)
            {
                return Forbid();
            }

            return View(student);
        }

        // POST: Student/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Employer")]
        public async Task<IActionResult> Edit(string id, [Bind("Id,FullName,StudentNumber,Department,Email")] Student student)
        {
            if (id != student.Id)
            {
                return NotFound();
            }

            var user = await _userManager.GetUserAsync(User);
            var existingStudent = await _context.Students.FindAsync(id);
            if (existingStudent.CreatedByEmployerId != user.Id)
            {
                return Forbid();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    existingStudent.FullName = student.FullName;
                    existingStudent.StudentNumber = student.StudentNumber;
                    existingStudent.Department = student.Department;
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
        [Authorize(Roles = "Employer")]
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _userManager.GetUserAsync(User);
            var student = await _context.Students
                .FirstOrDefaultAsync(m => m.Id == id);
            
            if (student == null)
            {
                return NotFound();
            }

            if (student.CreatedByEmployerId != user.Id)
            {
                return Forbid();
            }

            return View(student);
        }

        // POST: Student/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Employer")]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var user = await _userManager.GetUserAsync(User);
            var student = await _context.Students.FindAsync(id);
            
            if (student.CreatedByEmployerId != user.Id)
            {
                return Forbid();
            }

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