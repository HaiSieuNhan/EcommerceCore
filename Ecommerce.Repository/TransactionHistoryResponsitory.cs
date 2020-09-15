using Ecommerce.Domain;
using Ecommerce.Domain.Models;
using Ecommerce.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ecommerce.Repository
{
    public class TransactionHistoryResponsitory : BaseRepository<TransactionHistory>, ITransactionHistoryResponsitory
    {
        public TransactionHistoryResponsitory(EcommerceDbContext dbContext) : base(dbContext)
        {

        }
        public Task<ICollection<TransactionHistory>> GetOrdersParrent()
        {
            throw new NotImplementedException();
        }
    }
}
