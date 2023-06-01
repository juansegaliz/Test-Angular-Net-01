using Application.ViewModels.Response;
using Application.ViewModels.LandLogistic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface ILandLogisticService
    {
        Task<ResponseViewModel<bool>> CreateAsync(CreateLandLogisticViewModel model);
        Task<ResponseViewModel<bool>> DeleteAsync(int id);
        Task<ResponseViewModel<List<LandLogisticViewModel>>> GetAllAsync();
        Task<ResponseViewModel<LandLogisticViewModel>> GetAsync(int id);
        Task<ResponseViewModel<bool>> UpdateAsync(int id, LandLogisticViewModel model);
    }
}
