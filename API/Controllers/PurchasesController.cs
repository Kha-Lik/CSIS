using System.Collections.Generic;
using System.Threading.Tasks;
using BLL.Abstract;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace API.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class PurchasesController : Controller
    {
        private readonly ICrudService<PurchaseGetModel, PurchaseCreateUpdateModel> _purchaseService;
        private readonly ISellerService _sellerService;

        public PurchasesController(ICrudService<PurchaseGetModel, PurchaseCreateUpdateModel> purchaseService, ISellerService sellerService)
        {
            _purchaseService = purchaseService;
            _sellerService = sellerService;
        }
        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PurchaseGetModel>>> Index()
        {
            return Ok(await _purchaseService.GetAllAsync());
        }
        
        [HttpGet("{id}")]
        public async Task<ActionResult<ClientGetModel>> GetById(int id)
        {
            return Ok(await _purchaseService.GetByIdAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> Create(PurchaseCreateUpdateModel model)
        {
            await _purchaseService.CreateAsync(model);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Update(PurchaseCreateUpdateModel model, int id)
        {
            if (await _purchaseService.GetByIdAsync(id) is null) return NotFound($"No entity with id {id}");
            await _purchaseService.UpdateAsync(model, id);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _purchaseService.DeleteByIdAsync(id);
            return Ok();
        }

        [HttpPost("New")]
        public async Task<IActionResult> SellCosmeticsToClient(int clientId, int cosmeticId, int units)
        {
            await _sellerService.SellCosmeticsToClient(clientId, cosmeticId, units);
            return Ok();
        }
    }
}