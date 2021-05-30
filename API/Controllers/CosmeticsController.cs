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
        private readonly ICrudService<CosmeticGetModel, CosmeticCreateUpdateModel> _cosmeticService;
        private readonly IFilterService _filterService;

        public CosmeticsController(ICrudService<CosmeticGetModel, CosmeticCreateUpdateModel> cosmeticService, IFilterService filterService)
        {
            _cosmeticService = cosmeticService;
            _filterService = filterService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CosmeticGetModel>>> Index()
        {
            return Ok(await _cosmeticService.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CosmeticGetModel>> GetById(int id)
        {
            return Ok(await _cosmeticService.GetByIdAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> Create(CosmeticCreateUpdateModel model)
        {
            await _cosmeticService.CreateAsync(model);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Update(CosmeticCreateUpdateModel model, int id)
        {
            if (await _cosmeticService.GetByIdAsync(id) is null) return NotFound($"No entity with id {id}");
            await _cosmeticService.UpdateAsync(model, id);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _cosmeticService.DeleteByIdAsync(id);
            return Ok();
        }

        [HttpGet("Filtered")]
        public async Task<ActionResult<IEnumerable<CosmeticGetModel>>> GetFiltered(int? amount)
        {
            if (amount is not null) _filterService.SetMinLeftAmount(amount.Value);
            return Ok(await _filterService.GetFiltered());
        }
    }
}