using System;
using System.Collections.Generic;
using System.Text;
using Ecommerce.Domain.Models;

namespace Ecommerce.Repository.Interfaces
{
    public interface IUserReponsitory: IRepository<User>
    {
        User Authenticate(string username, string password);
        //IEnumerable<User> GetAll();
        //User GetById(int id);
        User Create(User user, string password);
        void Update(User user, string password = null);
        void Delete(Guid id);
    } 
}
