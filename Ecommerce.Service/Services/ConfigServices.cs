using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Ecommerce.Service.Interface;
using Ecommerce.Repository;
using Ecommerce.Repository.Interfaces;
using System.Linq.Expressions;
using System.Linq;
using Ecommerce.Domain.Models;
using Ecommerce.Service.Services;

namespace Ecommerce.Core.Services
{
    public class ConfigService : EcommerceServices<Config>, IConfigService
    {
        private readonly IConfigRepository _configRepository;
        private readonly IMapper _mapper;


        public ConfigService(IConfigRepository configRepository, IMapper mapper) : base(configRepository)
        {
            _configRepository = configRepository;
            _mapper = mapper;
        }
    }
}