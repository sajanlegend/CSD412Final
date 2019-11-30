﻿using System;
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
    public class BirdsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BirdsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Birds
        public async Task<IActionResult> Index()
        {
            return View(await _context.Bird.ToListAsync());
        }

        // GET: Birds/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bird = await _context.Bird
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bird == null)
            {
                return NotFound();
            }

            return View(bird);
        }

        // GET: Birds/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Birds/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] Bird bird)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bird);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(bird);
        }

        // GET: Birds/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bird = await _context.Bird.FindAsync(id);
            if (bird == null)
            {
                return NotFound();
            }
            return View(bird);
        }

        // POST: Birds/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] Bird bird)
        {
            if (id != bird.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bird);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BirdExists(bird.Id))
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
            return View(bird);
        }

        // GET: Birds/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bird = await _context.Bird
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bird == null)
            {
                return NotFound();
            }

            return View(bird);
        }

        // POST: Birds/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bird = await _context.Bird.FindAsync(id);
            _context.Bird.Remove(bird);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BirdExists(int id)
        {
            return _context.Bird.Any(e => e.Id == id);
        }
    }
}
