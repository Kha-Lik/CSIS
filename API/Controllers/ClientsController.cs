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
    public class ClientsController : Controller
    {
        private readonly ICrudService<ClientModel> _clientService;

        public ClientsController(ICrudService<ClientModel> clientService)
        {
            _clientService = clientService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClientModel>>> Index()
        {
            return Ok(await _clientService.GetAllAsync());
        }
        
        [HttpGet("{id}")]
        public async Task<ActionResult<ClientModel>> GetById(int id)
        {
            return Ok(await _clientService.GetByIdAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> Create(ClientModel model)
        {
            await _clientService.CreateAsync(model);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Update(ClientModel model)
        {
            if (await _clientService.GetByIdAsync(model.Id) is null) return NotFound($"No entity with id {model.Id}");
            await _clientService.UpdateAsync(model);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _clientService.DeleteByIdAsync(id);
            return Ok();
        }
    }
}