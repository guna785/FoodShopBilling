using FoodShopBilling.Domain.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodShopBilling.Application.Interfaces.Repositories
{
    public interface IUnitOfWork<TId> : IDisposable
    {
        //Task CommitAsync();
        IRepositoryAsync<T, TId> Repository<T>() where T : AuditableEntity<TId>;
       
    }
}
