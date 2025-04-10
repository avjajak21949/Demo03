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
        [Authorize(Roles = "Administrator,Employer,Teacher")]
        public async Task<IActionResult> Index()
        {
            var studentClasses = await _context.StudentClasses
                .Include(sc => sc.Class)
                .Include(sc => sc.Student)
                .ToListAsync();
            return View(studentClasses);
        }

        // GET: StudentClasses/Details/5
        [Authorize(Roles = "Administrator,Employer,Teacher")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studentClass = await _context.StudentClasses
                .Include(sc => sc.Class)
                .Include(sc => sc.Student)
                .FirstOrDefaultAsync(m => m.StudentClassID == id);

            if (studentClass == null)
            {
                return NotFound();
            }

            // Check if user is authorized to view this student-class
            var user = await _userManager.GetUserAsync(User);
            var userRoles = await _userManager.GetRolesAsync(user);
            if (userRoles.Contains("Teacher") && studentClass.Class.TeacherId != user.Id)
            {
                return Forbid();
            }

            return View(studentClass);
        }

        // GET: StudentClasses/Create
        [Authorize(Roles = "Administrator,Employer")]
        public IActionResult Create()
        {
            ViewData["ClassID"] = new SelectList(_context.Classes, "ClassID", "Name");
            ViewData["StudentId"] = new SelectList(_context.Students, "Id", "FullName");
            return View();
        }

        // POST: StudentClasses/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator,Employer")]
        public async Task<IActionResult> Create([Bind("StudentClassID,ClassID,StudentId")] StudentClass studentClass)
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
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("StudentClassID,ClassID,StudentId")] StudentClass studentClass)
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
        [Authorize(Roles = "Administrator,Employer")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studentClass = await _context.StudentClasses
                .Include(sc => sc.Class)
                .Include(sc => sc.Student)
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
        [Authorize(Roles = "Administrator,Employer")]
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
