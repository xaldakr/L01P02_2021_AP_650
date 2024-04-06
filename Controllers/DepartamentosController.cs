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
    public class DepartamentosController : Controller
    {
        private readonly notasContext _context;

        public DepartamentosController(notasContext context)
        {
            _context = context;
        }

        // GET: Departamentos
        public async Task<IActionResult> Index()
        {
            return View(await _context.departamentos.ToListAsync());
        }

        // GET: Departamentos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var depart = await _context.departamentos
                .FirstOrDefaultAsync(m => m.id == id);
            if (depart == null)
            {
                return NotFound();
            }

            return View(depart);
        }

        // GET: Departamentos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Departamentos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,departamento")] depart depart)
        {
            if (ModelState.IsValid)
            {
                _context.Add(depart);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(depart);
        }

        // GET: Departamentos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var depart = await _context.departamentos.FindAsync(id);
            if (depart == null)
            {
                return NotFound();
            }
            return View(depart);
        }

        // POST: Departamentos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,departamento")] depart depart)
        {
            if (id != depart.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(depart);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!departExists(depart.id))
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
            return View(depart);
        }

        // GET: Departamentos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var depart = await _context.departamentos
                .FirstOrDefaultAsync(m => m.id == id);
            if (depart == null)
            {
                return NotFound();
            }

            return View(depart);
        }

        // POST: Departamentos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var depart = await _context.departamentos.FindAsync(id);
            if (depart != null)
            {
                _context.departamentos.Remove(depart);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool departExists(int id)
        {
            return _context.departamentos.Any(e => e.id == id);
        }
    }
}
