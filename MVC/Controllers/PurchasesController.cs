using System;
using System.Diagnostics;
using System.Threading.Tasks;
using BLL.Abstract;
using Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Models;
using MVC.Models;

namespace MVC.Controllers
{
    [Authorize]
    public class PurchasesController : Controller
    {
        private readonly ICrudService<PurchaseGetModel, PurchaseCreateUpdateModel> _purchaseService;
        private readonly ICrudService<CosmeticGetModel, CosmeticCreateUpdateModel> _cosmeticService;
        private readonly ICrudService<ClientGetModel, ClientCreateUpdateModel> _clientService;
        private readonly ISellerService _sellerService;

        public PurchasesController(ICrudService<PurchaseGetModel, PurchaseCreateUpdateModel> purchaseService, ICrudService<CosmeticGetModel, CosmeticCreateUpdateModel> cosmeticService, ICrudService<ClientGetModel, ClientCreateUpdateModel> clientService, ISellerService sellerService)
        {
            _purchaseService = purchaseService;
            _cosmeticService = cosmeticService;
            _clientService = clientService;
            _sellerService = sellerService;
        }
        
        // GET: Purchases
        public async Task<IActionResult> Index()
        {
            return View(await _purchaseService.GetAllAsync());
        }

        // GET: Purchases/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var purchase = await _purchaseService.GetByIdAsync(id.Value);
            if (purchase == null)
            {
                return NotFound();
            }

            return View(purchase);
        }

        // GET: Purchases/Create
        public async Task<IActionResult> Create()
        {
            ViewData["ClientId"] = new SelectList((await _clientService.GetAllAsync()), "Id", "Id");
            ViewData["CosmeticId"] = new SelectList((await _cosmeticService.GetAllAsync()), "Id", "Id");
            
            return View();
        }

        // POST: Purchases/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ClientId,CosmeticId,Units")] PurchaseCreateViewModel purchase)
        {
            if (!ModelState.IsValid)
            {
                ViewData["ClientId"] = new SelectList((await _clientService.GetAllAsync()), "Id", "Id");
                ViewData["CosmeticId"] = new SelectList((await _cosmeticService.GetAllAsync()), "Id", "Id");
                return View(purchase);
            }

            try
            {
                await _sellerService.SellCosmeticsToClient(purchase.ClientId, purchase.CosmeticId, purchase.Units);
            }
            catch (InvalidOperationException e)
            {
                return Ok(e.Message);
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: Purchases/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var purchase = await _purchaseService.GetByIdAsync(id.Value);
            if (purchase == null)
            {
                return NotFound();
            }
            ViewData["ClientId"] = new SelectList((await _clientService.GetAllAsync()), "Id", "Id");
            ViewData["CosmeticId"] = new SelectList((await _cosmeticService.GetAllAsync()), "Id", "Id");
            return View(purchase);
        }

        // POST: Purchases/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ClientId,CosmeticId,PurchaseDate,Units")] PurchaseCreateUpdateModel purchase)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _purchaseService.UpdateAsync(purchase, id);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!(await PurchaseExists(id)))
                    {
                        return NotFound();
                    }

                    throw;
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClientId"] = new SelectList((await _clientService.GetAllAsync()), "Id", "Id");
            ViewData["CosmeticId"] = new SelectList((await _cosmeticService.GetAllAsync()), "Id", "Id");
            return View(new PurchaseGetModel
            {
                Client = new ClientGetModel
                {
                    FullName = purchase.Client.FullName,
                    PhoneNumber = purchase.Client.PhoneNumber
                },
                Cosmetic = new CosmeticGetModel
                {
                    DeliveryTime = purchase.Cosmetic.DeliveryTime,
                    Name = purchase.Cosmetic.Name,
                    Price = purchase.Cosmetic.Price,
                    ShelfLife = purchase.Cosmetic.ShelfLife
                },
                ClientId = purchase.ClientId,
                CosmeticId = purchase.CosmeticId,
                PurchaseDate = purchase.PurchaseDate,
                Units = purchase.Units
            });
        }

        // GET: Purchases/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var purchase = await _purchaseService.GetByIdAsync(id.Value);
            if (purchase == null)
            {
                return NotFound();
            }

            return View(purchase);
        }

        // POST: Purchases/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _purchaseService.DeleteByIdAsync(id);
            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> PurchaseExists(int id)
        {
            return (await _purchaseService.GetByIdAsync(id)) is not null;
        }
    }
}
