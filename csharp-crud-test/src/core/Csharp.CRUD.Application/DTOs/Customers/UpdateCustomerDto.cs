using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp.CRUD.Application.DTOs.Customers
{
    public class UpdateCustomerDto:CreateCustomerDto
    {
        public int Id { get; set; }
    }
}
