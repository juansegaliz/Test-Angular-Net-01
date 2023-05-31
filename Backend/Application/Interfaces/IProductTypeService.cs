using Application.ViewModels.Response;
using Application.ViewModels.ProductType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IProductTypeService
    {
        Task<ResponseViewModel<bool>> CreateAsync(CreateProductTypeViewModel model);
        Task<ResponseViewModel<bool>> DeleteAsync(int id);
        Task<ResponseViewModel<List<ProductTypeViewModel>>> GetAllAsync();
        Task<ResponseViewModel<ProductTypeViewModel>> GetAsync(int id);
        Task<ResponseViewModel<bool>> UpdateAsync(int id, ProductTypeViewModel model);
    }
}
