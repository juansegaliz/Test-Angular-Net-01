using Application.ViewModels.Port;
using Application.ViewModels.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IPortService
    {
        Task<ResponseViewModel<bool>> CreateAsync(CreatePortViewModel model);
        Task<ResponseViewModel<bool>> DeleteAsync(int id);
        Task<ResponseViewModel<List<PortViewModel>>> GetAllAsync();
        Task<ResponseViewModel<PortViewModel>> GetAsync(int id);
        Task<ResponseViewModel<bool>> UpdateAsync(int id, PortViewModel model);
    }
}
