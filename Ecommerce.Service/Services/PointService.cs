using Ecommerce.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Ecommerce.Service;
using Ecommerce.Service.Dto;
using Ecommerce.Repository.Interfaces;
using AutoMapper;
using Ecommerce.Service.Interface;
using Ecommerce.Core.Services;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System.Linq;

namespace Ecommerce.Service.Services
{
    public class PointService : EcommerceServices<Point>, IPointService
    {
        private readonly IPointRepository _pointRepository;
        private readonly IMapper _mapper;
        public PointService(IPointRepository pointRepository, IMapper mapper) : base(pointRepository)
        {
            _pointRepository = pointRepository;
            _mapper = mapper;
        }

    }
}
