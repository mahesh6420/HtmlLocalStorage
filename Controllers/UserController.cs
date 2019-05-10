using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LocalStorage.Data;
using LocalStorage.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace LocalStorage
{
    [Authorize]
    public class UserController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _usermanager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public UserController(ApplicationDbContext context, UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _context = context;
            _usermanager = userManager;
            _signInManager = signInManager;
        }

        // GET: User
        public async Task<IActionResult> Index()
        {
            return View(await _context.UserMaster.ToListAsync());
        }

        // GET: User/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userMasterModel = await _context.UserMaster.Include(m=>m.UserPhoneDetails)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (userMasterModel == null)
            {
                return NotFound();
            }

            return View(userMasterModel);
        }

        // GET: User/Create
        public IActionResult Create()
        {
            ViewBag.LoggedInUserId = _usermanager.GetUserId(HttpContext.User);

            return View();
        }

        // POST: User/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(UserMasterModel userMasterModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(userMasterModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(userMasterModel);
        }

        // GET: User/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userMasterModel = await _context.UserMaster.FindAsync(id);
            if (userMasterModel == null)
            {
                return NotFound();
            }
            return View(userMasterModel);
        }

        // POST: User/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] UserMasterModel userMasterModel)
        {
            if (id != userMasterModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(userMasterModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserMasterModelExists(userMasterModel.Id))
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
            return View(userMasterModel);
        }

        // GET: User/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userMasterModel = await _context.UserMaster
                .FirstOrDefaultAsync(m => m.Id == id);
            if (userMasterModel == null)
            {
                return NotFound();
            }

            return View(userMasterModel);
        }

        // POST: User/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var userMasterModel = await _context.UserMaster.FindAsync(id);
            _context.UserMaster.Remove(userMasterModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserMasterModelExists(int id)
        {
            return _context.UserMaster.Any(e => e.Id == id);
        }
    }
}
