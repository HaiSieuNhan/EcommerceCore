using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Ecommerce.Domain.Models;
using Ecommerce.Repository.Interfaces;
using Ecommerce.Service.Interface;

namespace Ecommerce.Service.Services
{
    public class RoleService : EcommerceServices<Role>, IRoleServices
    {
        private readonly IRoleRepository _roleRepository;
        private readonly IMapper _mapper;


        public RoleService(IRoleRepository roleRepository, IMapper mapper) : base(roleRepository)
        {
            _roleRepository = roleRepository;
            _mapper = mapper;
        }
    }
}
