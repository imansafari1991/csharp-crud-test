using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Csharp.CRUD.Application.DTOs.Customers;
using Csharp.CRUD.Domain;

namespace Csharp.CRUD.Application.Profiles
{
    public class CustomerMappingProfile:Profile
    {
        public CustomerMappingProfile()
        {
            CreateMap<Customer, CreateCustomerDto>().ReverseMap();
            CreateMap<Customer, UpdateCustomerDto>().ReverseMap();
            CreateMap<Customer, GetCustomerDto>();
           

        }
    }
}
