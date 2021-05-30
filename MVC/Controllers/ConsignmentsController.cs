using System.Threading.Tasks;
using BLL.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Models;

namespace MVC.Controllers
{
    [Authorize]
    public class ConsignmentsController : Controller
    {
        private readonly ICrudService<ConsignmentGetModel, ConsignmentCreateUpdateModel> _consignmentService;
        private readonly ICrudService<CosmeticGetModel, CosmeticCreateUpdateModel> _cosmeticService;
        private readonly IFilterService _filterService;

        public ConsignmentsController(ICrudService<ConsignmentGetModel, ConsignmentCreateUpdateModel> consignmentService, ICrudService<CosmeticGetModel, CosmeticCreateUpdateModel> cosmeticService, IFilterService filterService)
        {
            _consignmentService = consignmentService;
            _cosmeticService = cosmeticService;
            _filterService = filterService;
        }

        // GET: Consignments
        public async Task<IActionResult> Index()
        {
            return View(await _consignmentService.GetAllAsync());
        }

        public async Task<IActionResult> Filtered(int? amount)
        {
            if (amount is not null)
            {
                _filterService.SetMinLeftAmount(amount.Value);
            }

            return View(await _filterService.GetFiltered());
        }

        // GET: Consignments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var consignment = await _consignmentService.GetByIdAsync(id.Value);
            if (consignment == null)
            {
                return NotFound();
            }

            return View(consignment);
        }

        // GET: Consignments/Create
        public async Task<IActionResult> Create()
        {
            ViewData["CosmeticId"] = new SelectList((await _cosmeticService.GetAllAsync()), "Id", "Id");
            return View();
        }

        // POST: Consignments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CosmeticId,Units,ProductionDate,IsEnding")] ConsignmentCreateUpdateModel consignment)
        {
            if (ModelState.IsValid)
            {
                await _consignmentService.CreateAsync(consignment);
                return RedirectToAction(nameof(Index));
            }
            ViewData["CosmeticId"] = new SelectList((await _cosmeticService.GetAllAsync()), "Id", "Id", consignment.CosmeticId);
            return View(consignment);
        }

        // GET: Consignments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var consignment = await _consignmentService.GetByIdAsync(id.Value);
            if (consignment == null)
            {
                return NotFound();
            }
            ViewData["CosmeticId"] = new SelectList((await _cosmeticService.GetAllAsync()), "Id", "Id", consignment.CosmeticId);
            return View(consignment);
        }

        // POST: Consignments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CosmeticId,Units,ProductionDate,IsEnding")] ConsignmentCreateUpdateModel consignment)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    await _consignmentService.UpdateAsync(consignment, id);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!(await ConsignmentExists(id)))
                    {
                        return NotFound();
                    }

                    throw;
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["CosmeticId"] = new SelectList((await _cosmeticService.GetAllAsync()), "Id", "Id", consignment.CosmeticId);
            return View(new ConsignmentGetModel
            {
                Cosmetic = new CosmeticGetModel
                {
                    DeliveryTime = consignment.Cosmetic.DeliveryTime,
                    Name = consignment.Cosmetic.Name,
                    Price = consignment.Cosmetic.Price,
                    ShelfLife = consignment.Cosmetic.ShelfLife
                },
                CosmeticId = consignment.CosmeticId,
                IsEnding = consignment.IsEnding,
                ProductionDate = consignment.ProductionDate,
                Units = consignment.Units
            });
        }

        // GET: Consignments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var consignment = await _consignmentService.GetByIdAsync(id.Value);
            if (consignment == null)
            {
                return NotFound();
            }

            return View(consignment);
        }

        // POST: Consignments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _consignmentService.DeleteByIdAsync(id);
            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> ConsignmentExists(int id)
        {
            return (await _consignmentService.GetByIdAsync(id)) is not null;
        }
    }
}
