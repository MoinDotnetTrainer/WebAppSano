using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebAppSano.Models;

namespace WebAppSano.Controllers
{
    public class ProductsModelsController : Controller
    {
        private  AppDb _context;

        public ProductsModelsController()
        {
            _context = new AppDb();
        }

        // GET: ProductsModels

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View(await _context.tblproducts.ToListAsync());
        }

        // GET: ProductsModels/Details/5

        [HttpGet]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productsModel = await _context.tblproducts
                .FirstOrDefaultAsync(m => m.ID == id);
            if (productsModel == null)
            {
                return NotFound();
            }

            return View(productsModel);
        }

        // GET: ProductsModels/Create

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name,Qty,EpiryDate")] ProductsModel productsModel)
        {
            if (ModelState.IsValid) // F
            {
                await _context.AddAsync(productsModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(productsModel);
        }

        // GET: ProductsModels/Edit/5
        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productsModel = await _context.tblproducts.FindAsync(id);
            if (productsModel == null)
            {
                return NotFound();
            }
            return View(productsModel);
        }

        // POST: ProductsModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name,Qty,EpiryDate")] ProductsModel productsModel)
        {
            if (id != productsModel.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(productsModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductsModelExists(productsModel.ID))
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
            return View(productsModel);
        }

        // GET: ProductsModels/Delete/5
        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productsModel = await _context.tblproducts
                .FirstOrDefaultAsync(m => m.ID == id);
            if (productsModel == null)
            {
                return NotFound();
            }

            return View(productsModel);
        }

        // POST: ProductsModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var productsModel = await _context.tblproducts.FindAsync(id);
            if (productsModel != null)
            {
                _context.tblproducts.Remove(productsModel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductsModelExists(int id)
        {
            return _context.tblproducts.Any(e => e.ID == id);
        }
    }
}
