using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using Demo03.Data;
using Demo03.Models;

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
            var userRoles = await _userManager.GetRolesAsync(user);

            IQueryable<Meeting> query = _context.Meetings
                .Include(m => m.Class)
                .Include(m => m.Host);

            if (userRoles.Contains("Teacher"))
            {
                query = query.Where(m => m.HostUserId == user.Id);
            }
            else if (userRoles.Contains("Student"))
            {
                var studentClasses = await _context.StudentClasses
                    .Where(sc => sc.StudentId == user.Id)
                    .Select(sc => sc.ClassID)
                    .ToListAsync();

                query = query.Where(m => studentClasses.Contains(m.ClassID));
            }

            return View(await query.ToListAsync());
        }

        // GET: Meetings/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var meeting = await _context.Meetings
                .Include(m => m.Class)
                .Include(m => m.Host)
                .FirstOrDefaultAsync(m => m.MeetingID == id);

            if (meeting == null)
            {
                return NotFound();
            }

            return View(meeting);
        }

        // GET: Meetings/Create
        [Authorize(Roles = "Teacher")]
        public IActionResult Create()
        {
            ViewData["ClassID"] = new SelectList(_context.Classes, "ClassID", "Name");
            return View();
        }

        // POST: Meetings/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Teacher")]
        public async Task<IActionResult> Create([Bind("MeetingID,ClassID,Title,Description,StartTime,EndTime,MeetingLink")] Meeting meeting)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var user = await _userManager.GetUserAsync(User);
                    meeting.HostUserId = user.Id;
                    _context.Add(meeting);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "Unable to create meeting. Please try again.");
                }
            }
            ViewData["ClassID"] = new SelectList(_context.Classes, "ClassID", "Name", meeting.ClassID);
            return View(meeting);
        }

        // GET: Meetings/Edit/5
        [Authorize(Roles = "Teacher")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var meeting = await _context.Meetings.FindAsync(id);
            if (meeting == null)
            {
                return NotFound();
            }

            var user = await _userManager.GetUserAsync(User);
            if (meeting.HostUserId != user.Id)
            {
                return Forbid();
            }

            ViewData["ClassID"] = new SelectList(_context.Classes, "ClassID", "Name", meeting.ClassID);
            return View(meeting);
        }

        // POST: Meetings/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Teacher")]
        public async Task<IActionResult> Edit(int id, [Bind("MeetingID,ClassID,Title,Description,StartTime,EndTime,MeetingLink")] Meeting meeting)
        {
            if (id != meeting.MeetingID)
            {
                return NotFound();
            }

            var existingMeeting = await _context.Meetings.AsNoTracking().FirstOrDefaultAsync(m => m.MeetingID == id);
            if (existingMeeting == null)
            {
                return NotFound();
            }

            var user = await _userManager.GetUserAsync(User);
            if (existingMeeting.HostUserId != user.Id)
            {
                return Forbid();
            }

            meeting.HostUserId = user.Id;

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(meeting);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MeetingExists(meeting.MeetingID))
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
            ViewData["ClassID"] = new SelectList(_context.Classes, "ClassID", "Name", meeting.ClassID);
            return View(meeting);
        }

        // GET: Meetings/Delete/5
        [Authorize(Roles = "Teacher")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var meeting = await _context.Meetings
                .Include(m => m.Class)
                .Include(m => m.Host)
                .FirstOrDefaultAsync(m => m.MeetingID == id);

            if (meeting == null)
            {
                return NotFound();
            }

            var user = await _userManager.GetUserAsync(User);
            if (meeting.HostUserId != user.Id)
            {
                return Forbid();
            }

            return View(meeting);
        }

        // POST: Meetings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Teacher")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var meeting = await _context.Meetings.FindAsync(id);
            if (meeting == null)
            {
                return NotFound();
            }

            var user = await _userManager.GetUserAsync(User);
            if (meeting.HostUserId != user.Id)
            {
                return Forbid();
            }

            _context.Meetings.Remove(meeting);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MeetingExists(int id)
        {
            return _context.Meetings.Any(e => e.MeetingID == id);
        }
    }
} 