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
    [Authorize]
    public class MeetingsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public MeetingsController(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Meetings
        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(User);
            var meetings = await _context.Meetings
                .Include(m => m.Class)
                .Include(m => m.Host)
                .Where(m => m.StartTime >= DateTime.Today)
                .OrderBy(m => m.StartTime)
                .ToListAsync();

            return View(meetings);
        }

        // GET: Meetings/Create
        [Authorize(Roles = "Teacher")]
        public IActionResult Create()
        {
            ViewData["ClassID"] = new SelectList(_context.Class, "ClassID", "Name");
            return View();
        }

        // POST: Meetings/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Teacher")]
        public async Task<IActionResult> Create([Bind("Title,StartTime,ClassID,Description")] Meeting meeting)
        {
            if (ModelState.IsValid)
            {
                meeting.HostUserId = _userManager.GetUserId(User);
                
                // Generate a unique meeting room identifier
                string meetingId = Guid.NewGuid().ToString("N").Substring(0, 10);
                
                // Create the meeting room link using the application's domain
                // In production, this should use the actual domain name
                meeting.MeetingLink = $"/MeetingRoom/{meetingId}";
                
                _context.Add(meeting);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClassID"] = new SelectList(_context.Class, "ClassID", "Name", meeting.ClassID);
            return View(meeting);
        }
    }
} 