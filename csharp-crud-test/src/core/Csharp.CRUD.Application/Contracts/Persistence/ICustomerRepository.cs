using Csharp.CRUD.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp.CRUD.Application.Contracts.Persistence
{
    public interface ICustomerRepository
    {
        Task<Customer?> Get(int id);
        Task<IReadOnlyList<Customer>> GetAll();
        Task<Customer> Add(Customer entity);
        Task Update(Customer entity);
        Task Delete(Customer entity);
        bool IsExists(Customer customer);
        bool IsExists(string email);

    }
}
