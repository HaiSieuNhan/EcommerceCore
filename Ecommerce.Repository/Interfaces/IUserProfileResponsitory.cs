using System;
using System.Collections.Generic;
using System.Text;
using Ecommerce.Domain.Models;
namespace Ecommerce.Repository.Interfaces
{
    public interface IUserProfileResponsitory : IRepository<UserProfile>
    {

        //IEnumerable<User> GetAll();
        //User GetById(int id);
        void Update(UserProfile profile);
        void Delete(Guid id);
    }
}
