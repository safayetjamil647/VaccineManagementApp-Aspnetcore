using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MedicaTeams.Data;
using MedicaTeams.Models;

namespace MedicaTeams.Controllers
{
    public class VaccineCandidatesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public VaccineCandidatesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: VaccineCandidates
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.VaccineCandidate.Include(v => v.Venue);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: VaccineCandidates/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vaccineCandidate = await _context.VaccineCandidate
                .Include(v => v.Venue)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vaccineCandidate == null)
            {
                return NotFound();
            }

            return View(vaccineCandidate);
        }

        // GET: VaccineCandidates/Create
        public IActionResult Create()
        {
            ViewData["VenueId"] = new SelectList(_context.Venue, "VenueId", "VenueId");
            ViewBag.Options = new SelectList(_context.Venue, nameof(Venue.VenueId), nameof(Venue.VenueName));
            return View();
        }

        // POST: VaccineCandidates/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Age,PhoneNumber,VaccineDate,Abnormalities,VenueId")] VaccineCandidate vaccineCandidate)
        {
            if (ModelState.IsValid)
            {
                _context.Add(vaccineCandidate);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["VenueId"] = new SelectList(_context.Venue, "VenueId", "VenueId", vaccineCandidate.VenueId);
            return View(vaccineCandidate);
        }

        // GET: VaccineCandidates/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vaccineCandidate = await _context.VaccineCandidate.FindAsync(id);
            if (vaccineCandidate == null)
            {
                return NotFound();
            }
            ViewData["VenueId"] = new SelectList(_context.Venue, "VenueId", "VenueId", vaccineCandidate.VenueId);
            ViewBag.Options = new SelectList(_context.Venue, nameof(Venue.VenueId), nameof(Venue.VenueName));
            return View(vaccineCandidate);
        }

        // POST: VaccineCandidates/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Age,PhoneNumber,VaccineDate,Abnormalities,VenueId")] VaccineCandidate vaccineCandidate)
        {
            if (id != vaccineCandidate.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vaccineCandidate);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VaccineCandidateExists(vaccineCandidate.Id))
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
            ViewData["VenueId"] = new SelectList(_context.Venue, "VenueId", "VenueId", vaccineCandidate.VenueId);
            return View(vaccineCandidate);
        }

        // GET: VaccineCandidates/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vaccineCandidate = await _context.VaccineCandidate
                .Include(v => v.Venue)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vaccineCandidate == null)
            {
                return NotFound();
            }

            return View(vaccineCandidate);
        }

        // POST: VaccineCandidates/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var vaccineCandidate = await _context.VaccineCandidate.FindAsync(id);
            _context.VaccineCandidate.Remove(vaccineCandidate);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VaccineCandidateExists(int id)
        {
            return _context.VaccineCandidate.Any(e => e.Id == id);
        }
    }
}
