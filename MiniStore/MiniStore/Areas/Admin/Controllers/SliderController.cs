using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MiniStore.Context;
using MiniStore.Models;
using MiniStore.ViewModels.SliderVM;

namespace MiniStore.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SliderController : Controller
    {
        StoreDbContext _db { get; }

        public SliderController(StoreDbContext db)
        {
            _db = db;
        }

        public async Task<IActionResult> Index()
        {
            var items = await _db.Sliders.Select(s => new SliderListItemVM
            {
                Id = s.Id,
                ImageUrl = s.ImageUrl,
                Layer1 = s.Layer1,
                Layer2 = s.Layer2,
                Layer3 = s.Layer3,
                ButtonText = s.ButtonText
            }).ToListAsync();
            return View(items);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(SliderCreateVM item)
        {
            if (!ModelState.IsValid)
            {
                return View(item);
            }
            Slider slider = new Slider
            {
                ImageUrl = item.ImageUrl,
                Layer1 = item.Layer1,
                Layer2 = item.Layer2,
                Layer3 = item.Layer3,
                ButtonText = item.ButtonText
            };
            await _db.Sliders.AddAsync(slider);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || id <= 0) return BadRequest();
            var data = await _db.Sliders.FindAsync(id);
            if (id == null) return NotFound();
            _db.Sliders.Remove(data);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Update(int? id)
        {
            if (id == null || id <= 0) return BadRequest();
            var data = await _db.Sliders.FindAsync(id);
            if (data == null) return NotFound();
            return View(new SliderUpdateVM
            {
                ImageUrl = data.ImageUrl,
                Layer1 = data.Layer1,
                Layer2 = data.Layer2,
                Layer3 = data.Layer3,
                ButtonText = data.ButtonText
            });
        }

        [HttpPost]
        public async Task<IActionResult> Update(int? id, SliderUpdateVM vm)
        {
            if (id == null || id <= 0) return BadRequest();
            if (!ModelState.IsValid)
            {
                return View(vm);
            }
            var data = await _db.Sliders.FindAsync(id);
            if (data == null) return NotFound();
            data.ImageUrl = vm.ImageUrl;
            data.Layer1 = vm.Layer1;
            data.Layer2 = vm.Layer2;
            data.Layer3 = vm.Layer3;
            data.ButtonText = vm.ButtonText;
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
