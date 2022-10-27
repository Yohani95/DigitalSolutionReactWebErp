using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ErpApi.Data;
using Models.User;

namespace ErpApi.Controllers.User

{
    public class UserModelsController : Controller
    {
        private readonly ErpApiContext _context;

        public UserModelsController(ErpApiContext context)
        {
            _context = context;
        }

        // GET: UserModels
        public async Task<IActionResult> Index()
        {
              return View(await _context.UserModels.ToListAsync());
        }

        // GET: UserModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.UserModels == null)
            {
                return NotFound();
            }

            var userModels = await _context.UserModels
                .FirstOrDefaultAsync(m => m.Id == id);
            if (userModels == null)
            {
                return NotFound();
            }

            return View(userModels);
        }

        // GET: UserModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: UserModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,rut,Name,LastName,UserName,Email,Password,jobPosition,Foto,Nombrefoto")] UserModels userModels)
        {
            if (ModelState.IsValid)
            {
                _context.Add(userModels);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(userModels);
        }

        // GET: UserModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.UserModels == null)
            {
                return NotFound();
            }

            var userModels = await _context.UserModels.FindAsync(id);
            if (userModels == null)
            {
                return NotFound();
            }
            return View(userModels);
        }

        // POST: UserModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,rut,Name,LastName,UserName,Email,Password,jobPosition,Foto,Nombrefoto")] UserModels userModels)
        {
            if (id != userModels.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(userModels);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserModelsExists(userModels.Id))
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
            return View(userModels);
        }

        // GET: UserModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.UserModels == null)
            {
                return NotFound();
            }

            var userModels = await _context.UserModels
                .FirstOrDefaultAsync(m => m.Id == id);
            if (userModels == null)
            {
                return NotFound();
            }

            return View(userModels);
        }

        // POST: UserModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.UserModels == null)
            {
                return Problem("Entity set 'ErpApiContext.UserModels'  is null.");
            }
            var userModels = await _context.UserModels.FindAsync(id);
            if (userModels != null)
            {
                _context.UserModels.Remove(userModels);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserModelsExists(int id)
        {
          return _context.UserModels.Any(e => e.Id == id);
        }
    }
}
