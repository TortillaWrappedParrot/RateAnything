using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RateEverything.Data;
using RateEverything.Models;

namespace RateEverything.Controllers
{
    [Authorize]
    public class ItemCommentsController : Controller
    {
        private readonly RateEverythingContext _context;

        public ItemCommentsController(RateEverythingContext context)
        {
            _context = context;
        }

        // GET: ItemComments
        public async Task<IActionResult> Index(int? id)
        {

            if (id != null)
            {
                return _context.ItemComments != null ?
                      View(await _context.ItemComments.Where(x => x.ItemIdComment == id).ToListAsync()) :
                      Problem("Entity set 'RateEverythingContext.ItemComments'  is null.");
            } else
            {
                return _context.ItemComments != null ?
                      View(await _context.ItemComments.ToListAsync()) :
                      Problem("Entity set 'RateEverythingContext.ItemComments'  is null.");
            }
        }

        // GET: ItemComments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ItemComments == null)
            {
                return NotFound();
            }

            var itemComment = await _context.ItemComments
                .FirstOrDefaultAsync(m => m.InternalId == id);
            if (itemComment == null)
            {
                return NotFound();
            }

            return View(itemComment);
        }

        // GET: ItemComments/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ItemComments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Create([Bind("InternalId,ItemIdComment,UserId,Comment")] ItemComment itemComment)
        {
            if (ModelState.IsValid)
            {
                _context.Add(itemComment);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(itemComment);
        }

        // GET: ItemComments/Edit/5
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ItemComments == null)
            {
                return NotFound();
            }

            var itemComment = await _context.ItemComments.FindAsync(id);
            if (itemComment == null)
            {
                return NotFound();
            }
            return View(itemComment);
        }

        // POST: ItemComments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Edit(int id, [Bind("InternalId,ItemIdComment,UserId,Comment")] ItemComment itemComment)
        {
            if (id != itemComment.InternalId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(itemComment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ItemCommentExists(itemComment.InternalId))
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
            return View(itemComment);
        }

        // GET: ItemComments/Delete/5
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ItemComments == null)
            {
                return NotFound();
            }

            var itemComment = await _context.ItemComments
                .FirstOrDefaultAsync(m => m.InternalId == id);
            if (itemComment == null)
            {
                return NotFound();
            }

            return View(itemComment);
        }

        // POST: ItemComments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ItemComments == null)
            {
                return Problem("Entity set 'RateEverythingContext.ItemComments'  is null.");
            }
            var itemComment = await _context.ItemComments.FindAsync(id);
            if (itemComment != null)
            {
                _context.ItemComments.Remove(itemComment);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ItemCommentExists(int id)
        {
          return (_context.ItemComments?.Any(e => e.InternalId == id)).GetValueOrDefault();
        }
    }
}
