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
        private readonly ICrudService<PurchaseModel> _purchaseService;
        private readonly ISellerService _sellerService;

        public PurchasesController(ICrudService<PurchaseModel> purchaseService, ISellerService sellerService)
        {
            _purchaseService = purchaseService;
            _sellerService = sellerService;
        }
        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PurchaseModel>>> Index()
        {
            return Ok(await _purchaseService.GetAllAsync());
        }
        
        [HttpGet("{id}")]
        public async Task<ActionResult<ClientModel>> GetById(int id)
        {
            return Ok(await _purchaseService.GetByIdAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> Create(PurchaseModel model)
        {
            await _purchaseService.CreateAsync(model);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Update(PurchaseModel model)
        {
            if (await _purchaseService.GetByIdAsync(model.Id) is null) return NotFound($"No entity with id {model.Id}");
            await _purchaseService.UpdateAsync(model);
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