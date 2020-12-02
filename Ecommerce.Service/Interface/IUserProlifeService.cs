using Ecommerce.Common.Infrastructure.ViewModel.Admin.ViewModel;
using Ecommerce.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Service.Interface
{
    public interface IUserProfileService : IServices<UserProfile>
    {
        Task<IList<CustomerAdminViewModel>> GetCustomerListViewModel();
        Task<IList<StaffAdminViewModel>> GetStaffListViewModel();
    }
}
