using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using knjiznica.Data;
using knjiznica.Models;

namespace knjiznica.Controllers
{
    public class PosudbeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PosudbeController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Posudbe
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Posudba.Include(p => p.Knjiga).Include(p => p.User);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Posudbe/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var posudba = await _context.Posudba
                .Include(p => p.Knjiga)
                .Include(p => p.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (posudba == null)
            {
                return NotFound();
            }

            return View(posudba);
        }

        // GET: Posudbe/Create
        public IActionResult Create()
        {
            ViewData["KnjigaId"] = new SelectList(_context.Knjiga, "Id", "Naslov");
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Email");
            return View();
        }

        // POST: Posudbe/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,UserId,KnjigaId,datumPosudbe,datumVraćanja")] Posudba posudba)
        {
            if (ModelState.IsValid)
            {
                _context.Add(posudba);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["KnjigaId"] = new SelectList(_context.Knjiga, "Id", "Naslov", posudba.KnjigaId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Email", posudba.UserId);
            return View(posudba);
        }

        // GET: Posudbe/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var posudba = await _context.Posudba.FindAsync(id);
            if (posudba == null)
            {
                return NotFound();
            }
            ViewData["KnjigaId"] = new SelectList(_context.Knjiga, "Id", "Naslov", posudba.KnjigaId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Email", posudba.UserId);
            return View(posudba);
        }

        // POST: Posudbe/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,UserId,KnjigaId,datumPosudbe,datumVraćanja")] Posudba posudba)
        {
            if (id != posudba.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(posudba);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PosudbaExists(posudba.Id))
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
            ViewData["KnjigaId"] = new SelectList(_context.Knjiga, "Id", "Naslov", posudba.KnjigaId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Email", posudba.UserId);
            return View(posudba);
        }

        // GET: Posudbe/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var posudba = await _context.Posudba
                .Include(p => p.Knjiga)
                .Include(p => p.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (posudba == null)
            {
                return NotFound();
            }

            return View(posudba);
        }

        // POST: Posudbe/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var posudba = await _context.Posudba.FindAsync(id);
            _context.Posudba.Remove(posudba);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PosudbaExists(int id)
        {
            return _context.Posudba.Any(e => e.Id == id);
        }
    }
}
