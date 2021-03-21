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
    public class ApplyOnlinesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ApplyOnlinesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ApplyOnlines
        public async Task<IActionResult> Index(string searchString, string sortOrder, int? pageNumber, string currentFilter)
        {
            ViewData["DateSortParm"] = sortOrder == "Date" ? "date_desc" : "Date";
            if (searchString != null)
            {
                pageNumber = 1;
            }
            else
            {
                searchString = currentFilter;
            }
            ViewData["CurrentFilter"] = searchString;
            var onlines = from o in _context.ApplyOnlines.Include(a => a.Venue)
                          select o;
            if(!String.IsNullOrEmpty(searchString))
            {
                onlines = onlines.Where(s=>s.Name.Contains(searchString));
            }
            switch (sortOrder)
            {

                case "Date":
                    onlines = onlines.OrderBy(s => s.PreferedDate);
                    break;
                case "date_desc":
                    onlines = onlines.OrderByDescending(s => s.PreferedDate);
                    break;
                default:
                    onlines = onlines.OrderBy(s => s.Name);
                    break;
            }
            int pageSize = 5;
            return View(await PaginatedList<ApplyOnline>.CreateAsync(onlines.AsNoTracking(), pageNumber ?? 1, pageSize));
            //var applicationDbContext = _context.ApplyOnlines.Include(a => a.Venue);
            return View(await onlines.ToListAsync());
        }

        // GET: ApplyOnlines/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var applyOnline = await _context.ApplyOnlines
                .Include(a => a.Venue)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (applyOnline == null)
            {
                return NotFound();
            }

            return View(applyOnline);
        }

        // GET: ApplyOnlines/Create
        public IActionResult Create()
        {
            ViewData["VenueId"] = new SelectList(_context.Venue, "VenueId", "VenueId");
            ViewBag.Options = new SelectList(_context.Venue, nameof(Venue.VenueId), nameof(Venue.VenueName));
            return View();
        }

        // POST: ApplyOnlines/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,PhoneNumber,Age,PreferedDate,VenueId,Abnormalities")] ApplyOnline applyOnline)
        {
            if (ModelState.IsValid)
            {
                _context.Add(applyOnline);
                await _context.SaveChangesAsync();
                return RedirectToAction("Welcome","Home");
            }
            
            ViewData["VenueId"] = new SelectList(_context.Venue, "VenueId", "VenueId", applyOnline.VenueId);
            return RedirectToAction(nameof(applyOnline));
        }

        // GET: ApplyOnlines/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var applyOnline = await _context.ApplyOnlines.FindAsync(id);
            if (applyOnline == null)
            {
                return NotFound();
            }
            ViewData["VenueId"] = new SelectList(_context.Venue, "VenueId", "VenueId", applyOnline.VenueId);
            ViewBag.Options = new SelectList(_context.Venue, nameof(Venue.VenueId), nameof(Venue.VenueName));
            return View(applyOnline);
        }

        // POST: ApplyOnlines/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,PhoneNumber,Age,PreferedDate,VenueId,Abnormalities")] ApplyOnline applyOnline)
        {
            if (id != applyOnline.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(applyOnline);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ApplyOnlineExists(applyOnline.Id))
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
            ViewData["VenueId"] = new SelectList(_context.Venue, "VenueId", "VenueId", applyOnline.VenueId);
            
            
            return View(applyOnline);
        }

        // GET: ApplyOnlines/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var applyOnline = await _context.ApplyOnlines
                .Include(a => a.Venue)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (applyOnline == null)
            {
                return NotFound();
            }

            return View(applyOnline);
        }

        // POST: ApplyOnlines/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var applyOnline = await _context.ApplyOnlines.FindAsync(id);
            _context.ApplyOnlines.Remove(applyOnline);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ApplyOnlineExists(int id)
        {
            return _context.ApplyOnlines.Any(e => e.Id == id);
        }
    }
}
