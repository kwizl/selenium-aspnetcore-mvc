using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Selenium.Data;
using Selenium.Models;
using System.Threading.Tasks;

namespace Selenium.Controllers
{
    public class AddressController : Controller
    {
        private readonly ApplicationDbContext _db;

        public AddressController(ApplicationDbContext db)
        {
            _db = db;
        }

        // GET Action Method
        public async Task<IActionResult> Index()
        {
            var Addresses = await _db.Addresses.ToListAsync();
            return View(Addresses);
        }

        ///  GET - CREATE
        public IActionResult Create()
        {
            return View();
        }

        // POST - CREATE
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Address Addresses)
        {
            if (ModelState.IsValid)
            {
                _db.Addresses.Add(Addresses);
                await _db.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            return View(Addresses);
        }

        // GET - VIEW
        public async Task<IActionResult> Details(int? ID)
        {
            if (ID == null)
            {
                return NotFound();
            }

            var Addresses = await _db.Addresses.FindAsync(ID);
            if (Addresses == null)
            {
                return NotFound();
            }
            return View(Addresses);
        }

        // GET - EDIT
        public async Task<IActionResult> Edit(int? ID)
        {
            if (ID == null)
            {
                return NotFound();
            }

            var Addresses = await _db.Addresses.FindAsync(ID);
            if (Addresses == null)
            {
                return NotFound();
            }
            return View(Addresses);
        }

        // POST - EDIT
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Address Addresses)
        {
            if (ModelState.IsValid)
            {
                _db.Update(Addresses);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(Addresses);
        }

        // POST - DELETE
        public async Task<IActionResult> Delete(int? ID)
        {
            if (ID == null)
            {
                return NotFound();
            }

            var Addresses = await _db.Addresses.FindAsync(ID);
            if (Addresses == null)
            {
                return NotFound();
            }
            return View(Addresses);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? ID)
        {
            var Addresses = await _db.Addresses.FindAsync(ID);

            if (Addresses == null)
            {
                return View();
            }
            _db.Addresses.Remove(Addresses);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
