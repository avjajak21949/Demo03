using System;
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
    [Authorize(Roles = "Teacher")]
    public class AttendanceController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public AttendanceController(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Attendance
        public async Task<IActionResult> Index()
        {
            var teacherId = _userManager.GetUserId(User);
            var classes = await _context.Class
                .Include(c => c.Course)
                .ToListAsync();

            return View(classes);
        }

        // GET: Attendance/TakeAttendance/5
        public async Task<IActionResult> TakeAttendance(int? classId)
        {
            if (classId == null)
            {
                return NotFound();
            }

            var classWithStudents = await _context.Class
                .Include(c => c.StudentClasses)
                    .ThenInclude(sc => sc.StudentEnrollment)
                .FirstOrDefaultAsync(c => c.ClassID == classId);

            if (classWithStudents == null)
            {
                return NotFound();
            }

            // Get existing attendance records for today
            var today = DateTime.Today;
            var existingAttendance = await _context.Attendance
                .Where(a => a.ClassID == classId && a.Date.Date == today)
                .ToDictionaryAsync(a => a.StudentID, a => a);

            var attendanceViewModel = new AttendanceViewModel
            {
                ClassID = classWithStudents.ClassID,
                ClassName = classWithStudents.Name,
                Date = today,
                StudentAttendance = classWithStudents.StudentClasses
                    .Select(sc => new StudentAttendanceViewModel
                    {
                        StudentID = sc.SEID,
                        StudentName = sc.StudentEnrollment.FullName,
                        IsPresent = existingAttendance.ContainsKey(sc.SEID) && 
                                  existingAttendance[sc.SEID].IsPresent
                    })
                    .ToList()
            };

            return View(attendanceViewModel);
        }

        // POST: Attendance/TakeAttendance
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> TakeAttendance(AttendanceViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Remove existing attendance records for this class and date
                var existingRecords = await _context.Attendance
                    .Where(a => a.ClassID == model.ClassID && a.Date.Date == model.Date.Date)
                    .ToListAsync();
                _context.Attendance.RemoveRange(existingRecords);

                // Add new attendance records
                foreach (var studentAttendance in model.StudentAttendance)
                {
                    var attendance = new Attendance
                    {
                        StudentID = studentAttendance.StudentID,
                        ClassID = model.ClassID,
                        Date = model.Date,
                        IsPresent = studentAttendance.IsPresent
                    };
                    _context.Add(attendance);
                }

                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }
    }
} 