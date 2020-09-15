using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ecommerce.Domain;
using Ecommerce.Domain.Models;
using Ecommerce.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Repository
{
    public class CategoryReponsitory : BaseRepository<Category>, ICategoryReponsitory
    {

        public CategoryReponsitory(EcommerceDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<ICollection<Category>> GetCategoryParrent()
        {
            return await DbContext.Categories.Where(c => c.ParentId == null).ToListAsync();
        }

        public override async Task<Category> GetByIdAsync(Guid id)
        {
            return await DbContext.Set<Category>().FindAsync(id);
        }
    }
}
