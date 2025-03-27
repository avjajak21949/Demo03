using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Demo03.Data;
using Demo03.Models;

namespace Demo03.Controllers
{
    public class StudentEnrollmentsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public StudentEnrollmentsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: StudentEnrollments
        public async Task<IActionResult> Index()
        {
            return View(await _context.StudentEnrollment.ToListAsync());
        }

        // GET: StudentEnrollments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studentEnrollment = await _context.StudentEnrollment
                .FirstOrDefaultAsync(m => m.SEID == id);
            if (studentEnrollment == null)
            {
                return NotFound();
            }

            return View(studentEnrollment);
        }

        // GET: StudentEnrollments/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: StudentEnrollments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SEID,Name")] StudentEnrollment studentEnrollment)
        {
            if (ModelState.IsValid)
            {
                _context.Add(studentEnrollment);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(studentEnrollment);
        }

        // GET: StudentEnrollments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studentEnrollment = await _context.StudentEnrollment.FindAsync(id);
            if (studentEnrollment == null)
            {
                return NotFound();
            }
            return View(studentEnrollment);
        }

        // POST: StudentEnrollments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SEID,Name")] StudentEnrollment studentEnrollment)
        {
            if (id != studentEnrollment.SEID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(studentEnrollment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StudentEnrollmentExists(studentEnrollment.SEID))
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
            return View(studentEnrollment);
        }

        // GET: StudentEnrollments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studentEnrollment = await _context.StudentEnrollment
                .FirstOrDefaultAsync(m => m.SEID == id);
            if (studentEnrollment == null)
            {
                return NotFound();
            }

            return View(studentEnrollment);
        }

        // POST: StudentEnrollments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var studentEnrollment = await _context.StudentEnrollment.FindAsync(id);
            _context.StudentEnrollment.Remove(studentEnrollment);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StudentEnrollmentExists(int id)
        {
            return _context.StudentEnrollment.Any(e => e.SEID == id);
        }
    }
}
