using Ecommerce.Domain.Models;
using System;
//using System.Collections.Generic;
//using System.Text;
using Ecommerce.Domain;
using System.Linq;
using Ecommerce.Repository.Interfaces;
using Ecommerce.Common.Infrastructure.Helper;
using System.Data.Common;
using Castle.Core.Internal;

namespace Ecommerce.Repository
{
    public class UserProfileReponsitory : BaseRepository<UserProfile>, IUserProfileResponsitory
    {
        public UserProfileReponsitory(EcommerceDbContext dbContext) : base(dbContext)
        {
        }

        //public UserProfile Create(User user, string password)
        public UserProfile Create(UserProfile prolife, string Name)
        {

            //byte[] passwordHash;
            //byte[] passwordSalt;

            //AuthenUserHelper.CreatePasswordHash(password, out passwordHash, out passwordSalt);

            //user.PassWordHash = passwordHash;
            //user.PassWordSalt = passwordSalt;

            DbContext.UserProfiles.Add(prolife);
            DbContext.SaveChanges();

            return prolife;
        }

        public void Update(UserProfile userParam)
        {
            var user = DbContext.UserProfiles.Find(userParam.UserId);

            if (user == null)
                throw new Exception("User not found");

            if (userParam.UserId != user.UserId)
            {
                // username has changed so check if the new username is already taken
                if (DbContext.UserProfiles.Any(y => y.UserId == userParam.UserId))
                    throw new Exception("UserName " + userParam.UserId + " is already taken");
            }

            // update user properties
            //user.FirstName = userParam.FirstName;
            //user.LastName = userParam.LastName;
            //user.UserName = userParam.UserName;


            user.Name = userParam.Name;
            user.Email = userParam.Email;
            user.PhoneNumber = userParam.PhoneNumber;
            user.Birthday = userParam.Birthday;

            // update password if it was entered
            

            DbContext.UserProfiles.Update(user);
            DbContext.SaveChanges();
        }

        public void Delete(Guid id)
        {
            var user = DbContext.UserProfiles.Find(id);
            if (user != null)
            {
                DbContext.UserProfiles.Remove(user);
                DbContext.SaveChanges();
            }
        }
    }
}
