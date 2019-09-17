using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Memes.Data;
using Memes.Models;
using Microsoft.AspNetCore.Authorization;

namespace Memes.Controllers
{
    [Authorize]
    public class MemesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MemesController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: Memes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Meme.ToListAsync());
        }

        // GET: Memes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var meme = await _context.Meme.SingleOrDefaultAsync(m => m.ID == id);
            if (meme == null)
            {
                return NotFound();
            }

            return View(meme);
        }

        // GET: Memes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Memes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Description,Link,Title,User,Type")] Meme meme)
        {
            if (ModelState.IsValid)
            {
                _context.Add(meme);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(meme);
        }

        // GET: Memes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var meme = await _context.Meme.SingleOrDefaultAsync(m => m.ID == id);
            if (meme == null)
            {
                return NotFound();
            }
            return View(meme);
        }

        // POST: Memes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Description,Link,Title,User, Type")] Meme meme)
        {
            if (id != meme.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(meme);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MemeExists(meme.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            return View(meme);
        }

        // GET: Memes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var meme = await _context.Meme.SingleOrDefaultAsync(m => m.ID == id);
            if (meme == null)
            {
                return NotFound();
            }

            return View(meme);
        }

        // POST: Memes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var meme = await _context.Meme.SingleOrDefaultAsync(m => m.ID == id);
            _context.Meme.Remove(meme);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool MemeExists(int id)
        {
            return _context.Meme.Any(e => e.ID == id);
        }
    }
}
