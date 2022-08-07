using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Security.Principal;
using System.Text.RegularExpressions;

namespace Csharp.CRUD.Domain;

public class Customer
{
    public int Id { get; set; }
    public string FirstName { get;private set; }
    public string LastName { get;private set; }
    public DateTime DateOfBirth { get;private set; }
    public string PhoneNumber { get; private set; }
    [EmailAddress(ErrorMessage = Constants.InCorrectEmailFormat)]
    public string Email { get; private set; }

    public string BankAccountAddress { get; set; }

    private Customer()
    {

    }
    public static Customer CreateInstance()
    {
        return new Customer();
    }

    public void SetFirstName(string firstName)
    {
        FirstName = firstName;
    }

    public void SetLastName(string lastName)
    {
        LastName=lastName;
    }

    public void SetDateOfBirth(DateTime dateOfBirth)
    {
        if (dateOfBirth > DateTime.Now)
        {
            throw new ArgumentException(Constants.DateOfBirthInvalid);
        }
        DateOfBirth=dateOfBirth;
    }

    public void SetPhoneNumber(string phoneNumber)
    {
        if (phoneNumber.Length > 15)
        {
            throw new ArgumentException(Constants.PhoneNumberInvalidMessage);
        }
        PhoneNumber=phoneNumber;
    }
    public void SetEmail(string email)
    {
        var d=Regex.IsMatch(email, Constants.emailPattern);
        if (!Regex.IsMatch(email, Constants.emailPattern))
        {
            throw new ArgumentException(Constants.InCorrectEmailFormat);
        }
        Email = email;
    }
    public void SetBankAccountAddress(string bankAccountAddress)
    {
        BankAccountAddress = bankAccountAddress;
    }

}