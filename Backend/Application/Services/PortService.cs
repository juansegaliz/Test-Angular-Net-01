using Application.Interfaces;
using Application.ViewModels.Response;
using Application.ViewModels.Port;
using Infrastructure.Data.Interfaces;
using Infrastructure.Data.Models;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Net;

namespace Application.Services
{
    public class PortService : IPortService
    {
        private readonly IPortRepository _portRepository;
        public PortService(IPortRepository portRepository)
        {
            _portRepository = portRepository;
        }

        public async Task<ResponseViewModel<bool>> CreateAsync(CreatePortViewModel model)
        {
            ResponseViewModel<bool> response = new ResponseViewModel<bool>(HttpStatusCode.BadRequest);
            response.SetData(false);

            var port = await _portRepository.GetByName(model.Name);

            if (port != null) 
            {
                response.AddMessage("Ya existe un puerto con el mismo nombre");
            }

            if (response.Messages.Any()) 
            {
                return response;
            }

            Port createPort = new Port
            {
                Name = model.Name,
                City = model.City,
                Country = model.Country,
            };

            await _portRepository.Create(createPort);

            response.SetCode(HttpStatusCode.OK);
            response.SetData(true);
            response.AddMessage("Puerto agregado exitosamente");
            return response;
        }

        public async Task<ResponseViewModel<bool>> UpdateAsync(int id, PortViewModel model)
        {
            ResponseViewModel<bool> response = new ResponseViewModel<bool>(HttpStatusCode.BadRequest);
            response.SetData(false);

            var port = await _portRepository.Get(id);

            if (port == null)
            {
                response.AddMessage("Puerto no existe");
            }

            if (response.Messages.Any())
            {
                return response;
            }

            port.Name = model.Name;
            port.City = model.City;
            port.Country = model.Country;

            await _portRepository.Update(port);

            response.SetCode(HttpStatusCode.OK);
            response.SetData(true);
            response.AddMessage("Puerto actualizado exitosamente");
            return response;
        }

        public async Task<ResponseViewModel<bool>> DeleteAsync(int id)
        {
            ResponseViewModel<bool> response = new ResponseViewModel<bool>(HttpStatusCode.BadRequest);
            response.SetData(false);

            var port = await _portRepository.Get(id);

            if (port == null)
            {
                response.AddMessage("Puerto no existe");
            }

            if (response.Messages.Any())
            {
                return response;
            }

            await _portRepository.Delete(id);

            response.SetCode(HttpStatusCode.OK);
            response.SetData(true);
            response.AddMessage("Puerto eliminado exitosamente");
            return response;
        }

        public async Task<ResponseViewModel<List<PortViewModel>>> GetAllAsync()
        {
            var response = new ResponseViewModel<List<PortViewModel>>(HttpStatusCode.BadRequest);

            var ports = await _portRepository.GetAll();
            
            var portsReturn = new List<PortViewModel>();

            ports.ForEach(port => 
            {
                portsReturn.Add(new PortViewModel
                {
                    PortId = port.PortId,
                    Name = port.Name,
                    City = port.City,
                    Country = port.Country,
                });
            });

            response.SetCode(HttpStatusCode.OK);
            response.SetData(portsReturn);

            return response;
        }

        public async Task<ResponseViewModel<PortViewModel>> GetAsync(int id)
        {
            var response = new ResponseViewModel<PortViewModel>(HttpStatusCode.BadRequest);

            var port = await _portRepository.Get(id);

            if (port == null)
            {
                response.AddMessage("Puerto no existe");
            }

            if (response.Messages.Any())
            {
                return response;
            }

            PortViewModel portReturn = new PortViewModel
            {
                PortId = port.PortId,
                Name = port.Name,
                City = port.City,
                Country = port.Country,
            };

            response.SetCode(HttpStatusCode.OK);
            response.SetData(portReturn);

            return response;
        }

    }
}
