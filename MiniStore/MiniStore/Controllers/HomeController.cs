using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MiniStore.Context;
using MiniStore.Models;
using System.Diagnostics;

namespace MiniStore.Controllers
{
    public class HomeController : Controller
    {
        StoreDbContext _context { get; }

        public HomeController(StoreDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var sliders = await _context.Sliders.ToListAsync();
            var cards = await _context.Cards.ToListAsync();
            return View(sliders);
        }
    }
}
