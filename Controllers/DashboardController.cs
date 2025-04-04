using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Demo03.Data;
using Demo03.Models;
using System.Collections;

namespace Demo03.Controllers
{
    public class DashboardController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DashboardController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var dashboard = new DashboardViewModel
            {
                TotalCourses = await _context.Course.CountAsync(),
                TotalClasses = await _context.Class.CountAsync(),
                UpcomingSchedules = await _context.Schedule
                    .Include(s => s.Class)
                    .ThenInclude(c => c.Course)
                    .Where(s => s.StartDate >= DateTime.Today)
                    .OrderBy(s => s.StartDate)
                    .Take(5)
                    .ToListAsync(),
                TodaySchedules = await _context.Schedule
                    .Include(s => s.Class)
                    .ThenInclude(c => c.Course)
                    .Where(s => s.StartDate.Date == DateTime.Today.Date)
                    .OrderBy(s => s.StartTime)
                    .ToListAsync()
            };

            return View(dashboard);
        }
    }

    public class DashboardViewModel
    {
        public int TotalCourses { get; set; }
        public int TotalClasses { get; set; }
        public ICollection<Schedule> UpcomingSchedules { get; set; }
        public ICollection<Schedule> TodaySchedules { get; set; }
    }
} 