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
    public class ApplicantsController : Controller
    {
        private readonly ResumeContext _context;

        public ApplicantsController(ResumeContext context)
        {
            _context = context;
        }

        // GET: Applicants
       // [Authorize]
        public async Task<IActionResult> Index(
            string sortOrder,
            string currentFilter,
            string searchString,
            int? page)
        {
            ViewData["CurrentSort"] = sortOrder;
            ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewData["DateSortParm"] = sortOrder == "Date" ? "date_desc" : "Date";

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewData["CurrentFilter"] = searchString;

            var applicants = from s in _context.Applicants
                           select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                applicants = applicants.Where(s => s.LastName.Contains(searchString)
                                       || s.FirstName.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "name_desc":
                    applicants = applicants.OrderByDescending(s => s.LastName);
                    break;
                case "Date":
                    applicants = applicants.OrderBy(s => s.PhoneNumber);
                    break;
                case "date_desc":
                    applicants = applicants.OrderByDescending(s => s.PhoneNumber);
                    break;
                default:
                    applicants = applicants.OrderBy(s => s.LastName);
                    break;
            }

            int pageSize = 1;
            return View(await PaginatedList<Applicant>.CreateAsync(applicants.AsNoTracking(), page ?? 1, pageSize));

          //  return View(await applicants.AsNoTracking().ToListAsync());
        }

        // GET: Applicants/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var applicant = await _context.Applicants
                .Include (e => e.Educations)
                .Include(r => r.References)
                .Include(j => j.Jobs)
                    .ThenInclude (d =>d.Duties)
                
                .AsNoTracking()
                .SingleOrDefaultAsync(m => m.ApplicantID == id);            

            if (applicant == null)
            {
                return NotFound();
            }

            return View(applicant);
        }

        // GET: Applicants/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Applicants/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("LastName,FirstName,Address,PhoneNumber")] Applicant applicant)
        {
            try
            {

            
                if (ModelState.IsValid)
                {
                    _context.Add(applicant);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (DbUpdateException)
            {
                
                ModelState.AddModelError("", "Unable to save changes.");
            }

            if (ModelState.IsValid)             //check for validation and add and save changes
            {
                _context.Add(applicant);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
           
            return View(applicant);
        }

        // GET: Applicants/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var applicant = await _context.Applicants.SingleOrDefaultAsync(m => m.ApplicantID == id);
            if (applicant == null)
            {
                return NotFound();
            }
            return View(applicant);
        }

        // POST: Applicants/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditPost(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var applicantToUpdate = await _context.Applicants.SingleOrDefaultAsync(s => s.ApplicantID == id);
            if (await TryUpdateModelAsync<Applicant>(
                applicantToUpdate,
                "",
                s => s.FirstName, s => s.LastName, s=>s.Address, s =>s.PhoneNumber))
            {
                try
                {
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateException /* ex */)
                {
                    //Log the error (uncomment ex variable name and write a log.)
                    ModelState.AddModelError("", "Unable to save changes. ");
                }
            }
            return View(applicantToUpdate);
        }

        // GET: Applicants/Delete/5
        public async Task<IActionResult> Delete(int? id, bool? saveChangesError = false)
        {
            if (id == null)
            {
                return NotFound();
            }

            var applicant = await _context.Applicants
                .AsNoTracking()
                .SingleOrDefaultAsync(m => m.ApplicantID == id);
            if (applicant == null)
            {
                return NotFound();
            }

            if (saveChangesError.GetValueOrDefault())
            {
                ViewData["ErrorMessage"] =
                    "Delete failed. Try again, and if the problem persists " +
                    "see your system administrator.";
            }

            return View(applicant);
        }

        // POST: Applicants/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var applicant = await _context.Applicants
                .AsNoTracking()
                .SingleOrDefaultAsync(m => m.ApplicantID == id);
            if (applicant == null)
            {
                return RedirectToAction(nameof(Index));
            }
            try
            {
                _context.Applicants.Remove(applicant);

                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            catch (DbUpdateException )
            {
                //Log the error (uncomment ex variable name and write a log.)
                return RedirectToAction(nameof(Delete), new { id = id, saveChangesError = true });
            }

        }

        //private bool ApplicantExists(int id)
        //{
        //    return _context.Applicants.Any(e => e.ApplicantID == id);
        //}
    }
}
