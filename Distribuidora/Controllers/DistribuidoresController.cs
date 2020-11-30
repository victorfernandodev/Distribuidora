using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Distribuidora.Data;
using Distribuidora.Models;

namespace Distribuidora.Controllers
{
    public class DistribuidoresController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DistribuidoresController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Distribuidores
        public async Task<IActionResult> Index(string searchString)
        {
            var distribuidor = from m in _context.Distribuidor
                         select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                distribuidor = distribuidor.Where(s => s.NomeDistribuidor.Contains(searchString));
            }

            return View(await distribuidor.ToListAsync());
        }

        // GET: Distribuidores/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var distribuidor = await _context.Distribuidor
                .FirstOrDefaultAsync(m => m.Id == id);
            if (distribuidor == null)
            {
                return NotFound();
            }

            return View(distribuidor);
        }

        // GET: Distribuidores/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Distribuidores/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,NomeDistribuidor,CNPJ,CEP,Endereco,Numero,Complemento")] Distribuidor distribuidor)
        {
            if (ModelState.IsValid)
            {
                _context.Add(distribuidor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(distribuidor);
        }

        // GET: Distribuidores/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var distribuidor = await _context.Distribuidor.FindAsync(id);
            if (distribuidor == null)
            {
                return NotFound();
            }
            return View(distribuidor);
        }

        // POST: Distribuidores/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,NomeDistribuidor,CNPJ,CEP,Endereco,Numero,Complemento")] Distribuidor distribuidor)
        {
            if (id != distribuidor.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(distribuidor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DistribuidorExists(distribuidor.Id))
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
            return View(distribuidor);
        }

        // GET: Distribuidores/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var distribuidor = await _context.Distribuidor
                .FirstOrDefaultAsync(m => m.Id == id);
            if (distribuidor == null)
            {
                return NotFound();
            }

            return View(distribuidor);
        }

        // POST: Distribuidores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var distribuidor = await _context.Distribuidor.FindAsync(id);
            _context.Distribuidor.Remove(distribuidor);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DistribuidorExists(int id)
        {
            return _context.Distribuidor.Any(e => e.Id == id);
        }
    }
}
