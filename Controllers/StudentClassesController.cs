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
using Demo03.Services;

namespace Demo03.Controllers
{
    [Authorize]
    public class StudentClassesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IEmailService _emailService;

        public StudentClassesController(
            ApplicationDbContext context, 
            UserManager<IdentityUser> userManager,
            IEmailService emailService)
        {
            _context = context;
            _userManager = userManager;
            _emailService = emailService;
        }

        // GET: StudentClasses
        [Authorize(Roles = "Admin,Employer,Teacher")]
        public async Task<IActionResult> Index()
        {
            var studentClasses = await _context.StudentClasses
                .Include(sc => sc.Class)
                .Include(sc => sc.Student)
                .ToListAsync();
            return View(studentClasses);
        }

        // GET: StudentClasses/Details/5
        [Authorize(Roles = "Admin,Employer,Teacher")]
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
        [Authorize(Roles = "Admin,Employer")]
        public IActionResult Create()
        {
            ViewData["ClassID"] = new SelectList(_context.Classes, "ClassID", "Name");
            ViewData["StudentId"] = new SelectList(_context.Students, "Id", "FullName");
            return View();
        }

        // POST: StudentClasses/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin,Employer")]
        public async Task<IActionResult> Create([Bind("StudentClassID,ClassID,StudentId")] StudentClass studentClass)
        {
            if (ModelState.IsValid)
            {
                _context.Add(studentClass);
                await _context.SaveChangesAsync();

                // Get class and student details for the email
                var classDetails = await _context.Classes
                    .Include(c => c.Course)
                    .Include(c => c.Teacher)
                    .FirstOrDefaultAsync(c => c.ClassID == studentClass.ClassID);

                var student = await _context.Students
                    .FirstOrDefaultAsync(s => s.Id == studentClass.StudentId);

                if (classDetails != null && student != null)
                {
                    var emailSubject = "New Class Enrollment Notification";
                    var emailBody = $@"
                        <h2>Class Enrollment Notification</h2>
                        <p>Dear {student.FullName},</p>
                        <p>You have been enrolled in a new class:</p>
                        <p><strong>Class Name:</strong> {classDetails.Name}</p>
                        <p><strong>Course:</strong> {classDetails.Course?.Name}</p>
                        <p><strong>Teacher:</strong> {classDetails.Teacher?.FullName}</p>
                        <p><strong>Schedule:</strong> {classDetails.ScheduleInfo}</p>
                        <p>You can view your class details and materials by logging into your account.</p>
                        <p>Best regards,<br>E-Learning Team</p>";

                    await _emailService.SendEmailAsync(student.Email, emailSubject, emailBody);
                }

                return RedirectToAction(nameof(Index));
            }
            ViewData["ClassID"] = new SelectList(_context.Classes, "ClassID", "Name", studentClass.ClassID);
            ViewData["StudentId"] = new SelectList(_context.Students, "Id", "FullName", studentClass.StudentId);
            return View(studentClass);
        }

        // GET: StudentClasses/Edit/5
        [Authorize(Roles = "Admin,Employer")]
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
        [Authorize(Roles = "Admin,Employer")]
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
        [Authorize(Roles = "Admin,Employer")]
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
        [Authorize(Roles = "Admin  ,Employer")]
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
