using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Sapataria_de_Sapatos.Models;

namespace Sapataria_de_Sapatos.Controllers
{
    public class vendasController : Controller
    {
        private readonly contexto _context;

        public vendasController(contexto context)
        {
            _context = context;
        }

        // GET: vendas
        public async Task<IActionResult> Index()
        {
              return _context.Vendas != null ? 
                          View(await _context.Vendas.ToListAsync()) :
                          Problem("Entity set 'contexto.Vendas'  is null.");
        }

        // GET: vendas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Vendas == null)
            {
                return NotFound();
            }

            var venda = await _context.Vendas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (venda == null)
            {
                return NotFound();
            }

            return View(venda);
        }

        // GET: vendas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: vendas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id")] venda venda)
        {
            if (ModelState.IsValid)
            {
                _context.Add(venda);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(venda);
        }

        // GET: vendas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Vendas == null)
            {
                return NotFound();
            }

            var venda = await _context.Vendas.FindAsync(id);
            if (venda == null)
            {
                return NotFound();
            }
            return View(venda);
        }

        // POST: vendas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id")] venda venda)
        {
            if (id != venda.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(venda);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!vendaExists(venda.Id))
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
            return View(venda);
        }

        // GET: vendas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Vendas == null)
            {
                return NotFound();
            }

            var venda = await _context.Vendas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (venda == null)
            {
                return NotFound();
            }

            return View(venda);
        }

        // POST: vendas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Vendas == null)
            {
                return Problem("Entity set 'contexto.Vendas'  is null.");
            }
            var venda = await _context.Vendas.FindAsync(id);
            if (venda != null)
            {
                _context.Vendas.Remove(venda);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool vendaExists(int id)
        {
          return (_context.Vendas?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
