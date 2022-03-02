using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Selenium.Data;
using Selenium.DTOs;
using Selenium.Models;
using System;
using System.Threading.Tasks;

namespace Selenium.Controllers
{
    public class CurrencyController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;

        public CurrencyController(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        // GET Action Method
        public async Task<IActionResult> Index()
        {
            var currencies = await _db.Currencies.ToListAsync();
            return View(currencies);
        }

        ///  GET - CREATE
        public IActionResult Create()
        {
            return View();
        }

        // POST - CREATE
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CurrencyCreateRequest request)
        {
            if (ModelState.IsValid)
            {
                var req = _mapper.Map<Currency>(request);
                _db.Currencies.Add(req);
                await _db.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            return View(request);
        }

        // GET - VIEW
        public async Task<IActionResult> Details(int? ID)
        {
            if (ID == null)
            {
                return NotFound();
            }

            var Currencies = await _db.Currencies.SingleOrDefaultAsync(x => x.CurrencyID == ID);
            if (Currencies == null)
            {
                return NotFound();
            }
            return View(Currencies);
        }

        // GET - EDIT
        public async Task<IActionResult> Edit(int? ID)
        {
            if (ID == null)
            {
                return NotFound();
            }

            var currencies = await _db.Currencies.SingleOrDefaultAsync(x => x.CurrencyID == ID);
            if (currencies == null)
            {
                return NotFound();
            }
            return View(currencies);
        }

        // POST - EDIT
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(CurrencyUpdateRequest request)
        {
            var original = await _db.Currencies.SingleOrDefaultAsync(x => x.Symbol == request.Symbol);

            if (original != null)
            {
                _mapper.Map(request, original);
                await _db.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            //if (ModelState.IsValid)
            //{
            //    _db.Update(request);
            //    await _db.SaveChangesAsync();
            //    return RedirectToAction(nameof(Index));
            //}

            return View(_mapper.Map<CurrencyDTO>(original));
        }

        // POST - DELETE
        public async Task<IActionResult> Delete(int? ID)
        {
            if (ID == null)
            {
                return NotFound();
            }

            var currencies = await _db.Currencies.FindAsync(ID);
            if (currencies == null)
            {
                return NotFound();
            }
            return View(currencies);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? ID)
        {
            var currencies = await _db.Currencies.FindAsync(ID);

            if (currencies == null)
            {
                return View();
            }
            _db.Currencies.Remove(currencies);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
