using System.Collections.Generic;
using System.Threading.Tasks;
using BLL.Abstract;
using Entities;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace API.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class ConsignmentsController : Controller
    {
        private readonly ICrudService<ConsignmentModel> _consignmentService;

        public ConsignmentsController(ICrudService<ConsignmentModel> consignmentService)
        {
            _consignmentService = consignmentService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ConsignmentModel>>> Index()
        {
            return Ok(await _consignmentService.GetAllAsync());
        }
        
        [HttpGet("{id}")]
        public async Task<ActionResult<Consignment>> GetById(int id)
        {
            return Ok(await _consignmentService.GetByIdAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> Create(ConsignmentModel model)
        {
            await _consignmentService.CreateAsync(model);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Update(ConsignmentModel model)
        {
            if (await _consignmentService.GetByIdAsync(model.Id) is null) return NotFound($"No entity with id {model.Id}");
            await _consignmentService.UpdateAsync(model);
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