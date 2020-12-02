using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Ecommerce.Common.Infrastructure.ViewModel.Admin.ViewModel;
using Ecommerce.Domain.Models;
namespace Ecommerce.Repository.Interfaces
{
    public interface IUserProfileRepository : IRepository<UserProfile>
    {

        //IEnumerable<User> GetAll();
        //User GetById(int id);
        Task<IList<CustomerAdminViewModel>> GetCustomerListViewModel();
        Task<IList<StaffAdminViewModel>> GetStaffListViewModel();
    }
}
