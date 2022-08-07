using Csharp.CRUD.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shouldly;

namespace Csharp.CRUD.Tests.UnitTests
{
    public class CustomerTests
    {
        private readonly Customer _customer;
        public CustomerTests()
        {
            _customer=Customer.CreateInstance();
        }

        [Fact]
        public void Should_Throw_Exception_When_PhoneNumber_Length_Is_More_Than_15()
        {
            var phoneNumber = "1234567891011125";
            var exception = Should.Throw<ArgumentException>(() => _customer.SetPhoneNumber(phoneNumber));
            exception.Message.ShouldBe(Constants.PhoneNumberInvalidMessage);
        }
        [Fact]
        public void Should_Throw_Exception_When_Email_Format_Is_Invalid()
        {
            
            var exception = Should.Throw<ArgumentException>(() => _customer.SetEmail("iman.gmail.com"));
            exception.Message.ShouldBe(Constants.InCorrectEmailFormat);
        }

        [Fact]
        public void Should_Throw_Exception_When_DateOfBirth_Is_After_Today()
        {

            var exception = Should.Throw<ArgumentException>(() => _customer.SetDateOfBirth(DateTime.Now.AddDays(1)));
            exception.Message.ShouldBe(Constants.DateOfBirthInvalid);
        }
    }
}
