using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Demo03.Data;
using Demo03.Models;

namespace Demo03.Controllers
{
    public class SchedulesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SchedulesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Schedules
        public async Task<IActionResult> Index()
        {
            var schedules = _context.Schedule
                .Include(s => s.Class)
                .ThenInclude(c => c.Course);
            return View(await schedules.ToListAsync());
        }

        // GET: Schedules/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var schedule = await _context.Schedule
                .Include(s => s.Class)
                .ThenInclude(c => c.Course)
                .FirstOrDefaultAsync(m => m.ScheduleID == id);
                
            if (schedule == null)
            {
                return NotFound();
            }

            return View(schedule);
        }

        // GET: Schedules/Create
        public IActionResult Create(int? classId)
        {
            if (classId.HasValue)
            {
                ViewData["ClassID"] = new SelectList(_context.Class.Include(c => c.Course), "ClassID", "Name", classId);
            }
            else
            {
                ViewData["ClassID"] = new SelectList(_context.Class.Include(c => c.Course), "ClassID", "Name");
            }
            
            return View();
        }

        // POST: Schedules/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ScheduleID,ClassID,StartDate,EndDate,DaysOfWeek,StartTime,EndTime,Location")] Schedule schedule)
        {
            if (ModelState.IsValid)
            {
                // Validate no scheduling conflicts
                if (HasSchedulingConflict(schedule))
                {
                    ModelState.AddModelError("", "This schedule conflicts with an existing schedule");
                    ViewData["ClassID"] = new SelectList(_context.Class, "ClassID", "Name", schedule.ClassID);
                    return View(schedule);
                }
                
                _context.Add(schedule);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            
            ViewData["ClassID"] = new SelectList(_context.Class, "ClassID", "Name", schedule.ClassID);
            return View(schedule);
        }

        // GET: Schedules/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var schedule = await _context.Schedule.FindAsync(id);
            if (schedule == null)
            {
                return NotFound();
            }
            
            ViewData["ClassID"] = new SelectList(_context.Class, "ClassID", "Name", schedule.ClassID);
            return View(schedule);
        }

        // POST: Schedules/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ScheduleID,ClassID,StartDate,EndDate,DaysOfWeek,StartTime,EndTime,Location")] Schedule schedule)
        {
            if (id != schedule.ScheduleID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                // Validate no scheduling conflicts (excluding this schedule)
                if (HasSchedulingConflict(schedule, excludeId: id))
                {
                    ModelState.AddModelError("", "This schedule conflicts with an existing schedule");
                    ViewData["ClassID"] = new SelectList(_context.Class, "ClassID", "Name", schedule.ClassID);
                    return View(schedule);
                }
                
                try
                {
                    _context.Update(schedule);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ScheduleExists(schedule.ScheduleID))
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
            
            ViewData["ClassID"] = new SelectList(_context.Class, "ClassID", "Name", schedule.ClassID);
            return View(schedule);
        }

        // GET: Schedules/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var schedule = await _context.Schedule
                .Include(s => s.Class)
                .FirstOrDefaultAsync(m => m.ScheduleID == id);
                
            if (schedule == null)
            {
                return NotFound();
            }

            return View(schedule);
        }

        // GET: Schedules/Calendar
        public async Task<IActionResult> Calendar()
        {
        var schedules = await _context.Schedule
        .Include(s => s.Class)
        .ThenInclude(c => c.Course)
        .ToListAsync();
    
        return View(schedules);
        }

        // POST: Schedules/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var schedule = await _context.Schedule.FindAsync(id);
            _context.Schedule.Remove(schedule);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ScheduleExists(int id)
        {
            return _context.Schedule.Any(e => e.ScheduleID == id);
        }
        
        private bool HasSchedulingConflict(Schedule schedule, int? excludeId = null)
        {
            // Get schedules for the same class that might overlap
            var classSchedules = _context.Schedule
                .Where(s => s.ClassID == schedule.ClassID);
                
            if (excludeId.HasValue)
            {
                classSchedules = classSchedules.Where(s => s.ScheduleID != excludeId.Value);
            }
                
            foreach (var existingSchedule in classSchedules)
            {
                // Check for date overlap
                bool datesOverlap = schedule.StartDate <= existingSchedule.EndDate && 
                                   existingSchedule.StartDate <= schedule.EndDate;
                
                if (datesOverlap)
                {
                    // Check for day of week overlap
                    string[] newDays = schedule.DaysOfWeek.Split(',');
                    string[] existingDays = existingSchedule.DaysOfWeek.Split(',');
                    
                    bool daysOverlap = newDays.Any(day => existingDays.Contains(day));
                    
                    if (daysOverlap)
                    {
                        // Check for time overlap
                        bool timesOverlap = schedule.StartTime < existingSchedule.EndTime && 
                                           existingSchedule.StartTime < schedule.EndTime;
                        
                        if (timesOverlap)
                        {
                            return true; // Conflict found
                        }
                    }
                }
            }
            
            return false; // No conflict
        }
    }
}

