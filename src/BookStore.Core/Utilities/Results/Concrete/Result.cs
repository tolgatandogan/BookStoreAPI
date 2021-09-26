using BookStore.Core.Utilities.Results.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Core.Utilities.Results.Concrete
{
    public partial class Result<T> : IResult<T>
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }

        public Result(bool success, string message, T data)
        {
            Success = success;
            Message = message;
            Data = data;
        }
    }
}