using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Estapar.Context;
using Estapar.Models;
using Estapar.Repository;

namespace Estapar.Controllers
{
    public class ManobrasController : Controller
    {
        private const string V = "Recepção de Veiculo";
        private readonly DatabaseContext _context;

        public ManobrasController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: Manobras
        public async Task<IActionResult> Index()
        {
            var databaseContext = _context.Manobras.Include(m => m.Carro).Include(m => m.Manobrista);
            return View(await databaseContext.ToListAsync());
        }

        // GET: Manobras/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var manobra = await _context.Manobras
                .Include(m => m.Carro)
                .Include(m => m.Manobrista)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (manobra == null)
            {
                return NotFound();
            }

            return View(manobra);
        }

        // GET: Manobras/Create
        public IActionResult Create()
        {
            ViewData["CarroId"] = new SelectList(_context.Carros, "Id", "nom_modelo");
            ViewData["ManobristaId"] = new SelectList(_context.Manobristas, "Id", "nom_manobrista");
            return View();
        }

        // POST: Manobras/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ManobristaId,CarroId,dat_manobra,tip_manobra")] Manobra manobra)
        {
            if (ModelState.IsValid)
            {
                _context.Add(manobra);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CarroId"] = new SelectList(_context.Carros, "Id", "nom_modelo", manobra.CarroId);
            ViewData["ManobristaId"] = new SelectList(_context.Manobristas, "Id", "nom_manobrista", manobra.ManobristaId);

            return View(manobra);
        }

        // GET: Manobras/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var manobra = await _context.Manobras.FindAsync(id);
            if (manobra == null)
            {
                return NotFound();
            }
            ViewData["CarroId"] = new SelectList(_context.Carros, "Id", "nom_modelo", manobra.CarroId);
            ViewData["ManobristaId"] = new SelectList(_context.Manobristas, "Id", "nom_manobrista", manobra.ManobristaId);
            return View(manobra);
        }

        // POST: Manobras/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ManobristaId,CarroId,dat_manobra,tip_manobra")] Manobra manobra)
        {
            if (id != manobra.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(manobra);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ManobraExists(manobra.Id))
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
            ViewData["CarroId"] = new SelectList(_context.Carros, "Id", "nom_modelo", manobra.CarroId);
            ViewData["ManobristaId"] = new SelectList(_context.Manobristas, "Id", "nom_manobrista", manobra.ManobristaId);
            return View(manobra);
        }

        // GET: Manobras/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var manobra = await _context.Manobras
                .Include(m => m.Carro)
                .Include(m => m.Manobrista)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (manobra == null)
            {
                return NotFound();
            }

            return View(manobra);
        }

        // POST: Manobras/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var manobra = await _context.Manobras.FindAsync(id);
            _context.Manobras.Remove(manobra);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ManobraExists(int id)
        {
            return _context.Manobras.Any(e => e.Id == id);
        }
    }
}
