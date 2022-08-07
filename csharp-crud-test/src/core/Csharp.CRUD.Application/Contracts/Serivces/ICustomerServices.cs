using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Csharp.CRUD.Application.Contracts.Persistence;
using Csharp.CRUD.Domain;

namespace Csharp.CRUD.Application.Contracts.Serivces
{
    public interface ICustomerServices
    {


        Task Save(Customer customer);
    }
}
