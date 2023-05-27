using Application.Interfaces;
using Application.ViewModels.Response;
using Application.ViewModels.Warehouse;
using Infrastructure.Data.Interfaces;
using Infrastructure.Data.Models;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Net;

namespace Application.Services
{
    public class WarehouseService : IWarehouseService
    {
        private readonly IWarehouseRepository _warehouseRepository;
        public WarehouseService(IWarehouseRepository warehouseRepository)
        {
            _warehouseRepository = warehouseRepository;
        }

        public async Task<ResponseViewModel<bool>> CreateAsync(CreateWarehouseViewModel model)
        {
            ResponseViewModel<bool> response = new ResponseViewModel<bool>(HttpStatusCode.BadRequest);
            response.SetData(false);

            var warehouse = await _warehouseRepository.GetByName(model.Name);

            if (warehouse != null) 
            {
                response.AddMessage("Ya existe un almacen con el mismo nombre");
            }

            if (response.Messages.Any()) 
            {
                return response;
            }

            Warehouse createWarehouse = new Warehouse
            {
                Name = model.Name,
                Address = model.Address
            };

            await _warehouseRepository.Create(createWarehouse);

            response.SetCode(HttpStatusCode.OK);
            response.SetData(true);
            response.AddMessage("Almacen agregado exitosamente");
            return response;
        }

        public async Task<ResponseViewModel<bool>> UpdateAsync(int id, WarehouseViewModel model)
        {
            ResponseViewModel<bool> response = new ResponseViewModel<bool>(HttpStatusCode.BadRequest);
            response.SetData(false);

            var warehouse = await _warehouseRepository.Get(id);

            if (warehouse == null)
            {
                response.AddMessage("Almacen no existe");
            }

            if (response.Messages.Any())
            {
                return response;
            }

            warehouse.Name = model.Name;
            warehouse.Address = model.Address;

            await _warehouseRepository.Update(warehouse);

            response.SetCode(HttpStatusCode.OK);
            response.SetData(true);
            response.AddMessage("Almacen actualizado exitosamente");
            return response;
        }

        public async Task<ResponseViewModel<bool>> DeleteAsync(int id)
        {
            ResponseViewModel<bool> response = new ResponseViewModel<bool>(HttpStatusCode.BadRequest);
            response.SetData(false);

            var warehouse = await _warehouseRepository.Get(id);

            if (warehouse == null)
            {
                response.AddMessage("Almacen no existe");
            }

            if (response.Messages.Any())
            {
                return response;
            }

            await _warehouseRepository.Delete(id);

            response.SetCode(HttpStatusCode.OK);
            response.SetData(true);
            response.AddMessage("Almacen eliminado exitosamente");
            return response;
        }

        public async Task<ResponseViewModel<List<WarehouseViewModel>>> GetAllAsync()
        {
            var response = new ResponseViewModel<List<WarehouseViewModel>>(HttpStatusCode.BadRequest);

            var warehouses = await _warehouseRepository.GetAll();
            
            var warehousesReturn = new List<WarehouseViewModel>();

            warehouses.ForEach(warehouse => 
            {
                warehousesReturn.Add(new WarehouseViewModel
                {
                    WarehouseId = warehouse.WarehouseId,
                    Name = warehouse.Name,
                    Address = warehouse.Address
                });
            });

            response.SetCode(HttpStatusCode.OK);
            response.SetData(warehousesReturn);

            return response;
        }

        public async Task<ResponseViewModel<WarehouseViewModel>> GetAsync(int id)
        {
            var response = new ResponseViewModel<WarehouseViewModel>(HttpStatusCode.BadRequest);

            var warehouse = await _warehouseRepository.Get(id);

            if (warehouse == null)
            {
                response.AddMessage("Almacen no existe");
            }

            if (response.Messages.Any())
            {
                return response;
            }

            WarehouseViewModel warehouseReturn = new WarehouseViewModel
            {
                WarehouseId = warehouse.WarehouseId,
                Name = warehouse.Name,
                Address = warehouse.Address
            };

            response.SetCode(HttpStatusCode.OK);
            response.SetData(warehouseReturn);

            return response;
        }

    }
}
