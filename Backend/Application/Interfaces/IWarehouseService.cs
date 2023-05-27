using Application.ViewModels.Response;
using Application.ViewModels.Warehouse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IWarehouseService
    {
        Task<ResponseViewModel<bool>> CreateAsync(CreateWarehouseViewModel model);
        Task<ResponseViewModel<bool>> DeleteAsync(int id);
        Task<ResponseViewModel<List<WarehouseViewModel>>> GetAllAsync();
        Task<ResponseViewModel<WarehouseViewModel>> GetAsync(int id);
        Task<ResponseViewModel<bool>> UpdateAsync(int id, WarehouseViewModel model);
    }
}
