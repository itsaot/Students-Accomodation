using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using WebApplication20.Data;
using WebApplication20.Models;

namespace WebApplication20.Controllers
{
    public class RoomConditionsController : Controller
    {
        private readonly RoomConditionContext _context;
        

        public RoomConditionsController(RoomConditionContext context)
        {
            _context = context;
           
        }
        [Authorize]
        // GET: RoomConditions
        public async Task<IActionResult> Index()
        {
            return View(await _context.RoomCondition.ToListAsync());
        }

        // GET: RoomConditions/Create
        public IActionResult Create()
        {
            return View();
        }
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(RoomCondition roomCondition)
        {
            if (ModelState.IsValid)
            {
               

                _context.Add(roomCondition);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(roomCondition);
        }


        [Authorize]
        // GET: RoomConditions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var roomCondition = await _context.RoomCondition.FindAsync(id);
            if (roomCondition == null)
            {
                return NotFound();
            }
            return View(roomCondition);
        }
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,studyDesk,fridge,mattress,wallSocket,chair,stove,lightSwitches,ImageUrl")] RoomCondition roomCondition)
        {
            if (id != roomCondition.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(roomCondition);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RoomConditionExists(roomCondition.Id))
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
            return View(roomCondition);
        }
        [Authorize]
        // GET: RoomConditions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var roomCondition = await _context.RoomCondition.FirstOrDefaultAsync(m => m.Id == id);
            if (roomCondition == null)
            {
                return NotFound();
            }

            return View(roomCondition);
        }
        [Authorize]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var roomCondition = await _context.RoomCondition.FindAsync(id);
            if (roomCondition != null)
            {
                _context.RoomCondition.Remove(roomCondition);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }

        private bool RoomConditionExists(int id)
        {
            return _context.RoomCondition.Any(e => e.Id == id);
        }
    }
}
