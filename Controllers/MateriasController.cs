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
    public class MateriasController : Controller
    {
        private readonly notasContext _context;

        public MateriasController(notasContext context)
        {
            _context = context;
        }

        // GET: Materias
        public async Task<IActionResult> Index()
        {
            return View(await _context.materias.ToListAsync());
        }

        // GET: Materias/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mater = await _context.materias
                .FirstOrDefaultAsync(m => m.id == id);
            if (mater == null)
            {
                return NotFound();
            }

            return View(mater);
        }

        // GET: Materias/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Materias/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,materia,unidades_valorativas,estado")] mater mater)
        {
            if (ModelState.IsValid)
            {
                _context.Add(mater);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(mater);
        }

        // GET: Materias/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mater = await _context.materias.FindAsync(id);
            if (mater == null)
            {
                return NotFound();
            }
            return View(mater);
        }

        // POST: Materias/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,materia,unidades_valorativas,estado")] mater mater)
        {
            if (id != mater.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mater);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!materExists(mater.id))
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
            return View(mater);
        }

        // GET: Materias/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mater = await _context.materias
                .FirstOrDefaultAsync(m => m.id == id);
            if (mater == null)
            {
                return NotFound();
            }

            return View(mater);
        }

        // POST: Materias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var mater = await _context.materias.FindAsync(id);
            if (mater != null)
            {
                _context.materias.Remove(mater);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool materExists(int id)
        {
            return _context.materias.Any(e => e.id == id);
        }
    }
}
