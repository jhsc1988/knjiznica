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
    public class RezervacijeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RezervacijeController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Rezervacije
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Rezervacija.Include(r => r.Knjiga).Include(r => r.User);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Rezervacije/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rezervacija = await _context.Rezervacija
                .Include(r => r.Knjiga)
                .Include(r => r.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (rezervacija == null)
            {
                return NotFound();
            }

            return View(rezervacija);
        }

        // GET: Rezervacije/Create
        public IActionResult Create()
        {
            ViewData["KnjigaId"] = new SelectList(_context.Knjiga, "Id", "Naslov");
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Email");
            return View();
        }

        // POST: Rezervacije/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,KnjigaId,datumRezervacija,UserId")] Rezervacija rezervacija)
        {
            if (ModelState.IsValid)
            {
                _context.Add(rezervacija);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["KnjigaId"] = new SelectList(_context.Knjiga, "Id", "Autor", rezervacija.KnjigaId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", rezervacija.UserId);
            return View(rezervacija);
        }

        // GET: Rezervacije/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rezervacija = await _context.Rezervacija.FindAsync(id);
            if (rezervacija == null)
            {
                return NotFound();
            }
            ViewData["KnjigaId"] = new SelectList(_context.Knjiga, "Id", "Autor", rezervacija.KnjigaId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", rezervacija.UserId);
            return View(rezervacija);
        }

        // POST: Rezervacije/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,KnjigaId,datumRezervacija,UserId")] Rezervacija rezervacija)
        {
            if (id != rezervacija.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(rezervacija);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RezervacijaExists(rezervacija.Id))
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
            ViewData["KnjigaId"] = new SelectList(_context.Knjiga, "Id", "Autor", rezervacija.KnjigaId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", rezervacija.UserId);
            return View(rezervacija);
        }

        // GET: Rezervacije/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rezervacija = await _context.Rezervacija
                .Include(r => r.Knjiga)
                .Include(r => r.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (rezervacija == null)
            {
                return NotFound();
            }

            return View(rezervacija);
        }

        // POST: Rezervacije/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var rezervacija = await _context.Rezervacija.FindAsync(id);
            _context.Rezervacija.Remove(rezervacija);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RezervacijaExists(int id)
        {
            return _context.Rezervacija.Any(e => e.Id == id);
        }
    }
}
