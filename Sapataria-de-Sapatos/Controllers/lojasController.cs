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
    public class lojasController : Controller
    {
        private readonly contexto _context;

        public lojasController(contexto context)
        {
            _context = context;
        }

        // GET: lojas
        public async Task<IActionResult> Index()
        {
              return _context.Lojas != null ? 
                          View(await _context.Lojas.ToListAsync()) :
                          Problem("Entity set 'contexto.Lojas'  is null.");
        }

        // GET: lojas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Lojas == null)
            {
                return NotFound();
            }

            var loja = await _context.Lojas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (loja == null)
            {
                return NotFound();
            }

            return View(loja);
        }

        // GET: lojas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: lojas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Cidade,Estado")] loja loja)
        {
            if (ModelState.IsValid)
            {
                _context.Add(loja);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(loja);
        }

        // GET: lojas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Lojas == null)
            {
                return NotFound();
            }

            var loja = await _context.Lojas.FindAsync(id);
            if (loja == null)
            {
                return NotFound();
            }
            return View(loja);
        }

        // POST: lojas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Cidade,Estado")] loja loja)
        {
            if (id != loja.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(loja);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!lojaExists(loja.Id))
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
            return View(loja);
        }

        // GET: lojas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Lojas == null)
            {
                return NotFound();
            }

            var loja = await _context.Lojas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (loja == null)
            {
                return NotFound();
            }

            return View(loja);
        }

        // POST: lojas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Lojas == null)
            {
                return Problem("Entity set 'contexto.Lojas'  is null.");
            }
            var loja = await _context.Lojas.FindAsync(id);
            if (loja != null)
            {
                _context.Lojas.Remove(loja);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool lojaExists(int id)
        {
          return (_context.Lojas?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
