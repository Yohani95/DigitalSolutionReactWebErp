using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ErpApi.Data;
using ErpApi.Models.User;

namespace ErpApi.Views
{
    public class test : Controller
    {
        private readonly ErpApiContext _context;

        public test(ErpApiContext context)
        {
            _context = context;
        }

        // GET: test
        public async Task<IActionResult> Index()
        {
              return View(await _context.roles.ToListAsync());
        }

        // GET: test/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.roles == null)
            {
                return NotFound();
            }

            var rolesModels = await _context.roles
                .FirstOrDefaultAsync(m => m.id_rol == id);
            if (rolesModels == null)
            {
                return NotFound();
            }

            return View(rolesModels);
        }

        // GET: test/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: test/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id_rol,nombre_rol")] RolesModels rolesModels)
        {
            if (ModelState.IsValid)
            {
                _context.Add(rolesModels);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(rolesModels);
        }

        // GET: test/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.roles == null)
            {
                return NotFound();
            }

            var rolesModels = await _context.roles.FindAsync(id);
            if (rolesModels == null)
            {
                return NotFound();
            }
            return View(rolesModels);
        }

        // POST: test/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id_rol,nombre_rol")] RolesModels rolesModels)
        {
            if (id != rolesModels.id_rol)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(rolesModels);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RolesModelsExists(rolesModels.id_rol))
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
            return View(rolesModels);
        }

        // GET: test/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.roles == null)
            {
                return NotFound();
            }

            var rolesModels = await _context.roles
                .FirstOrDefaultAsync(m => m.id_rol == id);
            if (rolesModels == null)
            {
                return NotFound();
            }

            return View(rolesModels);
        }

        // POST: test/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.roles == null)
            {
                return Problem("Entity set 'ErpApiContext.roles'  is null.");
            }
            var rolesModels = await _context.roles.FindAsync(id);
            if (rolesModels != null)
            {
                _context.roles.Remove(rolesModels);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RolesModelsExists(int id)
        {
          return _context.roles.Any(e => e.id_rol == id);
        }
    }
}
