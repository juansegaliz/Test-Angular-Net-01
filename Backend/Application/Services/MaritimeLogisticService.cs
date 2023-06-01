using Application.Interfaces;
using Application.ViewModels.Response;
using Application.ViewModels.MaritimeLogistic;
using Infrastructure.Data.Interfaces;
using Infrastructure.Data.Models;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Net;
using Infrastructure.Data.Repositories;

namespace Application.Services
{
    public class MaritimeLogisticService : IMaritimeLogisticService
    {
        private readonly IMaritimeLogisticRepository _maritimeLogisticRepository;
        private readonly IProductTypeRepository _productTypeRepository;
        private readonly IPortRepository _portRepository;
        private readonly IClientRepository _clientRepository;

        public MaritimeLogisticService(IMaritimeLogisticRepository maritimeLogisticRepository, IProductTypeRepository productTypeRepository, 
            IPortRepository portRepository, IClientRepository clientRepository)
        {
            _maritimeLogisticRepository = maritimeLogisticRepository;
            _productTypeRepository = productTypeRepository;
            _portRepository = portRepository;
            _clientRepository = clientRepository;
        }

        public async Task<ResponseViewModel<bool>> CreateAsync(CreateMaritimeLogisticViewModel model)
        {
            ResponseViewModel<bool> response = new ResponseViewModel<bool>(HttpStatusCode.BadRequest);
            response.SetData(false);

            var productType = await _productTypeRepository.Get(model.ProductTypeId);

            if (productType == null)
            {
                response.AddMessage("Tipo de producto no existe");
            }

            var port = await _portRepository.Get(model.PortId);

            if (port == null)
            {
                response.AddMessage("Puerto no existe");
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

            Domain.Entities.MaritimeLogistic domainLogistic = new Domain.Entities.MaritimeLogistic(0, 
                model.ProductTypeId, model.Quantity, model.RegistrationDate, model.DeliveryDate, 
                model.PortId, model.ShippingPrice, model.FleetNumber, model.GuideNumber, 
                model.ClientId);

            MaritimeLogistic createMaritimeLogistic = new MaritimeLogistic
            {
                ProductTypeId = domainLogistic.ProductTypeId,
                Quantity = domainLogistic.Quantity,
                RegistrationDate = domainLogistic.RegistrationDate,
                DeliveryDate = domainLogistic.DeliveryDate,
                PortId = domainLogistic.PortId,
                ShippingPrice = domainLogistic.ShippingPrice,
                Discount = domainLogistic.Discount,
                TotalPrice = domainLogistic.TotalPrice,
                FleetNumber = domainLogistic.FleetNumber,
                GuideNumber = domainLogistic.GuideNumber,
                ClientId = domainLogistic.ClientId
            };

            await _maritimeLogisticRepository.Create(createMaritimeLogistic);

            response.SetCode(HttpStatusCode.OK);
            response.SetData(true);
            response.AddMessage("Logistica maritima agregada exitosamente");
            return response;
        }

        public async Task<ResponseViewModel<bool>> UpdateAsync(int id, MaritimeLogisticViewModel model)
        {
            ResponseViewModel<bool> response = new ResponseViewModel<bool>(HttpStatusCode.BadRequest);
            response.SetData(false);

            var maritimeLogistic = await _maritimeLogisticRepository.Get(id);

            if (maritimeLogistic == null)
            {
                response.AddMessage("Logistica maritima no existe");
            }

            var productType = await _productTypeRepository.Get(model.ProductTypeId);

            if (productType == null)
            {
                response.AddMessage("Tipo de producto no existe");
            }

            var port = await _portRepository.Get(model.PortId);

            if (port == null)
            {
                response.AddMessage("Puerto no existe");
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

            Domain.Entities.MaritimeLogistic domainLogistic = new Domain.Entities.MaritimeLogistic(model.MaritimeLogisticsId,
                model.ProductTypeId, model.Quantity, model.RegistrationDate, model.DeliveryDate,
                model.PortId, model.ShippingPrice, model.FleetNumber, model.GuideNumber,
                model.ClientId);

            maritimeLogistic.ProductTypeId = domainLogistic.ProductTypeId;
            maritimeLogistic.Quantity = domainLogistic.Quantity;
            maritimeLogistic.RegistrationDate = domainLogistic.RegistrationDate;
            maritimeLogistic.DeliveryDate = domainLogistic.DeliveryDate;
            maritimeLogistic.PortId = domainLogistic.PortId;
            maritimeLogistic.ShippingPrice = domainLogistic.ShippingPrice;
            maritimeLogistic.Discount = domainLogistic.Discount;
            maritimeLogistic.TotalPrice = domainLogistic.TotalPrice;
            maritimeLogistic.FleetNumber = domainLogistic.FleetNumber;
            maritimeLogistic.GuideNumber = domainLogistic.GuideNumber;
            maritimeLogistic.ClientId = domainLogistic.ClientId;

            await _maritimeLogisticRepository.Update(maritimeLogistic);

            response.SetCode(HttpStatusCode.OK);
            response.SetData(true);
            response.AddMessage("Logistica maritima actualizada exitosamente");
            return response;
        }

        public async Task<ResponseViewModel<bool>> DeleteAsync(int id)
        {
            ResponseViewModel<bool> response = new ResponseViewModel<bool>(HttpStatusCode.BadRequest);
            response.SetData(false);

            var maritimeLogistic = await _maritimeLogisticRepository.Get(id);

            if (maritimeLogistic == null)
            {
                response.AddMessage("Logistica maritima no existe");
            }

            if (response.Messages.Any())
            {
                return response;
            }

            await _maritimeLogisticRepository.Delete(id);

            response.SetCode(HttpStatusCode.OK);
            response.SetData(true);
            response.AddMessage("Logistica maritima eliminada exitosamente");
            return response;
        }

        public async Task<ResponseViewModel<List<MaritimeLogisticViewModel>>> GetAllAsync()
        {
            var response = new ResponseViewModel<List<MaritimeLogisticViewModel>>(HttpStatusCode.BadRequest);

            var maritimeLogistics = await _maritimeLogisticRepository.GetAll();
            
            var maritimeLogisticsReturn = new List<MaritimeLogisticViewModel>();

            maritimeLogistics.ForEach(maritimeLogistic => 
            {
                maritimeLogisticsReturn.Add(new MaritimeLogisticViewModel
                {
                    MaritimeLogisticsId = maritimeLogistic.MaritimeLogisticsId,
                    ProductTypeId = maritimeLogistic.ProductTypeId,
                    Quantity = maritimeLogistic.Quantity,
                    RegistrationDate = maritimeLogistic.RegistrationDate,
                    DeliveryDate = maritimeLogistic.DeliveryDate,
                    PortId = maritimeLogistic.PortId,
                    ShippingPrice = maritimeLogistic.ShippingPrice,
                    Discount = maritimeLogistic.Discount,
                    TotalPrice = maritimeLogistic.TotalPrice,
                    FleetNumber = maritimeLogistic.FleetNumber,
                    GuideNumber = maritimeLogistic.GuideNumber,
                    ClientId = maritimeLogistic.ClientId
                });
            });

            response.SetCode(HttpStatusCode.OK);
            response.SetData(maritimeLogisticsReturn);

            return response;
        }

        public async Task<ResponseViewModel<MaritimeLogisticViewModel>> GetAsync(int id)
        {
            var response = new ResponseViewModel<MaritimeLogisticViewModel>(HttpStatusCode.BadRequest);

            var maritimeLogistic = await _maritimeLogisticRepository.Get(id);

            if (maritimeLogistic == null)
            {
                response.AddMessage("Logistica maritima no existe");
            }

            if (response.Messages.Any())
            {
                return response;
            }

            MaritimeLogisticViewModel maritimeLogisticReturn = new MaritimeLogisticViewModel
            {
                MaritimeLogisticsId = maritimeLogistic.MaritimeLogisticsId,
                ProductTypeId = maritimeLogistic.ProductTypeId,
                Quantity = maritimeLogistic.Quantity,
                RegistrationDate = maritimeLogistic.RegistrationDate,
                DeliveryDate = maritimeLogistic.DeliveryDate,
                PortId = maritimeLogistic.PortId,
                ShippingPrice = maritimeLogistic.ShippingPrice,
                Discount = maritimeLogistic.Discount,
                TotalPrice = maritimeLogistic.TotalPrice,
                FleetNumber = maritimeLogistic.FleetNumber,
                GuideNumber = maritimeLogistic.GuideNumber,
                ClientId = maritimeLogistic.ClientId
            };

            response.SetCode(HttpStatusCode.OK);
            response.SetData(maritimeLogisticReturn);

            return response;
        }

    }
}
