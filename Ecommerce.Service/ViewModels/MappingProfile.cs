using AutoMapper;
using Ecommerce.Domain.Models;
using Ecommerce.Service.Dto;
using Ecommerce.Service.ViewModels.Header;

namespace Ecommerce.Core.ViewModels
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            MappingEntityToViewModel();
            MappingViewModelToEntity();
        }

        private void MappingEntityToViewModel()
        {
            // case get data
            CreateMap<Category, CategoryViewModel>();
            CreateMap<Supplier, SupplierViewModel>();
            CreateMap<Manufacturer, ManufacturerViewModel>();
            //CreateMap<Product, ProductViewModel>();
            CreateMap<User, UserDto>();
        }

        private void MappingViewModelToEntity()
        {
            // case insert or update
            CreateMap<CategoryDto, Category>();
            CreateMap<SupplierDto, Supplier>();
            CreateMap<ManufacturerDto, Manufacturer>();
            CreateMap<UserDto, User>();

        }
    }
}