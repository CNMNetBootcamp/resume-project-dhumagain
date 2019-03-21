using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ResumeProject.Data;
using ResumeProject.Models;

namespace ResumeProject.Controllers
{
    public class ReferencesController : Controller
    {
        private readonly ResumeContext _context;

        public ReferencesController(ResumeContext context)
        {
            _context = context;
        }

        [Authorize]
        // GET: References
        public async Task<IActionResult> Index()
        {
            var resumeContext = _context.References.Include(r => r.Applicant);
            return View(await resumeContext.ToListAsync());
        }

        [Authorize]
        // GET: References/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reference = await _context.References
                .Include(r => r.Applicant)
                .SingleOrDefaultAsync(m => m.ReferenceID == id);
            if (reference == null)
            {
                return NotFound();
            }

            return View(reference);
        }

        [Authorize]
        // GET: References/Create
        public IActionResult Create()
        {
            ViewData["ApplicantID"] = new SelectList(_context.Applicants, "ApplicantID", "LastName");
            return View();
        }

        // POST: References/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ReferenceID,LastName,FirstName,PhoneNumber,ApplicantID")] Reference reference)
        {
            if (ModelState.IsValid)
            {
                _context.Add(reference);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ApplicantID"] = new SelectList(_context.Applicants, "ApplicantID", "LastName", reference.ApplicantID);
            return View(reference);
        }

        [Authorize]
        // GET: References/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reference = await _context.References.SingleOrDefaultAsync(m => m.ReferenceID == id);
            if (reference == null)
            {
                return NotFound();
            }
            ViewData["ApplicantID"] = new SelectList(_context.Applicants, "ApplicantID", "LastName", reference.ApplicantID);
            return View(reference);
        }

        [Authorize]
        // POST: References/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ReferenceID,LastName,FirstName,PhoneNumber,ApplicantID")] Reference reference)
        {
            if (id != reference.ReferenceID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(reference);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReferenceExists(reference.ReferenceID))
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
            ViewData["ApplicantID"] = new SelectList(_context.Applicants, "ApplicantID", "LastName", reference.ApplicantID);
            return View(reference);
        }

        // GET: References/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reference = await _context.References
                .Include(r => r.Applicant)
                .SingleOrDefaultAsync(m => m.ReferenceID == id);
            if (reference == null)
            {
                return NotFound();
            }

            return View(reference);
        }

        // POST: References/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var reference = await _context.References.SingleOrDefaultAsync(m => m.ReferenceID == id);
            _context.References.Remove(reference);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReferenceExists(int id)
        {
            return _context.References.Any(e => e.ReferenceID == id);
        }
    }
}
