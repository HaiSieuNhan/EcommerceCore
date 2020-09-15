using Ecommerce.Domain.Models;
using System;
//using System.Collections.Generic;
//using System.Text;
using Ecommerce.Domain;
using System.Linq;
using Ecommerce.Repository.Interfaces;
using Ecommerce.Common.Infrastructure.Helper;

namespace Ecommerce.Repository
{
    public class UserReponsitory : BaseRepository<User>, IUserReponsitory
    {
        public UserReponsitory(EcommerceDbContext dbContext) : base(dbContext)
        {
        }

        public User Authenticate(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                return null;

            var user = DbContext.Users.SingleOrDefault(x => x.UserName == username);

            // check if username exists
            if (user == null)
                return null;

            // check if password is correct
            if (!AuthenUserHelper.VerifyPasswordHash(password, user.PassWordHash, user.PassWordSalt))
                return null;

            // authentication successful
            return user;
        }

        public User Create(User user, string password)
        {
            if (string.IsNullOrWhiteSpace(password))
                throw new Exception("Password is required");

            if (DbContext.Users.Any(x => x.UserName == user.UserName))
                throw new Exception("UserName \"" + user.UserName + "\" is already taken");

            byte[] passwordHash;
            byte[] passwordSalt;

            AuthenUserHelper.CreatePasswordHash(password, out passwordHash, out passwordSalt);

            user.PassWordHash = passwordHash;
            user.PassWordSalt = passwordSalt;

            DbContext.Users.Add(user);
            DbContext.SaveChanges();

            return user;
        }

        public void Update(User userParam, string password = null)
        {
            var user = DbContext.Users.Find(userParam.Id);

            if (user == null)
                throw new Exception("User not found");

            if (userParam.UserName != user.UserName)
            {
                // username has changed so check if the new username is already taken
                if (DbContext.Users.Any(x => x.UserName == userParam.UserName))
                    throw new Exception("UserName " + userParam.UserName + " is already taken");
            }

            // update user properties
            user.FirstName = userParam.FirstName;
            user.LastName = userParam.LastName;
            user.UserName = userParam.UserName;

            // update password if it was entered
            if (!string.IsNullOrWhiteSpace(password))
            {
                byte[] passwordHash, passwordSalt;
                AuthenUserHelper.CreatePasswordHash(password, out passwordHash, out passwordSalt);

                user.PassWordHash = passwordHash;
                user.PassWordSalt = passwordSalt;
            }

            DbContext.Users.Update(user);
            DbContext.SaveChanges();
        }

        public void Delete(Guid id)
        {
            var user = DbContext.Users.Find(id);
            if (user != null)
            {
                DbContext.Users.Remove(user);
                DbContext.SaveChanges();
            }
        }
    }
}
