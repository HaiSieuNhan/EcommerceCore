using System;
using System.Collections.Generic;
using System.Text;
using Ecommerce.Domain.Models;
namespace Ecommerce.Repository.Interfaces
{
    
    public interface IConfigResponsitory : IRepository<Config>
    {
        Config Authenticate(string key,string code);
        //IEnumerable<User> GetAll();
        //User GetById(int id);
        Config Create(Config config, string code,string value);
        void Update(Config config, string code=null);
        void Delete(Guid id);
    }
}
