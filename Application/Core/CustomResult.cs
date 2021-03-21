using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Core
{
    public class CustomResult<T>
    {
        public bool IsSuccess { get; set; }
        public T Value { get; set; }
        public string Error { get; set; }

        public static CustomResult<T> Success(T value) => new CustomResult<T> { IsSuccess = true, Value = value };
        public static CustomResult<T> Failure(string error) => new CustomResult<T> { IsSuccess = false, Error = error };
    }
}
