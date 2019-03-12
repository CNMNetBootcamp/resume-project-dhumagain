using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ResumeProject.Data;
using ResumeProject.Models;

namespace ResumeProject.Controllers
{
    public class DutiesController : Controller
    {
        private readonly ResumeContext _context;

        public DutiesController(ResumeContext context)
        {
            _context = context;
        }

        // GET: Duties
        public async Task<IActionResult> Index()
        {
            return View(await _context.Duties.ToListAsync());
        }

        // GET: Duties/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var duty = await _context.Duties
                .Include(d=>d.JobID)
                .SingleOrDefaultAsync(m => m.DutyID == id);
            if (duty == null)
            {
                return NotFound();
            }

            return View(duty);
        }

        // GET: Duties/Create
        public IActionResult Create()
        {
            ViewData["JobID"] = new SelectList(_context.Jobs, "JobID","Position");
            return View();
            
        }

        // POST: Duties/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DutyID,DutiesPerformed,JobID")] Duty duty)
        {
            if (ModelState.IsValid)
            {
                _context.Add(duty);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(duty);
        }

        // GET: Duties/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var duty = await _context.Duties.SingleOrDefaultAsync(m => m.DutyID == id);
            if (duty == null)
            {
                return NotFound();
            }
            return View(duty);
        }

        // POST: Duties/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DutyID,DutiesPerformed,JobID")] Duty duty)
        {
            if (id != duty.DutyID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(duty);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DutyExists(duty.DutyID))
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
            return View(duty);
        }

        // GET: Duties/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var duty = await _context.Duties
                .SingleOrDefaultAsync(m => m.DutyID == id);
            if (duty == null)
            {
                return NotFound();
            }

            return View(duty);
        }

        // POST: Duties/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var duty = await _context.Duties.SingleOrDefaultAsync(m => m.DutyID == id);
            _context.Duties.Remove(duty);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DutyExists(int id)
        {
            return _context.Duties.Any(e => e.DutyID == id);
        }
    }
}
