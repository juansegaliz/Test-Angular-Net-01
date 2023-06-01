using Application.Interfaces;
using Application.ViewModels.Response;
using Application.ViewModels.MaritimeLogistic;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Presentation.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class MaritimeLogisticsController : ControllerBase
    {
        private readonly IMaritimeLogisticService _maritimeLogisticService;
        public MaritimeLogisticsController(IMaritimeLogisticService maritimeLogisticService) 
        {
            _maritimeLogisticService = maritimeLogisticService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            ResponseViewModel<List<MaritimeLogisticViewModel>> response = await _maritimeLogisticService.GetAllAsync();
            return new ObjectResult(response) { StatusCode = response.Code };
        }
        
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            ResponseViewModel<MaritimeLogisticViewModel> response = await _maritimeLogisticService.GetAsync(id);
            return new ObjectResult(response) { StatusCode = response.Code };
        }
                
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateMaritimeLogisticViewModel model)
        {
            ResponseViewModel<bool> response = await _maritimeLogisticService.CreateAsync(model);
            return new ObjectResult(response) { StatusCode = response.Code };
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] MaritimeLogisticViewModel model)
        {
            ResponseViewModel<bool> response = await _maritimeLogisticService.UpdateAsync(id, model);
            return new ObjectResult(response) { StatusCode = response.Code };
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            ResponseViewModel<bool> response = await _maritimeLogisticService.DeleteAsync(id);
            return new ObjectResult(response) { StatusCode = response.Code };
        }
    }
}
