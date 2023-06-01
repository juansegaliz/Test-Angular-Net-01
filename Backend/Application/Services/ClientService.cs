using Application.Interfaces;
using Application.ViewModels.Response;
using Application.ViewModels.Client;
using Infrastructure.Data.Interfaces;
using Infrastructure.Data.Models;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Net;

namespace Application.Services
{
    
    public class ClientService : IClientService
    {
        private readonly IClientRepository _clientRepository;
        public ClientService(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        public async Task<ResponseViewModel<bool>> CreateAsync(CreateClientViewModel model)
        {
            ResponseViewModel<bool> response = new ResponseViewModel<bool>(HttpStatusCode.BadRequest);
            response.SetData(false);

            var client = await _clientRepository.GetByName(model.Name);

            if (client != null) 
            {
                response.AddMessage("Ya existe un cliente con el mismo nombre");
            }

            if (response.Messages.Any()) 
            {
                return response;
            }

            Client createClient = new Client
            {
                Name = model.Name,
                Address = model.Address,
                Phone = model.Phone
            };

            await _clientRepository.Create(createClient);

            response.SetCode(HttpStatusCode.OK);
            response.SetData(true);
            response.AddMessage("Cliente agregado exitosamente");
            return response;
        }

        public async Task<ResponseViewModel<bool>> UpdateAsync(int id, ClientViewModel model)
        {
            ResponseViewModel<bool> response = new ResponseViewModel<bool>(HttpStatusCode.BadRequest);
            response.SetData(false);

            var client = await _clientRepository.Get(id);

            if (client == null)
            {
                response.AddMessage("Cliente no existe");
            }

            if (response.Messages.Any())
            {
                return response;
            }

            client.Name = model.Name;
            client.Address = model.Address;
            client.Phone = model.Phone;

            await _clientRepository.Update(client);

            response.SetCode(HttpStatusCode.OK);
            response.SetData(true);
            response.AddMessage("Cliente actualizado exitosamente");
            return response;
        }

        public async Task<ResponseViewModel<bool>> DeleteAsync(int id)
        {
            ResponseViewModel<bool> response = new ResponseViewModel<bool>(HttpStatusCode.BadRequest);
            response.SetData(false);

            var client = await _clientRepository.Get(id);

            if (client == null)
            {
                response.AddMessage("Cliente no existe");
            }

            if (response.Messages.Any())
            {
                return response;
            }

            await _clientRepository.Delete(id);

            response.SetCode(HttpStatusCode.OK);
            response.SetData(true);
            response.AddMessage("Cliente eliminado exitosamente");
            return response;
        }

        public async Task<ResponseViewModel<List<ClientViewModel>>> GetAllAsync()
        {
            var response = new ResponseViewModel<List<ClientViewModel>>(HttpStatusCode.BadRequest);

            var clients = await _clientRepository.GetAll();
            
            var clientsReturn = new List<ClientViewModel>();

            clients.ForEach(client => 
            {
                clientsReturn.Add(new ClientViewModel
                {
                    ClientId = client.ClientId,
                    Name = client.Name,
                    Address = client.Address,
                    Phone = client.Phone
                });
            });

            response.SetCode(HttpStatusCode.OK);
            response.SetData(clientsReturn);

            return response;
        }

        public async Task<ResponseViewModel<ClientViewModel>> GetAsync(int id)
        {
            var response = new ResponseViewModel<ClientViewModel>(HttpStatusCode.BadRequest);

            var client = await _clientRepository.Get(id);

            if (client == null)
            {
                response.AddMessage("Cliente no existe");
            }

            if (response.Messages.Any())
            {
                return response;
            }

            ClientViewModel clientReturn = new ClientViewModel
            {
                ClientId = client.ClientId,
                Name = client.Name,
                Address = client.Address,
                Phone = client.Phone
            };

            response.SetCode(HttpStatusCode.OK);
            response.SetData(clientReturn);

            return response;
        }

    }
    
}
