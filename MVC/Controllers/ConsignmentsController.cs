using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DAL.Impl;
using Entities;

namespace MVC.Controllers
{
    public class ConsignmentsController : Controller
    {
        private readonly CsisDbContext _context;

        public ConsignmentsController(CsisDbContext context)
        {
            _context = context;
        }

        // GET: Consignments
        public async Task<IActionResult> Index()
        {
            var csisDbContext = _context.Consignments.Include(c => c.Cosmetic);
            return View(await csisDbContext.ToListAsync());
        }

        // GET: Consignments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var consignment = await _context.Consignments
                .Include(c => c.Cosmetic)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (consignment == null)
            {
                return NotFound();
            }

            return View(consignment);
        }

        // GET: Consignments/Create
        public IActionResult Create()
        {
            ViewData["CosmeticId"] = new SelectList(_context.Cosmetics, "Id", "Id");
            return View();
        }

        // POST: Consignments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CosmeticId,Units,ProductionDate,IsEnding,Id")] Consignment consignment)
        {
            if (ModelState.IsValid)
            {
                _context.Add(consignment);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CosmeticId"] = new SelectList(_context.Cosmetics, "Id", "Id", consignment.CosmeticId);
            return View(consignment);
        }

        // GET: Consignments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var consignment = await _context.Consignments.FindAsync(id);
            if (consignment == null)
            {
                return NotFound();
            }
            ViewData["CosmeticId"] = new SelectList(_context.Cosmetics, "Id", "Id", consignment.CosmeticId);
            return View(consignment);
        }

        // POST: Consignments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CosmeticId,Units,ProductionDate,IsEnding,Id")] Consignment consignment)
        {
            if (id != consignment.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(consignment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ConsignmentExists(consignment.Id))
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
            ViewData["CosmeticId"] = new SelectList(_context.Cosmetics, "Id", "Id", consignment.CosmeticId);
            return View(consignment);
        }

        // GET: Consignments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var consignment = await _context.Consignments
                .Include(c => c.Cosmetic)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (consignment == null)
            {
                return NotFound();
            }

            return View(consignment);
        }

        // POST: Consignments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var consignment = await _context.Consignments.FindAsync(id);
            _context.Consignments.Remove(consignment);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ConsignmentExists(int id)
        {
            return _context.Consignments.Any(e => e.Id == id);
        }
    }
}
