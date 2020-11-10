using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Ecommerce.Service.Interface;
using AutoMapper;
using Ecommerce.Portal.Infrastructure.Wrappers;
using Ecommerce.Domain.Models;
using Ecommerce.Service.ViewModels.Header;
using Ecommerce.Service.Dto;
using Ecommerce.Portal.Infrastructure.Extensions;

namespace Ecommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SupplierController : ControllerBase
    {
        private readonly ISupplierServices _supplierServices;
        private readonly IMapper _mapper;
        public SupplierController(ISupplierServices supplierServices, IMapper mapper)
        {
            _supplierServices = supplierServices;
            _mapper = mapper;
        }
        
        [HttpGet("GetSupplier")]
        public async Task<ApiResponse> GetSuppliers()
        {
            var suppliers = await _supplierServices.GetAllAsync();
            if (suppliers != null && suppliers.Any())
            {
                var result = _mapper.Map<List<SupplierViewModel>>(suppliers);
                return new ApiResponse("All supplier item", result, 200);
            }
            return new ApiResponse("No Item", null, 200);
        }
        [HttpGet("get-supplier-by-id/{id}")]
        public async Task<ApiResponse> GetCategoryById(Guid id)
        {
            var supplier = await _supplierServices.GetByIdAsync(id);
            if (supplier != null)
            {
                var result = _mapper.Map<SupplierViewModel>(supplier);
                return new ApiResponse("All supplier Detail", result, 200);
            }
            return new ApiResponse("No item", null, 200);
        }
        [HttpDelete("delete-supplier-by-id/{id}")]
        public async Task<ApiResponse> DeleteSupplier(Guid id)
        {
            var supplier = await _supplierServices.GetByIdAsync(id);
            if (supplier != null)
            {
                await _supplierServices.DeleteAsync(supplier);
                return new ApiResponse("Removed Item", 200);
            }
            return new ApiResponse("Can't delete item", null, 200);
        }
        [HttpPost("create-or-edit-supplier")]
        public async Task<ApiResponse> CreateOrEditSupplier(SupplierDto dto)
        {
            if (!ModelState.IsValid)
            {
                throw new ApiException(ModelState.AllErrors());
            }
            // Case insert
            if (!dto.Id.HasValue)
            {
                var supplier = _mapper.Map<Supplier>(dto);
                supplier.UpdatedDate = null;
                await _supplierServices.AddAsync(supplier);
                return new ApiResponse("New record has been created to the database", dto, 201);
            }

            var supplierOld = await _supplierServices.GetByIdAsync(dto.Id.Value);
            if (supplierOld != null)
            {
                var newSupplier = _mapper.Map(dto, supplierOld);
                newSupplier.UpdatedDate = DateTime.Now;
                await _supplierServices.UpdateAsync(newSupplier);
                return new ApiResponse($"Record has been updated with id {dto.Id} to the database", dto, 201);
            }
            throw new ApiException($"Record with id: {dto.Id} does not exist.", 400);
        }
    }
}
