using DOTNET_UI.Data;
using DOTNET_UI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace DOTNET_UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;
        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Home()
        {
            IEnumerable<UsersModel> objectlist = _context.Users;
            return View(objectlist);
        }
        public IActionResult Create()
        {
            return View();
        }
        [Authorize(Roles = "Administrator, User")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(UsersModel userobj)
        {
            if (ModelState.IsValid)
            {
                _context.Users.Add(userobj);
                _context.SaveChanges();
                TempData["ResultOk"] = "Record Added Successfully !";
                return RedirectToAction("Index");
            }
            return View(userobj);
        }
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var userfromdb = _context.Users.Find(id);

            if (userfromdb == null)
            {
                return NotFound();
            }
            return View(userfromdb);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(UsersModel updateobj)
        {
            if (ModelState.IsValid)
            {
                _context.Users.Update(updateobj);
                _context.SaveChanges();
                TempData["ResultOk"] = "Data Updated Successfully !";
                return RedirectToAction("Index");
            }

            return View(updateobj);
        }



        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movie = await _context.Users.FirstOrDefaultAsync(m => m.UserID == id);
            if (movie == null)
            {
                return NotFound();
            }

            return View(movie);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var movie = await _context.Users.FindAsync(id);
            _context.Users.Remove(movie);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

    }
    }