using AutoMapper;
using Ecommerce.Core.Services;
using Ecommerce.Domain.Models;
using Ecommerce.Repository.Interfaces;
using Ecommerce.Service.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.Service.Services
{
    public class UserProfileService : EcommerceServices<UserProfile>, IUserProfileService
    {
        private readonly IUserProfileRepository _userprofileRepository;
        private readonly IMapper _mapper;

        public UserProfileService(IUserProfileRepository userProfileRepository, IMapper mapper) : base(userProfileRepository)
        {
            _userprofileRepository = userProfileRepository;
            _mapper = mapper;
        }

        void IUserProfileService.Delete(Guid id)
        {
            throw new NotImplementedException();
        }
        void IUserProfileService.Create(UserProfile profile)
        {
            throw new NotImplementedException();
        }


    }

    
}
