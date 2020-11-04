using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Ecommerce.Core.Services;
using Ecommerce.Domain.Models;
using Ecommerce.Repository.Interfaces;
using Ecommerce.Service.Dto;
using Ecommerce.Service.Interface;
namespace Ecommerce.Service.Services
{
    public class ProductRatingService : EcommerceServices<ProductRating>
    {
        private readonly IProductRatingRepository _productratingRepository;
        private readonly IMapper _mapper;

        public ProductRatingService(IProductRatingRepository productratingRepository, IMapper mapper) : base(productratingRepository)
        {
            _productratingRepository = productratingRepository;
            _mapper = mapper;
        }
    }
}
