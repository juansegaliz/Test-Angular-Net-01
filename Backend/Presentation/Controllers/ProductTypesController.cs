using Application.Interfaces;
using Application.ViewModels.Response;
using Application.ViewModels.ProductType;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Presentation.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductTypesController : ControllerBase
    {
        private readonly IProductTypeService _productTypeService;
        public ProductTypesController(IProductTypeService productTypeService) 
        {
            _productTypeService = productTypeService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            ResponseViewModel<List<ProductTypeViewModel>> response = await _productTypeService.GetAllAsync();
            return new ObjectResult(response) { StatusCode = response.Code };
        }
        
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            ResponseViewModel<ProductTypeViewModel> response = await _productTypeService.GetAsync(id);
            return new ObjectResult(response) { StatusCode = response.Code };
        }
                
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateProductTypeViewModel model)
        {
            ResponseViewModel<bool> response = await _productTypeService.CreateAsync(model);
            return new ObjectResult(response) { StatusCode = response.Code };
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] ProductTypeViewModel model)
        {
            ResponseViewModel<bool> response = await _productTypeService.UpdateAsync(id, model);
            return new ObjectResult(response) { StatusCode = response.Code };
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            ResponseViewModel<bool> response = await _productTypeService.DeleteAsync(id);
            return new ObjectResult(response) { StatusCode = response.Code };
        }
    }
}
