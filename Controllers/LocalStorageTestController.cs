using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LocalStorage.Data;
using LocalStorage.Models;
using Microsoft.AspNetCore.Authorization;

namespace LocalStorage.Controllers
{
    public class LocalStorageTestController : Controller
    {
        private readonly ApplicationDbContext _context;

        public LocalStorageTestController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: LocalStorageTest
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.TestForm.Include(t => t.User);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: LocalStorageTest/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var testFormModel = await _context.TestForm
                .Include(t => t.User)
                .FirstOrDefaultAsync(m => m.Int == id);
            if (testFormModel == null)
            {
                return NotFound();
            }

            return View(testFormModel);
        }

        // GET: LocalStorageTest/Create
        public IActionResult Create()
        {
            ViewBag.FormCacheKey = "0123456789";

            ViewData["CreatedBy"] = new SelectList(_context.Users, "Id", "Id");
            return View();
        }

        public IActionResult Age()
        {
            ViewData["CreatedBy"] = new SelectList(_context.Users, "Id", "Id");
            return View();
        }


        // POST: LocalStorageTest/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Int,FirstName,MiddleName,LastName,Phone,Address,FatherFirstName,FatherMiddleName,FatherLastName,MotherFirstName,MotherMiddleName,MotherLastName,BirthPlace,FatherBirthPlace,MotherBirthPlace,FatherPhone,MotherPhone,SpouseFirstName,SposeMiddleName,SpouseLastName,SpusePhone,WorkPlace,WorkPlaceAddress,BirthDate,FatherBirthDate,MotherBirthDate,SpouseBirthDate,SpouseBirthPlace,CreatedBy")] TestFormModel testFormModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(testFormModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CreatedBy"] = new SelectList(_context.Users, "Id", "Id", testFormModel.CreatedBy);
            return View(testFormModel);
        }

        // GET: LocalStorageTest/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var testFormModel = await _context.TestForm.FindAsync(id);
            if (testFormModel == null)
            {
                return NotFound();
            }
            ViewData["CreatedBy"] = new SelectList(_context.Users, "Id", "Id", testFormModel.CreatedBy);
            return View(testFormModel);
        }

        // POST: LocalStorageTest/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Int,FirstName,MiddleName,LastName,Phone,Address,FatherFirstName,FatherMiddleName,FatherLastName,MotherFirstName,MotherMiddleName,MotherLastName,BirthPlace,FatherBirthPlace,MotherBirthPlace,FatherPhone,MotherPhone,SpouseFirstName,SposeMiddleName,SpouseLastName,SpusePhone,WorkPlace,WorkPlaceAddress,BirthDate,FatherBirthDate,MotherBirthDate,SpouseBirthDate,SpouseBirthPlace,CreatedBy")] TestFormModel testFormModel)
        {
            if (id != testFormModel.Int)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(testFormModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TestFormModelExists(testFormModel.Int))
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
            ViewData["CreatedBy"] = new SelectList(_context.Users, "Id", "Id", testFormModel.CreatedBy);
            return View(testFormModel);
        }

        // GET: LocalStorageTest/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var testFormModel = await _context.TestForm
                .Include(t => t.User)
                .FirstOrDefaultAsync(m => m.Int == id);
            if (testFormModel == null)
            {
                return NotFound();
            }

            return View(testFormModel);
        }

        // POST: LocalStorageTest/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var testFormModel = await _context.TestForm.FindAsync(id);
            _context.TestForm.Remove(testFormModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TestFormModelExists(int id)
        {
            return _context.TestForm.Any(e => e.Int == id);
        }
    }
}
