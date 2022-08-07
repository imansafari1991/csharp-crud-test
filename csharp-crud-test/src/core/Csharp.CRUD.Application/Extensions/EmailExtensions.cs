using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Csharp.CRUD.Domain;

namespace Csharp.CRUD.Application.Extensions
{
    public static class EmailExtensions
    {
        public static bool IsValidEmail(this string value)
        {
            return Regex.IsMatch(value, Constants.emailPattern);
        }
    }
}
