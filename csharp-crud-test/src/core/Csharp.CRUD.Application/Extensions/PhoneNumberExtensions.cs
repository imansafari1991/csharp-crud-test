namespace Csharp.CRUD.Application.Extensions;

public static class PhoneNumberExtensions
{
    public static bool IsValidPhoneNumber(this string value)
    {
        var phoneNumberUtil = PhoneNumbers.PhoneNumberUtil.GetInstance();
      
        var phoneNumber = phoneNumberUtil.Parse(value, null);
        return phoneNumberUtil.IsValidNumber(phoneNumber);
    }
}