using AutoMapper;
using Ecommerce.Common.Infrastructure.ViewModel.Admin.ViewModel;
using Ecommerce.Core.Services;
using Ecommerce.Domain.Models;
using Ecommerce.Repository.Interfaces;
using Ecommerce.Service.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Service.Services
{
    public class UserProfileService : EcommerceServices<UserProfile>, IUserProfileService
    {
        private readonly IUserProfileRepository _userProfileRepository;
        private readonly IMapper _mapper;


        public UserProfileService(IUserProfileRepository userProfileRepository, IMapper mapper) : base(userProfileRepository)
        {
            _userProfileRepository = userProfileRepository;
            _mapper = mapper;
        }


        public async Task<IList<CustomerAdminViewModel>> GetCustomerListViewModel()
        {
            var customerlist = await _userProfileRepository.GetCustomerListViewModel();
            return customerlist;
        }

        public async Task<IList<StaffAdminViewModel>> GetStaffListViewModel()
        {
            var stafflist = await _userProfileRepository.GetStaffListViewModel();
            return stafflist;
        }


    }

    
}
