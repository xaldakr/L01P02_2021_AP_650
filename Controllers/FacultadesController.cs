using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using L01P02_2021_AP_650.Models;

namespace L01P02_2021_AP_650.Controllers
{
    public class FacultadesController : Controller
    {
        private readonly notasContext _context;

        public FacultadesController(notasContext context)
        {
            _context = context;
        }

        // GET: Facultades
        public async Task<IActionResult> Index()
        {
            return View(await _context.facultades.ToListAsync());
        }

        // GET: Facultades/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var facultade = await _context.facultades
                .FirstOrDefaultAsync(m => m.id == id);
            if (facultade == null)
            {
                return NotFound();
            }

            return View(facultade);
        }

        // GET: Facultades/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Facultades/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,facultad")] facultade facultade)
        {
            if (ModelState.IsValid)
            {
                _context.Add(facultade);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(facultade);
        }

        // GET: Facultades/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var facultade = await _context.facultades.FindAsync(id);
            if (facultade == null)
            {
                return NotFound();
            }
            return View(facultade);
        }

        // POST: Facultades/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,facultad")] facultade facultade)
        {
            if (id != facultade.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(facultade);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!facultadeExists(facultade.id))
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
            return View(facultade);
        }

        // GET: Facultades/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var facultade = await _context.facultades
                .FirstOrDefaultAsync(m => m.id == id);
            if (facultade == null)
            {
                return NotFound();
            }

            return View(facultade);
        }

        // POST: Facultades/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var facultade = await _context.facultades.FindAsync(id);
            if (facultade != null)
            {
                _context.facultades.Remove(facultade);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool facultadeExists(int id)
        {
            return _context.facultades.Any(e => e.id == id);
        }
    }
}
