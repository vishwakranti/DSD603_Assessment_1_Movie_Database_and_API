using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DSD603_Asseessment_1_Movie_Database_and_API.Data;
using DSD603_Asseessment_1_Movie_Database_and_API.Models;

namespace DSD603_Asseessment_1_Movie_Database_and_API.Controllers
{
    public class CastsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CastsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Casts
        public async Task<IActionResult> Index()
        {
              return View(await _context.Cast.Include(x => x.Movie).ToListAsync());
        }

        // GET: Casts/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _context.Cast == null)
            {
                return NotFound();
            }

            var cast = await _context.Cast.Include(x => x.Movie)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cast == null)
            {
                return NotFound();
            }

            return View(cast);
        }

        // GET: Casts/Create
        public IActionResult Create()
        {
            ViewData[index: "Movies"] = new SelectList(items: _context.Movie, dataValueField: "Id", dataTextField: "Title");
            return View();
        }

        // POST: Casts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FirstName,LastName,ScreenName, MovieId")] Cast cast)
        //public async Task<IActionResult> Create(Cast cast)
        {
            //if (ModelState.IsValid)
            //{
            //    _context.Add(cast);
            //    await _context.SaveChangesAsync();
            //    return RedirectToAction(nameof(Index));
            //}
            try
            {
                _context.Add(cast);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch(Exception ex)
            {
                return View(cast);
            }
            
            
        }

        // GET: Casts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Cast == null)
            {
                return NotFound();
            }

            var cast = await _context.Cast.FindAsync(id);
            if (cast == null)
            {
                return NotFound();
            }
            var moviesSelectList = new SelectList(items: _context.Movie, dataValueField: "Id",                                          dataTextField: "Title");

            foreach (var item in moviesSelectList)
            {
                if(item.Value == id.ToString())
                {
                    item.Selected = true;
                    break;
                }
            }

            ViewData[index: "Movies"] = moviesSelectList;
            return View(cast);
        }

        // POST: Casts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,FirstName,LastName,ScreenName")] Cast cast)
        {
            if (id != cast.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cast);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CastExists(cast.Id))
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
            return View(cast);
        }

        // GET: Casts/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _context.Cast == null)
            {
                return NotFound();
            }

            var cast = await _context.Cast
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cast == null)
            {
                return NotFound();
            }

            return View(cast);
        }

        // POST: Casts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Cast == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Cast'  is null.");
            }
            var cast = await _context.Cast.FindAsync(id);
            if (cast != null)
            {
                _context.Cast.Remove(cast);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CastExists(Guid id)
        {
          return _context.Cast.Any(e => e.Id == id);
        }
    }
}
