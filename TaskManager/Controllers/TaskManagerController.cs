using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TaskManager.Data;
using TaskManager.Models;

namespace Controllers
{
    public class TaskManagerController : Controller
    {
        private readonly TaskManagerContext _context;

        public TaskManagerController(TaskManagerContext context)
        {
            _context = context;
        }

        // GET: TaskManager
        public async Task<IActionResult> Index()
        {
            return View(await _context.Tasks.ToListAsync());
        }

        // GET: TaskManager/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var taskItems = await _context.Tasks
                .FirstOrDefaultAsync(m => m.Id == id);
            if (taskItems == null)
            {
                return NotFound();
            }

            return View(taskItems);
        }

        // GET: TaskManager/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TaskManager/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description,DueDate,Priority,IsCompleted")] TaskItems taskItems)
        {
            if (ModelState.IsValid)
            {
                _context.Add(taskItems);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(taskItems);
        }

        // GET: TaskManager/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var taskItems = await _context.Tasks.FindAsync(id);
            if (taskItems == null)
            {
                return NotFound();
            }
            return View(taskItems);
        }

        // POST: TaskManager/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,DueDate,Priority,IsCompleted")] TaskItems taskItems)
        {
            if (id != taskItems.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(taskItems);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TaskItemsExists(taskItems.Id))
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
            return View(taskItems);
        }

        // GET: TaskManager/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var taskItems = await _context.Tasks
                .FirstOrDefaultAsync(m => m.Id == id);
            if (taskItems == null)
            {
                return NotFound();
            }

            return View(taskItems);
        }

        // POST: TaskManager/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var taskItems = await _context.Tasks.FindAsync(id);
            if (taskItems != null)
            {
                _context.Tasks.Remove(taskItems);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TaskItemsExists(int id)
        {
            return _context.Tasks.Any(e => e.Id == id);
        }
    }
}
