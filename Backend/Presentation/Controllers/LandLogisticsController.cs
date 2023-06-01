using Application.Interfaces;
using Application.ViewModels.Response;
using Application.ViewModels.LandLogistic;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Presentation.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class LandLogisticsController : ControllerBase
    {
        private readonly ILandLogisticService _landLogisticService;
        public LandLogisticsController(ILandLogisticService landLogisticService) 
        {
            _landLogisticService = landLogisticService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            ResponseViewModel<List<LandLogisticViewModel>> response = await _landLogisticService.GetAllAsync();
            return new ObjectResult(response) { StatusCode = response.Code };
        }
        
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            ResponseViewModel<LandLogisticViewModel> response = await _landLogisticService.GetAsync(id);
            return new ObjectResult(response) { StatusCode = response.Code };
        }
                
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateLandLogisticViewModel model)
        {
            ResponseViewModel<bool> response = await _landLogisticService.CreateAsync(model);
            return new ObjectResult(response) { StatusCode = response.Code };
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] LandLogisticViewModel model)
        {
            ResponseViewModel<bool> response = await _landLogisticService.UpdateAsync(id, model);
            return new ObjectResult(response) { StatusCode = response.Code };
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            ResponseViewModel<bool> response = await _landLogisticService.DeleteAsync(id);
            return new ObjectResult(response) { StatusCode = response.Code };
        }
    }
}
