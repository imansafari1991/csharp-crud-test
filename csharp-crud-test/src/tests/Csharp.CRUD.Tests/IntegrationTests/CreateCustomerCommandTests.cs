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
using Castle.Core.Resource;
using Shouldly;

namespace Csharp.CRUD.Tests.IntegrationTests
{
    public class CreateCustomerCommandTests
    {
        private readonly Mock<ICustomerRepository> _customerRepositoryMock;
        private readonly IMapper _mapper;
        private Customer _customer;
        private readonly ApplicationDbContext _context;
        public CreateCustomerCommandTests()
        {
            var dbOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase("CustomerDbTest", b => b.EnableNullChecks(false))
                .Options;

            _context = new ApplicationDbContext(dbOptions);
            _customerRepositoryMock = new Mock<ICustomerRepository>();
            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<CustomerMappingProfile>();
            });
            _mapper = mapperConfig.CreateMapper();

            _customer = new Customer("Iman", "Safari", new DateTime(1991, 05, 22), "+989905336854",
                "imansafari33@gmail.com", "21487997547");


        }

        [Fact]
        public async void Should_Not_Invoke_Add_When_Customer_Is_Duplicate()
        {
            _context.Add(_customer);

            _context.SaveChanges();

            var customerRepo = new CustomerRepository(_context);
            var customer2 = _customer;
            customer2.Id = 2;

            var createCustomerHandler = new CreateCustomerCommandHandler(customerRepo, _mapper);

            CreateCustomerCommand command = new CreateCustomerCommand
            {
                CreateCustomerDto = _mapper.Map<CreateCustomerDto>(customer2)
            };
            await createCustomerHandler.Handle(command, CancellationToken.None);

            _customerRepositoryMock.Verify(x => x.Add(It.IsAny<Customer>()), Times.Never);



        }

        [Fact]
        public async void Should_Throw_Exception_If_Phonenumber_Is_not_valid()
        {

            var customerRepo = new CustomerRepository(_context);
            var createCustomerHandler = new CreateCustomerCommandHandler(customerRepo, _mapper);
            _customer.PhoneNumber = "+74544447";
            CreateCustomerCommand command = new CreateCustomerCommand
            {
                CreateCustomerDto = _mapper.Map<CreateCustomerDto>(_customer)
            };

            var res = await createCustomerHandler.Handle(command, CancellationToken.None);

            res.Errors.ShouldContain(p => p.ErrorMessage == Constants.PhoneNumberInvalidMessage);

        }

        [Fact]
        public async void Should_Throw_Exception_Phonenumber_Not_Start_with_Valid_Country_Code()
        {

            var customerRepo = new CustomerRepository(_context);
            var createCustomerHandler = new CreateCustomerCommandHandler(customerRepo, _mapper);
            _customer.PhoneNumber = "745";
            CreateCustomerCommand command = new CreateCustomerCommand
            {
                CreateCustomerDto = _mapper.Map<CreateCustomerDto>(_customer)
            };
            var exception= Should.Throw<Exception>(() => createCustomerHandler.Handle(command, CancellationToken.None));
            exception.Message.ShouldBe(Constants.InvalidPhoneNumberRegion);

        }



    }
}
