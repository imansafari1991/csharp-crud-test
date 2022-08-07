using Csharp.CRUD.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Csharp.CRUD.Application.Contracts.Persistence;
using Csharp.CRUD.Application.Contracts.Serivces;
using Csharp.CRUD.Application.DTOs.Customers;
using Csharp.CRUD.Application.Features.Customers.Handlers.Commands;
using Csharp.CRUD.Application.Features.Customers.Requests.Commands;
using Csharp.CRUD.Application.Profiles;
using Csharp.CRUD.Domain;
using Csharp.CRUD.Persistence.Repositories;
using Moq;

namespace Csharp.CRUD.Tests.IntegrationTests
{
    public class CreateCustomerCommandTests
    {
        private readonly Mock<ICustomerRepository> _customerRepositoryMock;
        private readonly IMapper _mapper;

        public CreateCustomerCommandTests( )
        {
            _customerRepositoryMock = new Mock<ICustomerRepository>();
            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<CustomerMappingProfile>();
            });
            _mapper = mapperConfig.CreateMapper();
        }

        [Fact]
        public async void Should_Not_Invoke_Add_When_Customer_Is_Duplicate()
        {

            var dbOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase("CustomerDbTest", b => b.EnableNullChecks(false))
                .Options;

            using var context = new ApplicationDbContext(dbOptions);
            var customer1 = Customer.CreateInstance();
            customer1.Id = 1;
            customer1.SetFirstName("Iman");
            customer1.SetLastName("Safari");
            customer1.SetEmail("imansafari33@gmail.com");
            customer1.SetDateOfBirth(new DateTime(1991,05,22));
            customer1.SetPhoneNumber("+989905336854");
            customer1.SetBankAccountAddress("21487997547");
            context.Add(customer1);

            context.SaveChanges();

            var customerRepo = new CustomerRepository(context);
            var customer2 = customer1;
            customer2.Id = 2;
         
            var createCustomerHandler = new CreateCustomerCommandHandler(customerRepo,_mapper);

            CreateCustomerCommand command = new CreateCustomerCommand
            {
                CreateCustomerDto = _mapper.Map<CreateCustomerDto>(customer2)
            };
            await  createCustomerHandler.Handle(command, CancellationToken.None);

            _customerRepositoryMock.Verify(x=>x.Add(It.IsAny<Customer>()),Times.Never);



        }

    }
}
