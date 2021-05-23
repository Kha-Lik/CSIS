using System.Collections.Generic;
using System.Threading.Tasks;
using BLL.Abstract;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace API.Controllers
{
    [Produces(("application/json"))]
    [Route("api/[controller]")]
    [ApiController]
    public class CosmeticsController : Controller
    {
        private readonly ICrudService<CosmeticModel> _cosmeticService;
        private readonly IFilterService _filterService;

        public CosmeticsController(ICrudService<CosmeticModel> cosmeticService, IFilterService filterService)
        {
            _cosmeticService = cosmeticService;
            _filterService = filterService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CosmeticModel>>> Index()
        {
            return Ok(await _cosmeticService.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CosmeticModel>> GetById(int id)
        {
            return Ok(await _cosmeticService.GetByIdAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> Create(CosmeticModel model)
        {
            await _cosmeticService.CreateAsync(model);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Update(CosmeticModel model)
        {
            if (await _cosmeticService.GetByIdAsync(model.Id) is null) return NotFound($"No entity with id {model.Id}");
            await _cosmeticService.UpdateAsync(model);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _cosmeticService.DeleteByIdAsync(id);
            return Ok();
        }

        [HttpGet("Filtered")]
        public async Task<ActionResult<IEnumerable<CosmeticModel>>> GetFiltered(int? amount)
        {
            if (amount is not null) _filterService.SetMinLeftAmount(amount.Value);
            return Ok(await _filterService.GetFiltered());
        }
    }
}