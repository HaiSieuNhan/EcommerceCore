using Ecommerce.Domain.Models;
using System;
//using System.Collections.Generic;
//using System.Text;
using Ecommerce.Domain;
using System.Linq;
using Ecommerce.Repository.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using Ecommerce.Common.Infrastructure.ViewModel.Admin.ViewModel;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Repository
{
    public class UserProfileRepository : BaseRepository<UserProfile>, IUserProfileRepository
    {

        public UserProfileRepository(EcommerceDbContext dbContext) : base(dbContext)
        { }

        public async Task UpdateUserProfile(UserProfile userprofile, string password = null)
        {
            // find user profile
            var user = DbContext.UserProfiles.Find(userprofile.Id);

            if (user != null)
            {
                // update
                userprofile.UpdatedDate = DateTime.Now;
                await UpdateAsync(user);

            }
        }

        public async Task<IList<CustomerAdminViewModel>> GetCustomerListViewModel()
        {
            var customerlist = await (from up in DbContext.UserProfiles
                                      join us in DbContext.Users
                                      on up.UserId equals us.Id
                                      where us.Roles == Role.Customer
                                      select new CustomerAdminViewModel
                                      {
                                          UserName = us.Username,
                                          Name = up.Name,
                                          Gender = up.Gender,
                                          Birthday = up.Birthday,
                                          Phone = up.Phone,
                                          Email = up.Email,
                                          AvatarUrl = up.AvatarUrl,
                                      }).ToListAsync();
            return customerlist;


        }

        public async Task<IList<StaffAdminViewModel>> GetStaffListViewModel()
        {
            var staffList = await (from up in DbContext.UserProfiles
                                   join us in DbContext.Users
                                   on up.UserId equals us.Id
                                   where us.Roles == Role.Staff
                                   select new StaffAdminViewModel
                                   {
                                       UserName = us.Username,
                                       Name = up.Name,
                                       Gender = up.Gender,
                                       Birthday = up.Birthday,
                                       Phone = up.Phone,
                                       Email = up.Email,
                                       AvatarUrl = up.AvatarUrl,
                                   }).ToListAsync();
            return staffList;
        }

      



        //public async Task<ICollection<UserProfile>> ShowUserprofile()
        //{
        //    return await DbContext.Userprofiles.Where(c => c.NSXId == null).ToListAsync();
        //}
    }
}
