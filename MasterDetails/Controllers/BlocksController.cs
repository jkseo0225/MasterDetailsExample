using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DAL.Models;
using MasterDetails.Data;

namespace MasterDetails.Controllers
{
    public class BlocksController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BlocksController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Blocks
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Blocks.Include(b => b.Project);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Blocks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var block = await _context.Blocks
                .Include(b => b.Project)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (block == null)
            {
                return NotFound();
            }

            return View(block);
        }

        // GET: Blocks/Insert/id
        // the id parameter is passing the projectId to the insert function from regions controller
        public async Task<IActionResult> Insert(int? id)
        {
            Project project = await _context.Projects.Where(p => p.Id == id).FirstAsync();
            if (id is not null && project.Id == id)
            {
                Block block = new Block();
                block.ProjectId = (int)id;
                //ViewData["ProjectId"] = new SelectList(_context.Projects, "Id", "ProjectName");
                return View(block);
            }
            return NotFound();
        }

        // POST: Blocks/Insert
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Insert([Bind("Id,BlockName,TargetSmallGen,TargetSmallSun,TargetBigGen,TargetBigSun,ProductGenSmall,ProductGenBig,ProductSunSmall,ProductSunBig,TargetDate,ProjectId")] Block block)
        {
            if (ModelState.IsValid)
            {
                _context.Add(block);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Details), "Projects", new { id = block.ProjectId});
            }
            //ViewData["ProjectId"] = new SelectList(_context.Projects, "Id", "ProjectName", block.ProjectId);
            return View(block);
        }
       
        // GET: Blocks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var block = await _context.Blocks.FindAsync(id);
            if (block == null)
            {
                return NotFound();
            }
            ViewData["ProjectId"] = new SelectList(_context.Projects, "Id", "ProjectName", block.ProjectId);
            return View(block);
        }

        // POST: Blocks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,BlockName,TargetSmallGen,TargetSmallSun,TargetBigGen,TargetBigSun,ProductGenSmall,ProductGenBig,ProductSunSmall,ProductSunBig,TargetDate,ProjectId")] Block block)
        {
            if (id != block.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(block);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BlockExists(block.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Details), "Projects", new { id = block.ProjectId });
                
            }
            ViewData["ProjectId"] = new SelectList(_context.Projects, "Id", "ProjectName", block.ProjectId);
            return View(block);
        }

        // GET: Blocks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var block = await _context.Blocks
                .Include(b => b.Project)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (block == null)
            {
                return NotFound();
            }

            return View(block);
        }

        // POST: Blocks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var block = await _context.Blocks.FindAsync(id);
            _context.Blocks.Remove(block);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Details), "Projects", new { id = block.ProjectId });            
        }

        private bool BlockExists(int id)
        {
            return _context.Blocks.Any(e => e.Id == id);
        }
    }
}
