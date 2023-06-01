using Application.ViewModels.Response;
using Application.ViewModels.MaritimeLogistic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IMaritimeLogisticService
    {
        Task<ResponseViewModel<bool>> CreateAsync(CreateMaritimeLogisticViewModel model);
        Task<ResponseViewModel<bool>> DeleteAsync(int id);
        Task<ResponseViewModel<List<MaritimeLogisticViewModel>>> GetAllAsync();
        Task<ResponseViewModel<MaritimeLogisticViewModel>> GetAsync(int id);
        Task<ResponseViewModel<bool>> UpdateAsync(int id, MaritimeLogisticViewModel model);
    }
}
