using Application.Interfaces;
using Application.ViewModels.Response;
using Application.ViewModels.ProductType;
using Infrastructure.Data.Interfaces;
using Infrastructure.Data.Models;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Net;

namespace Application.Services
{
    public class ProductTypeService : IProductTypeService
    {
        private readonly IProductTypeRepository _productTypeRepository;
        public ProductTypeService(IProductTypeRepository productTypeRepository)
        {
            _productTypeRepository = productTypeRepository;
        }

        public async Task<ResponseViewModel<bool>> CreateAsync(CreateProductTypeViewModel model)
        {
            ResponseViewModel<bool> response = new ResponseViewModel<bool>(HttpStatusCode.BadRequest);
            response.SetData(false);

            var productType = await _productTypeRepository.GetByName(model.Name);

            if (productType != null) 
            {
                response.AddMessage("Ya existe un tipo de producto con el mismo nombre");
            }

            if (response.Messages.Any()) 
            {
                return response;
            }

            ProductType createProductType = new ProductType
            {
                Name = model.Name
            };

            await _productTypeRepository.Create(createProductType);

            response.SetCode(HttpStatusCode.OK);
            response.SetData(true);
            response.AddMessage("Tipo de producto agregado exitosamente");
            return response;
        }

        public async Task<ResponseViewModel<bool>> UpdateAsync(int id, ProductTypeViewModel model)
        {
            ResponseViewModel<bool> response = new ResponseViewModel<bool>(HttpStatusCode.BadRequest);
            response.SetData(false);

            var productType = await _productTypeRepository.Get(id);

            if (productType == null)
            {
                response.AddMessage("Tipo de producto no existe");
            }

            if (response.Messages.Any())
            {
                return response;
            }

            productType.Name = model.Name;

            await _productTypeRepository.Update(productType);

            response.SetCode(HttpStatusCode.OK);
            response.SetData(true);
            response.AddMessage("Tipo de producto actualizado exitosamente");
            return response;
        }

        public async Task<ResponseViewModel<bool>> DeleteAsync(int id)
        {
            ResponseViewModel<bool> response = new ResponseViewModel<bool>(HttpStatusCode.BadRequest);
            response.SetData(false);

            var productType = await _productTypeRepository.Get(id);

            if (productType == null)
            {
                response.AddMessage("Tipo de producto no existe");
            }

            if (response.Messages.Any())
            {
                return response;
            }

            await _productTypeRepository.Delete(id);

            response.SetCode(HttpStatusCode.OK);
            response.SetData(true);
            response.AddMessage("Tipo de producto eliminado exitosamente");
            return response;
        }

        public async Task<ResponseViewModel<List<ProductTypeViewModel>>> GetAllAsync()
        {
            var response = new ResponseViewModel<List<ProductTypeViewModel>>(HttpStatusCode.BadRequest);

            var productTypes = await _productTypeRepository.GetAll();
            
            var productTypesReturn = new List<ProductTypeViewModel>();

            productTypes.ForEach(productType => 
            {
                productTypesReturn.Add(new ProductTypeViewModel
                {
                    ProductTypeId = productType.ProductTypeId,
                    Name = productType.Name,
                });
            });

            response.SetCode(HttpStatusCode.OK);
            response.SetData(productTypesReturn);

            return response;
        }

        public async Task<ResponseViewModel<ProductTypeViewModel>> GetAsync(int id)
        {
            var response = new ResponseViewModel<ProductTypeViewModel>(HttpStatusCode.BadRequest);

            var productType = await _productTypeRepository.Get(id);

            if (productType == null)
            {
                response.AddMessage("Tipo de producto no existe");
            }

            if (response.Messages.Any())
            {
                return response;
            }

            ProductTypeViewModel productTypeReturn = new ProductTypeViewModel
            {
                ProductTypeId = productType.ProductTypeId,
                Name = productType.Name
            };

            response.SetCode(HttpStatusCode.OK);
            response.SetData(productTypeReturn);

            return response;
        }

    }
}
