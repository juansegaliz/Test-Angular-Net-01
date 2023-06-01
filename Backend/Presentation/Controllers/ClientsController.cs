using Application.Interfaces;
using Application.ViewModels.Response;
using Application.ViewModels.Client;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Presentation.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        private readonly IClientService _clientService;
        public ClientsController(IClientService clientService) 
        {
            _clientService = clientService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            ResponseViewModel<List<ClientViewModel>> response = await _clientService.GetAllAsync();
            return new ObjectResult(response) { StatusCode = response.Code };
        }
        
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            ResponseViewModel<ClientViewModel> response = await _clientService.GetAsync(id);
            return new ObjectResult(response) { StatusCode = response.Code };
        }
                
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateClientViewModel model)
        {
            ResponseViewModel<bool> response = await _clientService.CreateAsync(model);
            return new ObjectResult(response) { StatusCode = response.Code };
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] ClientViewModel model)
        {
            ResponseViewModel<bool> response = await _clientService.UpdateAsync(id, model);
            return new ObjectResult(response) { StatusCode = response.Code };
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            ResponseViewModel<bool> response = await _clientService.DeleteAsync(id);
            return new ObjectResult(response) { StatusCode = response.Code };
        }
    }
}
