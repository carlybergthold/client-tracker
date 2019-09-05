using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ClientTracker.Data;
using ClientTracker.Models;

namespace ClientTracker.Controllers
{
    public class DisordersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DisordersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Disorders
        public async Task<IActionResult> Index()
        {
            return View(await _context.Disorders.ToListAsync());
        }

        // GET: Disorders/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var disorder = await _context.Disorders
                .FirstOrDefaultAsync(m => m.Id == id);
            if (disorder == null)
            {
                return NotFound();
            }

            return View(disorder);
        }

        // GET: Disorders/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Disorders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description")] Disorder disorder)
        {
            if (ModelState.IsValid)
            {
                _context.Add(disorder);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(disorder);
        }

        // GET: Disorders/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var disorder = await _context.Disorders.FindAsync(id);
            if (disorder == null)
            {
                return NotFound();
            }
            return View(disorder);
        }

        // POST: Disorders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description")] Disorder disorder)
        {
            if (id != disorder.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(disorder);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DisorderExists(disorder.Id))
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
            return View(disorder);
        }

        // GET: Disorders/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var disorder = await _context.Disorders
                .FirstOrDefaultAsync(m => m.Id == id);
            if (disorder == null)
            {
                return NotFound();
            }

            return View(disorder);
        }

        // POST: Disorders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var disorder = await _context.Disorders.FindAsync(id);
            _context.Disorders.Remove(disorder);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DisorderExists(int id)
        {
            return _context.Disorders.Any(e => e.Id == id);
        }
    }
}
