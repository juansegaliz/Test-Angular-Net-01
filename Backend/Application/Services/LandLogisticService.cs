using Application.Interfaces;
using Application.ViewModels.Response;
using Application.ViewModels.LandLogistic;
using Infrastructure.Data.Interfaces;
using Infrastructure.Data.Models;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Net;
using Infrastructure.Data.Repositories;

namespace Application.Services
{
    public class LandLogisticService : ILandLogisticService
    {
        private readonly ILandLogisticRepository _landLogisticRepository;
        private readonly IProductTypeRepository _productTypeRepository;
        private readonly IWarehouseRepository _warehouseRepository;
        private readonly IClientRepository _clientRepository;

        public LandLogisticService(ILandLogisticRepository landLogisticRepository, IProductTypeRepository productTypeRepository, 
            IWarehouseRepository warehouseRepository, IClientRepository clientRepository)
        {
            _landLogisticRepository = landLogisticRepository;
            _productTypeRepository = productTypeRepository;
            _warehouseRepository = warehouseRepository;
            _clientRepository = clientRepository;
        }

        public async Task<ResponseViewModel<bool>> CreateAsync(CreateLandLogisticViewModel model)
        {
            ResponseViewModel<bool> response = new ResponseViewModel<bool>(HttpStatusCode.BadRequest);
            response.SetData(false);

            var productType = await _productTypeRepository.Get(model.ProductTypeId);

            if (productType == null)
            {
                response.AddMessage("Tipo de producto no existe");
            }

            var warehouse = await _warehouseRepository.Get(model.WarehouseId);

            if (warehouse == null)
            {
                response.AddMessage("Almacen no existe");
            }

            var client = await _clientRepository.Get(model.ClientId);

            if (client == null)
            {
                response.AddMessage("Cliente no existe");
            }

            if (response.Messages.Any())
            {
                return response;
            }

            Domain.Entities.LandLogistic domainLogistic = new Domain.Entities.LandLogistic(0, 
                model.ProductTypeId, model.Quantity, model.RegistrationDate, model.DeliveryDate, 
                model.WarehouseId, model.ShippingPrice, model.VehiclePlate, model.GuideNumber, 
                model.ClientId);

            LandLogistic createLandLogistic = new LandLogistic
            {
                ProductTypeId = domainLogistic.ProductTypeId,
                Quantity = domainLogistic.Quantity,
                RegistrationDate = domainLogistic.RegistrationDate,
                DeliveryDate = domainLogistic.DeliveryDate,
                WarehouseId = domainLogistic.WarehouseId,
                ShippingPrice = domainLogistic.ShippingPrice,
                Discount = domainLogistic.Discount,
                TotalPrice = domainLogistic.TotalPrice,
                VehiclePlate = domainLogistic.VehiclePlate,
                GuideNumber = domainLogistic.GuideNumber,
                ClientId = domainLogistic.ClientId
            };

            await _landLogisticRepository.Create(createLandLogistic);

            response.SetCode(HttpStatusCode.OK);
            response.SetData(true);
            response.AddMessage("Logistica terrestre agregada exitosamente");
            return response;
        }

        public async Task<ResponseViewModel<bool>> UpdateAsync(int id, LandLogisticViewModel model)
        {
            ResponseViewModel<bool> response = new ResponseViewModel<bool>(HttpStatusCode.BadRequest);
            response.SetData(false);

            var landLogistic = await _landLogisticRepository.Get(id);

            if (landLogistic == null)
            {
                response.AddMessage("Logistica terrestre no existe");
            }

            var productType = await _productTypeRepository.Get(model.ProductTypeId);

            if (productType == null)
            {
                response.AddMessage("Tipo de producto no existe");
            }

            var warehouse = await _warehouseRepository.Get(model.WarehouseId);

            if (warehouse == null)
            {
                response.AddMessage("Almacen no existe");
            }

            var client = await _clientRepository.Get(model.ClientId);

            if (client == null)
            {
                response.AddMessage("Cliente no existe");
            }

            if (response.Messages.Any())
            {
                return response;
            }

            Domain.Entities.LandLogistic domainLogistic = new Domain.Entities.LandLogistic(model.LandLogisticsId,
                model.ProductTypeId, model.Quantity, model.RegistrationDate, model.DeliveryDate,
                model.WarehouseId, model.ShippingPrice, model.VehiclePlate, model.GuideNumber,
                model.ClientId);

            landLogistic.ProductTypeId = domainLogistic.ProductTypeId;
            landLogistic.Quantity = domainLogistic.Quantity;
            landLogistic.RegistrationDate = domainLogistic.RegistrationDate;
            landLogistic.DeliveryDate = domainLogistic.DeliveryDate;
            landLogistic.WarehouseId = domainLogistic.WarehouseId;
            landLogistic.ShippingPrice = domainLogistic.ShippingPrice;
            landLogistic.Discount = domainLogistic.Discount;
            landLogistic.TotalPrice = domainLogistic.TotalPrice;
            landLogistic.VehiclePlate = domainLogistic.VehiclePlate;
            landLogistic.GuideNumber = domainLogistic.GuideNumber;
            landLogistic.ClientId = domainLogistic.ClientId;

            await _landLogisticRepository.Update(landLogistic);

            response.SetCode(HttpStatusCode.OK);
            response.SetData(true);
            response.AddMessage("Logistica terrestre actualizada exitosamente");
            return response;
        }

        public async Task<ResponseViewModel<bool>> DeleteAsync(int id)
        {
            ResponseViewModel<bool> response = new ResponseViewModel<bool>(HttpStatusCode.BadRequest);
            response.SetData(false);

            var landLogistic = await _landLogisticRepository.Get(id);

            if (landLogistic == null)
            {
                response.AddMessage("Logistica terrestre no existe");
            }

            if (response.Messages.Any())
            {
                return response;
            }

            await _landLogisticRepository.Delete(id);

            response.SetCode(HttpStatusCode.OK);
            response.SetData(true);
            response.AddMessage("Logistica terrestre eliminada exitosamente");
            return response;
        }

        public async Task<ResponseViewModel<List<LandLogisticViewModel>>> GetAllAsync()
        {
            var response = new ResponseViewModel<List<LandLogisticViewModel>>(HttpStatusCode.BadRequest);

            var landLogistics = await _landLogisticRepository.GetAll();
            
            var landLogisticsReturn = new List<LandLogisticViewModel>();

            landLogistics.ForEach(landLogistic => 
            {
                landLogisticsReturn.Add(new LandLogisticViewModel
                {
                    LandLogisticsId = landLogistic.LandLogisticsId,
                    ProductTypeId = landLogistic.ProductTypeId,
                    Quantity = landLogistic.Quantity,
                    RegistrationDate = landLogistic.RegistrationDate,
                    DeliveryDate = landLogistic.DeliveryDate,
                    WarehouseId = landLogistic.WarehouseId,
                    ShippingPrice = landLogistic.ShippingPrice,
                    Discount = landLogistic.Discount,
                    TotalPrice = landLogistic.TotalPrice,
                    VehiclePlate = landLogistic.VehiclePlate,
                    GuideNumber = landLogistic.GuideNumber,
                    ClientId = landLogistic.ClientId
                });
            });

            response.SetCode(HttpStatusCode.OK);
            response.SetData(landLogisticsReturn);

            return response;
        }

        public async Task<ResponseViewModel<LandLogisticViewModel>> GetAsync(int id)
        {
            var response = new ResponseViewModel<LandLogisticViewModel>(HttpStatusCode.BadRequest);

            var landLogistic = await _landLogisticRepository.Get(id);

            if (landLogistic == null)
            {
                response.AddMessage("Logistica terrestre no existe");
            }

            if (response.Messages.Any())
            {
                return response;
            }

            LandLogisticViewModel landLogisticReturn = new LandLogisticViewModel
            {
                LandLogisticsId = landLogistic.LandLogisticsId,
                ProductTypeId = landLogistic.ProductTypeId,
                Quantity = landLogistic.Quantity,
                RegistrationDate = landLogistic.RegistrationDate,
                DeliveryDate = landLogistic.DeliveryDate,
                WarehouseId = landLogistic.WarehouseId,
                ShippingPrice = landLogistic.ShippingPrice,
                Discount = landLogistic.Discount,
                TotalPrice = landLogistic.TotalPrice,
                VehiclePlate = landLogistic.VehiclePlate,
                GuideNumber = landLogistic.GuideNumber,
                ClientId = landLogistic.ClientId
            };

            response.SetCode(HttpStatusCode.OK);
            response.SetData(landLogisticReturn);

            return response;
        }

    }
}
