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
    public class AlumnosController : Controller
    {
        private readonly notasContext _context;

        public AlumnosController(notasContext context)
        {
            _context = context;
        }

        // GET: Alumnos
        public async Task<IActionResult> Index()
        {
            return View(await _context.alumnos.ToListAsync());
        }

        // GET: Alumnos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var alumn = await _context.alumnos
                .FirstOrDefaultAsync(m => m.id == id);
            if (alumn == null)
            {
                return NotFound();
            }

            return View(alumn);
        }

        // GET: Alumnos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Alumnos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,codigo,nombre,apellidos,dui,estado")] alumn alumn)
        {
            if (ModelState.IsValid)
            {
                _context.Add(alumn);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(alumn);
        }

        // GET: Alumnos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var alumn = await _context.alumnos.FindAsync(id);
            if (alumn == null)
            {
                return NotFound();
            }
            return View(alumn);
        }

        // POST: Alumnos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,codigo,nombre,apellidos,dui,estado")] alumn alumn)
        {
            if (id != alumn.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(alumn);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!alumnExists(alumn.id))
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
            return View(alumn);
        }

        // GET: Alumnos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var alumn = await _context.alumnos
                .FirstOrDefaultAsync(m => m.id == id);
            if (alumn == null)
            {
                return NotFound();
            }

            return View(alumn);
        }

        // POST: Alumnos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var alumn = await _context.alumnos.FindAsync(id);
            if (alumn != null)
            {
                _context.alumnos.Remove(alumn);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool alumnExists(int id)
        {
            return _context.alumnos.Any(e => e.id == id);
        }
    }
}
