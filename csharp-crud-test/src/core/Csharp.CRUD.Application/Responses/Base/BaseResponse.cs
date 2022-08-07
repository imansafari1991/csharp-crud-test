using System;

namespace Csharp.CRUD.Application.Responses.Base
{
    public class BaseResponse<T>
    {
        public T Id { get; set; }
    }
}
