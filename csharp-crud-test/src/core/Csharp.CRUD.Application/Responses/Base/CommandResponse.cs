using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;

namespace Csharp.CRUD.Application.Responses.Base
{
    public class CommandResponse
    {
        public CommandResponse()
        {

        }

        public object Id { get; set; }
        public object Data { get; set; }
        public bool Success { get; set; } = false;
        public string StatusCode { get; set; }
        public string Message { get; set; }

        public List<ValidationFailure> Errors { get; set; }
    }

    public class Success : CommandResponse
    {
        public Success()
        {
            Success = true;
            Message = "Operation is done Successfully";
            StatusCode = "200";
        }
    }

    public class HasError : CommandResponse
    { 
        public HasError(ValidationResult validationResult)
        {
            Success = validationResult.IsValid;
            Errors = validationResult.Errors.Where(validationFailure => validationFailure != null).ToList();
            Message = validationResult.IsValid ? null : "operation error";
            StatusCode = "400";
        } 
    }

    public class BadRequest : CommandResponse
    {
        public BadRequest()
        {
            Success = false;
            StatusCode = "400";
        }

        public BadRequest(ValidationResult validationResult)
        {
            Success = validationResult.IsValid;
            Errors = validationResult.Errors.Where(validationFailure => validationFailure != null).ToList();
            Message = validationResult.IsValid ? null : "operation error";
            StatusCode = "400";
        } 
    }

    public class ResponseNotFound : CommandResponse
    {
        public ResponseNotFound()
        {
            Success = false;
            Message = "Not found";
            StatusCode = "404";
        }
 
    }
}
