using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Ecommerce.Domain.Models;
using Ecommerce.Repository.Interfaces;
using Ecommerce.Service.Dto;
using Ecommerce.Service.Interface;

namespace Ecommerce.Service.Services
{
    public class UserService : EcommerceServices<User>, IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public UserService(IUserRepository userRepository, IMapper mapper) : base(userRepository)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public User Authenticate(string username, string password)
        {
            return _userRepository.Authenticate(username, password);
        }

        public User Create(UserDto userDto, string password)
        {
            var user = _mapper.Map<User>(userDto);
            return _userRepository.Create(user, password);
        }

        public void Delete(Guid id)
        {
            _userRepository.Delete(id);
        }

        public void Update(UserDto userDto, string password = null)
        {
            var user = _mapper.Map<User>(userDto);
            _userRepository.Update(user, password);
        }
    }
}
