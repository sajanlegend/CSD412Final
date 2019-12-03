using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BirdWatcherWebApp.Data;
using BirdWatcherWebApp.Models;

namespace BirdWatcherWebApp.Controllers
{
    public class spottedsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public spottedsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: spotteds
        public async Task<IActionResult> Index()
        {
            return View(await _context.spotted.ToListAsync());
        }

        // GET: spotteds/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var spotted = await _context.spotted
                .FirstOrDefaultAsync(m => m.id == id);
            if (spotted == null)
            {
                return NotFound();
            }

            return View(spotted);
        }

        // GET: spotteds/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: spotteds/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,Bird,QuantitySpotted,longitude,latitude")] spotted spotted)
        {
            if (ModelState.IsValid)
            {
                _context.Add(spotted);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(spotted);
        }

        // GET: spotteds/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var spotted = await _context.spotted.FindAsync(id);
            if (spotted == null)
            {
                return NotFound();
            }
            return View(spotted);
        }

        // POST: spotteds/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,Bird,QuantitySpotted,longitude,latitude")] spotted spotted)
        {
            if (id != spotted.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(spotted);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!spottedExists(spotted.id))
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
            return View(spotted);
        }

        // GET: spotteds/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var spotted = await _context.spotted
                .FirstOrDefaultAsync(m => m.id == id);
            if (spotted == null)
            {
                return NotFound();
            }

            return View(spotted);
        }

        // POST: spotteds/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var spotted = await _context.spotted.FindAsync(id);
            _context.spotted.Remove(spotted);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool spottedExists(int id)
        {
            return _context.spotted.Any(e => e.id == id);
        }
    }
}
