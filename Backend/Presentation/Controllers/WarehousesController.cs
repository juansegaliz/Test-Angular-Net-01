using Application.Interfaces;
using Application.ViewModels.Response;
using Application.ViewModels.Warehouse;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Presentation.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class WarehousesController : ControllerBase
    {
        private readonly IWarehouseService _warehouseService;
        public WarehousesController(IWarehouseService warehouseService) 
        {
            _warehouseService = warehouseService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            ResponseViewModel<List<WarehouseViewModel>> response = await _warehouseService.GetAllAsync();
            return new ObjectResult(response) { StatusCode = response.Code };
        }
        
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            ResponseViewModel<WarehouseViewModel> response = await _warehouseService.GetAsync(id);
            return new ObjectResult(response) { StatusCode = response.Code };
        }
                
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateWarehouseViewModel model)
        {
            ResponseViewModel<bool> response = await _warehouseService.CreateAsync(model);
            return new ObjectResult(response) { StatusCode = response.Code };
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] WarehouseViewModel model)
        {
            ResponseViewModel<bool> response = await _warehouseService.UpdateAsync(id, model);
            return new ObjectResult(response) { StatusCode = response.Code };
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            ResponseViewModel<bool> response = await _warehouseService.DeleteAsync(id);
            return new ObjectResult(response) { StatusCode = response.Code };
        }
    }
}
