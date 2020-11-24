using Ecommerce.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ecommerce.Repository.Interfaces
{
    public interface ICategoryRepository : IRepository<Category>
    {
        Task<ICollection<Category>> GetCategoryParrent();
       


    }
}
