using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using JM_Ejercicio_2_Tablas.Data;
using JM_Ejercicio_2_Tablas.Models;

namespace JM_Ejercicio_2_Tablas.Controllers
{
    public class PromoesController : Controller
    {
        private readonly JM_Ejercicio_2_TablasContext _context;

        public PromoesController(JM_Ejercicio_2_TablasContext context)
        {
            _context = context;
        }

        // GET: Promoes
        public async Task<IActionResult> Index()
        {
            var jM_Ejercicio_2_TablasContext = _context.Promo.Include(p => p.Burger);
            return View(await jM_Ejercicio_2_TablasContext.ToListAsync());
        }

        // GET: Promoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Promo == null)
            {
                return NotFound();
            }

            var promo = await _context.Promo
                .Include(p => p.Burger)
                .FirstOrDefaultAsync(m => m.PromoId == id);
            if (promo == null)
            {
                return NotFound();
            }

            return View(promo);
        }

        // GET: Promoes/Create
        public IActionResult Create()
        {
            ViewData["BurgerName"] = new SelectList(_context.Burger, "Name", "Name");
            return View();
        }

        // POST: Promoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PromoID,Descripcion,Fecha,BurgerName")] Promo promo)
        {
            if (ModelState.IsValid)
            {
                var burger = _context.Burger.FirstOrDefault(b => b.Name == promo.BurgerName);
                if (burger != null)
                {
                    promo.BurgerId = burger.BurgerID;
                    _context.Add(promo);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                ModelState.AddModelError("BurgerName", "Invalid Burger Name");
            }
            ViewData["BurgerName"] = new SelectList(_context.Burger, "Name", "Name", promo.BurgerName);
            return View(promo);
        }

        // GET: Promoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Promo == null)
            {
                return NotFound();
            }

            var promo = await _context.Promo.FindAsync(id);
            if (promo == null)
            {
                return NotFound();
            }
            ViewData["BurgerId"] = new SelectList(_context.Burger, "BurgerID", "BurgerID", promo.BurgerId);
            return View(promo);
        }

        // POST: Promoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PromoId,Descripcion,Fecha,BurgerId")] Promo promo)
        {
            if (id != promo.PromoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(promo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PromoExists(promo.PromoId))
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
            ViewData["BurgerId"] = new SelectList(_context.Burger, "BurgerID", "BurgerID", promo.BurgerId);
            return View(promo);
        }

        // GET: Promoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Promo == null)
            {
                return NotFound();
            }

            var promo = await _context.Promo
                .Include(p => p.Burger)
                .FirstOrDefaultAsync(m => m.PromoId == id);
            if (promo == null)
            {
                return NotFound();
            }

            return View(promo);
        }

        // POST: Promoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Promo == null)
            {
                return Problem("Entity set 'JM_Ejercicio_2_TablasContext.Promo'  is null.");
            }
            var promo = await _context.Promo.FindAsync(id);
            if (promo != null)
            {
                _context.Promo.Remove(promo);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PromoExists(int id)
        {
          return (_context.Promo?.Any(e => e.PromoId == id)).GetValueOrDefault();
        }
    }
}
