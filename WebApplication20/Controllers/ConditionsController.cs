using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using WebApplication20.Data;
using WebApplication20.Models;

namespace WebApplication20.Controllers
{
    public class ConditionsController : Controller
    {
        private readonly ConditionContext _context;

        public ConditionsController(ConditionContext context)
        {
            _context = context;
        }

        // GET: Conditions
        public async Task<IActionResult> Index()
        {
            return View(await _context.Condition.ToListAsync());
        }

        // GET: Conditions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var condition = await _context.Condition
                .FirstOrDefaultAsync(m => m.Id == id);
            if (condition == null)
            {
                return NotFound();
            }

            return View(condition);
        }

        // GET: Conditions/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Conditions/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,studyDesk,fridge,mattress,wallSocket,chair,stove,lightSwitches,ConditionImage,ImageFile")] Condition condition)
        {
            if (ModelState.IsValid)
            {
                // Check if the image file is provided
                if (condition.ImageFile != null && condition.ImageFile.Length > 0)
                {
                    // Generate a unique file name
                    var fileName = $"{Guid.NewGuid().ToString()}{System.IO.Path.GetExtension(condition.ImageFile.FileName)}";

                    // Set the ConditionImage property with the file name
                    condition.ConditionImage = fileName;

                    // Save the image file to the server
                    var filePath = System.IO.Path.Combine("wwwroot/images", fileName);
                    using (var stream = new System.IO.FileStream(filePath, System.IO.FileMode.Create))
                    {
                        await condition.ImageFile.CopyToAsync(stream);
                    }
                }

                _context.Add(condition);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(condition);
        }

        // GET: Conditions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var condition = await _context.Condition.FindAsync(id);
            if (condition == null)
            {
                return NotFound();
            }
            return View(condition);
        }

        // POST: Conditions/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,studyDesk,fridge,mattress,wallSocket,chair,stove,lightSwitches,ConditionImage,ImageFile")] Condition condition)
        {
            if (id != condition.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (condition.ImageFile != null && condition.ImageFile.Length > 0)
                    {
                        // Generate a unique file name
                        var fileName = $"{Guid.NewGuid().ToString()}{System.IO.Path.GetExtension(condition.ImageFile.FileName)}";

                        // Set the ConditionImage property with the file name
                        condition.ConditionImage = fileName;

                        // Save the image file to the server
                        var filePath = System.IO.Path.Combine("wwwroot/images", fileName);
                        using (var stream = new System.IO.FileStream(filePath, System.IO.FileMode.Create))
                        {
                            await condition.ImageFile.CopyToAsync(stream);
                        }
                    }

                    _context.Update(condition);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ConditionExists(condition.Id))
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
            return View(condition);
        }

        // GET: Conditions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var condition = await _context.Condition
                .FirstOrDefaultAsync(m => m.Id == id);
            if (condition == null)
            {
                return NotFound();
            }

            return View(condition);
        }

        // POST: Conditions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var condition = await _context.Condition.FindAsync(id);
            if (condition != null)
            {
                _context.Condition.Remove(condition);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ConditionExists(int id)
        {
            return _context.Condition.Any(e => e.Id == id);
        }
    }
}
