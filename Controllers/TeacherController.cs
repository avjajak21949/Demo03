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
    public class TeacherController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ApplicationDbContext _context;

        public TeacherController(UserManager<IdentityUser> userManager, ApplicationDbContext context)
        {
            _userManager = userManager;
            _context = context;
        }

        // GET: Teacher
        [Authorize(Policy = "TeacherOrManagerPolicy")]
        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(User);
            var isManager = await _userManager.IsInRoleAsync(user, "Manager");
            
            IQueryable<Teacher> teachersQuery = _context.Teachers
                .Include(t => t.Classes)
                .Include(t => t.Meetings)
                .Include(t => t.Documents);
            
            if (isManager)
            {
                teachersQuery = teachersQuery.Where(t => t.CreatedByEmployerId == user.Id);
            }
            else if (await _userManager.IsInRoleAsync(user, "Teacher"))
            {
                teachersQuery = teachersQuery.Where(t => t.Id == user.Id);
            }
            
            var teachers = await teachersQuery.ToListAsync();
            return View(teachers);
        }

        // GET: Teacher/Details/5
        [Authorize(Policy = "TeacherOrManagerPolicy")]
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _userManager.GetUserAsync(User);
            var isManager = await _userManager.IsInRoleAsync(user, "Manager");
            
            var teacher = await _context.Teachers
                .Include(t => t.Classes)
                .Include(t => t.Meetings)
                .Include(t => t.Documents)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (teacher == null)
            {
                return NotFound();
            }

            if (isManager && teacher.CreatedByEmployerId != user.Id)
            {
                return Forbid();
            }

            return View(teacher);
        }

        // GET: Teacher/Create
        [Authorize(Policy = "ManagerPolicy")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Teacher/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Policy = "ManagerPolicy")]
        public async Task<IActionResult> Create([Bind("FullName,Department,Specialization,Password,Email")] Teacher teacher)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.GetUserAsync(User);
                teacher.CreatedByEmployerId = user.Id;
                teacher.UserName = teacher.Email;
                teacher.EmailConfirmed = true;
                
                var result = await _userManager.CreateAsync(teacher, teacher.Password);
                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(teacher, "Teacher");
                    return RedirectToAction(nameof(Index));
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }
            return View(teacher);
        }

        // GET: Teacher/Edit/5
        [Authorize(Policy = "ManagerPolicy")]
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _userManager.GetUserAsync(User);
            var teacher = await _context.Teachers.FindAsync(id);
            
            if (teacher == null)
            {
                return NotFound();
            }

            if (teacher.CreatedByEmployerId != user.Id)
            {
                return Forbid();
            }

            return View(teacher);
        }

        // POST: Teacher/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Policy = "ManagerPolicy")]
        public async Task<IActionResult> Edit(string id, [Bind("Id,FullName,Department,Specialization,Email")] Teacher teacher)
        {
            if (id != teacher.Id)
            {
                return NotFound();
            }

            var user = await _userManager.GetUserAsync(User);
            var existingTeacher = await _context.Teachers.FindAsync(id);
            if (existingTeacher.CreatedByEmployerId != user.Id)
            {
                return Forbid();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    existingTeacher.FullName = teacher.FullName;
                    existingTeacher.Department = teacher.Department;
                    existingTeacher.Specialization = teacher.Specialization;
                    existingTeacher.Email = teacher.Email;
                    existingTeacher.UserName = teacher.Email;

                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TeacherExists(teacher.Id))
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
            return View(teacher);
        }

        // GET: Teacher/Delete/5
        [Authorize(Policy = "ManagerPolicy")]
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _userManager.GetUserAsync(User);
            var teacher = await _context.Teachers
                .FirstOrDefaultAsync(m => m.Id == id);
            
            if (teacher == null)
            {
                return NotFound();
            }

            if (teacher.CreatedByEmployerId != user.Id)
            {
                return Forbid();
            }

            return View(teacher);
        }

        // POST: Teacher/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Policy = "ManagerPolicy")]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var user = await _userManager.GetUserAsync(User);
            var teacher = await _context.Teachers.FindAsync(id);
            
            if (teacher.CreatedByEmployerId != user.Id)
            {
                return Forbid();
            }

            _context.Teachers.Remove(teacher);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TeacherExists(string id)
        {
            return _context.Teachers.Any(e => e.Id == id);
        }
    }
} 