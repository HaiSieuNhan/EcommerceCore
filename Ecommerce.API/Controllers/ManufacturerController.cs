using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Ecommerce.Service.Interface;
using Microsoft.AspNetCore.Mvc;
using Ecommerce.Portal.Infrastructure.Wrappers;
using Ecommerce.Service.ViewModels.Header;
using System;
using Ecommerce.Service.Dto;
using Ecommerce.Portal.Infrastructure.Extensions;
using Ecommerce.Domain.Models;

namespace Ecommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManufacturerController : ControllerBase
    {
        private readonly IManufacturerServices _manufacturerServices;
        private readonly IMapper _mapper;

        public ManufacturerController(IManufacturerServices manufacturerServices, IMapper mapper)
        {
            _manufacturerServices = manufacturerServices;
            _mapper = mapper;
        }
        [HttpGet("GetManufacturer")]
        public async Task<ApiResponse> GetManufacturer()
        {
            var manufacturer = await _manufacturerServices.GetAllAsync();
            if (manufacturer != null && manufacturer.Any())
            {
                var result = _mapper.Map<List<ManufacturerViewModel>>(manufacturer);
                return new ApiResponse("All Manufacturer items", result, 200);
            }
            return new ApiResponse("No item", null, 200);
        }
        [HttpGet("Get-manufacturer-by-id/{id}")]
        public async Task<ApiResponse> GetManufacturerById(Guid id)
        {
            var manufacturer = await _manufacturerServices.GetByIdAsync(id);
            if (manufacturer != null)
            {
                var result = _mapper.Map<ManufacturerViewModel>(manufacturer);
                return new ApiResponse("All manufacturer Detail", result, 200);
            }
            return new ApiResponse("No item", null, 200);
        }
        [HttpDelete("delete-manufacturer-by-id/{id}")]
        public async Task<ApiResponse> DeleteManufacturer(Guid id)
        {
            var manufacturer = await _manufacturerServices.GetByIdAsync(id);
            if (manufacturer != null)
            {
                await _manufacturerServices.DeleteAsync(manufacturer);
                return new ApiResponse("Removed Item", 200);
            }
            return new ApiResponse("Can't delete item", null, 200);
        }
        [HttpPost("manufacturer-or-edit-category")]
        public async Task<ApiResponse> ManufacturerOrEditCategory(ManufacturerDto dto)
        {
            if (!ModelState.IsValid)
            {
                throw new ApiException(ModelState.AllErrors());
            }
            // Case insert
            if (!dto.Id.HasValue)
            {
                var manufacturer = _mapper.Map<Manufacturer>(dto);
                manufacturer.UpdatedDate = null;
                await _manufacturerServices.AddAsync(manufacturer);
                return new ApiResponse("New record has been created to the database", dto, 201);
            }

            var manufacturerOld = await _manufacturerServices.GetByIdAsync(dto.Id.Value);
            if (manufacturerOld != null)
            {
                var newManufacturer = _mapper.Map(dto, manufacturerOld);
                newManufacturer.UpdatedDate = DateTime.Now;
                await _manufacturerServices.UpdateAsync(newManufacturer);
                return new ApiResponse($"Record has been updated with id {dto.Id} to the database", dto, 201);
            }
            throw new ApiException($"Record with id: {dto.Id} does not exist.", 400);
        }
    }
}
