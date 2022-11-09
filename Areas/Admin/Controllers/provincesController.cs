using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OnlineShoppingCart.Models;

namespace OnlineShoppingCart.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class provincesController : Controller
    {
        private readonly OnlineShoppingCartContext _context;

        public provincesController(OnlineShoppingCartContext context)
        {
            _context = context;
        }

        // GET: Admin/provinces
        public async Task<IActionResult> Index()
        {
            var onlineShoppingCartContext = _context.provinces.Include(p => p.administrative_region_).Include(p => p.administrative_unit_);
            return View(await onlineShoppingCartContext.ToListAsync());
        }

        // GET: Admin/provinces/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var provinces = await _context.provinces
                .Include(p => p.administrative_region_)
                .Include(p => p.administrative_unit_)
                .FirstOrDefaultAsync(m => m.code == id);
            if (provinces == null)
            {
                return NotFound();
            }

            return View(provinces);
        }

        // GET: Admin/provinces/Create
        public IActionResult Create()
        {
            ViewData["administrative_region_id"] = new SelectList(_context.administrative_regions, "id", "name");
            ViewData["administrative_unit_id"] = new SelectList(_context.administrative_units, "id", "id");
            return View();
        }

        // POST: Admin/provinces/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("code,name,name_en,full_name,full_name_en,code_name,administrative_unit_id,administrative_region_id")] provinces provinces)
        {
            if (ModelState.IsValid)
            {
                _context.Add(provinces);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["administrative_region_id"] = new SelectList(_context.administrative_regions, "id", "name", provinces.administrative_region_id);
            ViewData["administrative_unit_id"] = new SelectList(_context.administrative_units, "id", "id", provinces.administrative_unit_id);
            return View(provinces);
        }

        // GET: Admin/provinces/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var provinces = await _context.provinces.FindAsync(id);
            if (provinces == null)
            {
                return NotFound();
            }
            ViewData["administrative_region_id"] = new SelectList(_context.administrative_regions, "id", "name", provinces.administrative_region_id);
            ViewData["administrative_unit_id"] = new SelectList(_context.administrative_units, "id", "id", provinces.administrative_unit_id);
            return View(provinces);
        }

        // POST: Admin/provinces/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("code,name,name_en,full_name,full_name_en,code_name,administrative_unit_id,administrative_region_id")] provinces provinces)
        {
            if (id != provinces.code)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(provinces);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!provincesExists(provinces.code))
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
            ViewData["administrative_region_id"] = new SelectList(_context.administrative_regions, "id", "name", provinces.administrative_region_id);
            ViewData["administrative_unit_id"] = new SelectList(_context.administrative_units, "id", "id", provinces.administrative_unit_id);
            return View(provinces);
        }

        // GET: Admin/provinces/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var provinces = await _context.provinces
                .Include(p => p.administrative_region_)
                .Include(p => p.administrative_unit_)
                .FirstOrDefaultAsync(m => m.code == id);
            if (provinces == null)
            {
                return NotFound();
            }

            return View(provinces);
        }

        // POST: Admin/provinces/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var provinces = await _context.provinces.FindAsync(id);
            _context.provinces.Remove(provinces);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool provincesExists(string id)
        {
            return _context.provinces.Any(e => e.code == id);
        }
    }
}
