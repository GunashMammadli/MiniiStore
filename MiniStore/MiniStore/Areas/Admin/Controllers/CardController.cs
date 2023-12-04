using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MiniStore.Context;
using MiniStore.Models;
using MiniStore.ViewModels.CardVM;

namespace MiniStore.Areas.Admin.Controllers
{
    public class CardController : Controller
    {
        StoreDbContext _dbContext { get; }

        public CardController(StoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IActionResult> Index()
        {
            var items = await _dbContext.Cards.Select(c => new CardListItemVM
            {
                Id = c.Id,
                ImageUrl1 = c.ImageUrl1,
                ImageUrl2 = c.ImageUrl2,
                Title = c.Title,
                Price = c.Price
            }).ToListAsync();
            return View(items);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        
        public async Task<IActionResult> Create(CardListItemVM item)
        {
            if (!ModelState.IsValid)
            {
                return View(item);
            }
            Card card = new()
            {
                ImageUrl1 = item.ImageUrl1,
                ImageUrl2 = item.ImageUrl2,
                Title = item.Title,
                Price = item.Price
            };
            await _dbContext.Cards.AddAsync(card);
            await _dbContext.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

        }

        public async Task<IActionResult> Remove(int? id)
        {
            if (id == null && id <= 0) return BadRequest();
            var data = await _dbContext.Cards.FindAsync(id);
            if (id == null) return NotFound();
            _dbContext.Cards.Remove(data);
            await _dbContext.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        
        public async Task<IActionResult> Update(int? id)
        {
            if (id == null || id <= 0) return BadRequest();
            var data = await _dbContext.Cards.FindAsync(id);
            if (data == null) return NotFound();
            return View(new CardUpdateVM
            {
                ImageUrl1 = data.ImageUrl1,
                ImageUrl2 = data.ImageUrl2,
                Title = data.Title,
                Price = data.Price
            });
        }

        [HttpPost]
        public async Task<IActionResult> Update(int? id, CardUpdateVM vm)
        {
            if (id == null || id <= 0) return BadRequest();
            if (!ModelState.IsValid)
            {
                return View(vm);
            }
            var data = await _dbContext.Cards.FindAsync(id);
            if (data == null) return NotFound();
            data.ImageUrl1 = vm.ImageUrl1;
            data.ImageUrl2 = vm.ImageUrl2;
            data.Title = vm.Title;
            data.Price = vm.Price;
            await _dbContext.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

        }

    }
}
