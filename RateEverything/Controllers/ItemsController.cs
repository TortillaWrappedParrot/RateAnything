using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using RateEverything.Areas.Identity.Data;
using RateEverything.Data;
using RateEverything.Models;

namespace RateEverything.Controllers
{
    [Authorize]
    public class ItemsController : Controller
    {
        private readonly RateEverythingContext _context;
        private UserManager<RateEverythingUser> _userManager;

        public ItemsController(RateEverythingContext context, UserManager<RateEverythingUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Items
        public async Task<IActionResult> Index()
        {
            return _context.Items != null ? 
                        View(await _context.Items.ToListAsync()) :
                        Problem("Entity set 'RateEverythingContext.Items'  is null.");
        }

        // GET: Items/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Items == null)
            {
                return NotFound();
            }

            var item = await _context.Items
                .FirstOrDefaultAsync(m => m.ItemId == id);
            if (item == null)
            {
                return NotFound();
            }

            List<ItemRating> ratings = await _context.ItemRatings.Where(x => x.ItemIdRating == item.ItemId).ToListAsync();
            CombinedItem details = new(item, ratings);

            return View(details);
        }

        /// <summary>
        /// Given a rating and ID create a new rating or update the user's rating
        /// </summary>
        /// <param name="rating"></param>
        /// <param name="ID"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Details(int rating, int ID)
        {
            string returnMessage = "No user!"; //The return message sent back to the js

            if (User != null) //Check if there is a user logged in
            {
                string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                returnMessage = "No data!"; //There's a user but no data made yet

                if (!_context.ItemRatings.Where(x => x.UserId == userId).IsNullOrEmpty()) //Check if the user already posted a review
                {
                    //If true then create a new rating
                    ItemRating currentRating = _context.ItemRatings.Where(x => x.UserId == userId).First();

                    currentRating.Rating = rating;
                    _context.ItemRatings.Update(currentRating);
                    returnMessage = "Created a new rating!"; //Change message to indicate created rating
                } else
                {
                    //If false then update old rating
                    ItemRating newRating = new(ID, User.FindFirstValue(ClaimTypes.NameIdentifier), rating);
                    _context.ItemRatings.Add(newRating);
                    returnMessage = "Updated previous rating!"; //Change message to indicate updated rating
                }

                Item targetItem = _context.Items.First(x => x.ItemId == ID);

                int Sum = 0;
                int Amount = 0;

                foreach (ItemRating Rating in await _context.ItemRatings.Where(x => x.ItemIdRating == targetItem.ItemId).ToListAsync()) //Update rating for item
                {
                    Sum += Rating.Rating;
                    Amount += 1;
                }

                //No items found so default to 1 to prevent division error
                if (Amount <= 0)
                {
                    Amount = 1;
                }

                targetItem.Rating = Sum / Amount;
                _context.Items.Update(targetItem);

                await _context.SaveChangesAsync(); //Save any changes
                return Json(returnMessage);
            }
            return Json(returnMessage);
        }

        // GET: Items/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Items/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ItemId,Name,Description")] Item item)
        {
            if (ModelState.IsValid)
            {
                _context.Add(item);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(item);
        }

        // GET: Items/Edit/5
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Items == null)
            {
                return NotFound();
            }

            var item = await _context.Items.FindAsync(id);
            if (item == null)
            {
                return NotFound();
            }
            return View(item);
        }

        // POST: Items/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Edit(int id, [Bind("ItemId,Name,Description,Rating")] Item item)
        {
            if (id != item.ItemId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(item);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ItemExists(item.ItemId))
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
            return View(item);
        }

        // GET: Items/Delete/5
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Items == null)
            {
                return NotFound();
            }

            var item = await _context.Items
                .FirstOrDefaultAsync(m => m.ItemId == id);
            if (item == null)
            {
                return NotFound();
            }

            return View(item);
        }

        // POST: Items/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Items == null)
            {
                return Problem("Entity set 'RateEverythingContext.Items'  is null.");
            }
            var item = await _context.Items.FindAsync(id);
            if (item != null)
            {
                _context.Items.Remove(item);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ItemExists(int id)
        {
          return (_context.Items?.Any(e => e.ItemId == id)).GetValueOrDefault();
        }
    }
}
