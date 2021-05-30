using System.Threading.Tasks;
using BLL.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models;

namespace MVC.Controllers
{
    [Authorize]
    public class CosmeticsController : Controller
    {
        private readonly ICrudService<CosmeticGetModel, CosmeticCreateUpdateModel> _cosmeticService;

        public CosmeticsController(ICrudService<CosmeticGetModel, CosmeticCreateUpdateModel> cosmeticService)
        {
            _cosmeticService = cosmeticService;
        }

        // GET: Cosmetics
        public async Task<IActionResult> Index()
        {
            return View(await _cosmeticService.GetAllAsync());
        }

        // GET: Cosmetics/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cosmetic = await _cosmeticService.GetByIdAsync(id.Value);
            if (cosmetic == null)
            {
                return NotFound();
            }

            return View(cosmetic);
        }

        // GET: Cosmetics/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Cosmetics/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Price,DeliveryTime,ShelfLife")] CosmeticCreateUpdateModel cosmetic)
        {
            if (ModelState.IsValid)
            {
                await _cosmeticService.CreateAsync(cosmetic);
                return RedirectToAction(nameof(Index));
            }
            return View(cosmetic);
        }

        // GET: Cosmetics/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cosmetic = await _cosmeticService.GetByIdAsync(id.Value);
            if (cosmetic == null)
            {
                return NotFound();
            }
            return View(cosmetic);
        }

        // POST: Cosmetics/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Name,Price,DeliveryTime,ShelfLife")] CosmeticCreateUpdateModel cosmetic)
        {
            if (!ModelState.IsValid) return View(new CosmeticGetModel
            {
                DeliveryTime = cosmetic.DeliveryTime, 
                Name = cosmetic.Name, 
                Price = cosmetic.Price, 
                ShelfLife = cosmetic.ShelfLife
            });
            try
            {
                await _cosmeticService.UpdateAsync(cosmetic, id);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!(await CosmeticExists(id)))
                {
                    return NotFound();
                }
                throw;
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: Cosmetics/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cosmetic = await _cosmeticService.GetByIdAsync(id.Value);
            if (cosmetic == null)
            {
                return NotFound();
            }

            return View(cosmetic);
        }

        // POST: Cosmetics/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _cosmeticService.DeleteByIdAsync(id);
            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> CosmeticExists(int id)
        {
            return (await _cosmeticService.GetByIdAsync(id)) is not null;
        }
    }
}
