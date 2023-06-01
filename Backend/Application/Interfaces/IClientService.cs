using Application.ViewModels.Response;
using Application.ViewModels.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IClientService
    {
        Task<ResponseViewModel<bool>> CreateAsync(CreateClientViewModel model);
        Task<ResponseViewModel<bool>> DeleteAsync(int id);
        Task<ResponseViewModel<List<ClientViewModel>>> GetAllAsync();
        Task<ResponseViewModel<ClientViewModel>> GetAsync(int id);
        Task<ResponseViewModel<bool>> UpdateAsync(int id, ClientViewModel model);
    }
}
