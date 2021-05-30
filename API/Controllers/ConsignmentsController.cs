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
    public class ConsignmentsController : Controller
    {
        private readonly ICrudService<ConsignmentGetModel, ConsignmentCreateUpdateModel> _consignmentService;

        public ConsignmentsController(ICrudService<ConsignmentGetModel, ConsignmentCreateUpdateModel> consignmentService)
        {
            _consignmentService = consignmentService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ConsignmentGetModel>>> Index()
        {
            return Ok(await _consignmentService.GetAllAsync());
        }
        
        [HttpGet("{id}")]
        public async Task<ActionResult<ConsignmentGetModel>> GetById(int id)
        {
            return Ok(await _consignmentService.GetByIdAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> Create(ConsignmentCreateUpdateModel model)
        {
            await _consignmentService.CreateAsync(model);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Update(ConsignmentCreateUpdateModel model, int id)
        {
            if (await _consignmentService.GetByIdAsync(id) is null) return NotFound($"No entity with id {id}");
            await _consignmentService.UpdateAsync(model, id);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _consignmentService.DeleteByIdAsync(id);
            return Ok();
        }
    }
}