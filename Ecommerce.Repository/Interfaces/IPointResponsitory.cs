using System;
using System.Collections.Generic;
using System.Text;
using Ecommerce.Domain.Models;
namespace Ecommerce.Repository.Interfaces
{
    public interface IPointResponsitory : IRepository<Point>
    {
        Point Authenticate(Guid Userid);
        //IEnumerable<User> GetAll();
        //User GetById(int id);
        Point Create(Point point);
        void Update(Point point);
        void Delete(Guid id);
    }
}
