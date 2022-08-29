using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication23.Models;

namespace WebApplication23.Controllers
{
    
    public class ResturantsController : Controller
    {
        private readonly resturantDBContext _context;

        public ResturantsController(resturantDBContext context)
        {
            _context = context;
        }
        public string abc()
        {
            return "abc";
        }

        // GET: Resturants
        public async Task<IActionResult> Index()
        {
            return View(await _context.Resturant.ToListAsync());
        }

        // GET: Resturants/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var resturant = await _context.Resturant
                .FirstOrDefaultAsync(m => m.ResturantId == id);
            if (resturant == null)
            {
                return NotFound();
            }

            return View(resturant);
        }

        // GET: Resturants/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Resturants/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ResturantId,ResturantName")] Resturant resturant)
        {
            if (ModelState.IsValid)
            {
                _context.Add(resturant);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(resturant);
        }

        // GET: Resturants/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var resturant = await _context.Resturant.FindAsync(id);
            if (resturant == null)
            {
                return NotFound();
            }
            return View(resturant);
        }

        // POST: Resturants/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ResturantId,ResturantName")] Resturant resturant)
        {
            if (id != resturant.ResturantId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(resturant);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ResturantExists(resturant.ResturantId))
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
            return View(resturant);
        }

        // GET: Resturants/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var resturant = await _context.Resturant
                .FirstOrDefaultAsync(m => m.ResturantId == id);
            if (resturant == null)
            {
                return NotFound();
            }

            return View(resturant);
        }

        // POST: Resturants/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var resturant = await _context.Resturant.FindAsync(id);
            _context.Resturant.Remove(resturant);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ResturantExists(int id)
        {
            return _context.Resturant.Any(e => e.ResturantId == id);
        }
    }
}
