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
        private readonly ICrudService<ClientGetModel, ClientCreateUpdateModel> _clientService;

        public ClientsController(ICrudService<ClientGetModel, ClientCreateUpdateModel> clientService)
        {
            _clientService = clientService;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClientGetModel>>> Index()
        {
            return Ok(await _clientService.GetAllAsync());
        }
        
        [HttpGet("{id}")]
        public async Task<ActionResult<ClientGetModel>> GetById(int id)
        {
            return Ok(await _clientService.GetByIdAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> Create(ClientCreateUpdateModel model)
        {
            await _clientService.CreateAsync(model);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Update(ClientCreateUpdateModel model, int id)
        {
            if (await _clientService.GetByIdAsync(id) is null) return NotFound($"No entity with id {id}");
            await _clientService.UpdateAsync(model, id);
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