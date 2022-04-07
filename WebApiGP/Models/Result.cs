using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiGP.Models
{
    public class Result
    {
        internal Result(bool succeeded, string error)
        {
            Succeeded = succeeded;
            Error = error;
        }

        internal Result(bool succeeded, object data)
        {
            Succeeded = succeeded;
            Data = data;
        }

        public object Data { get; set; }

        public bool Succeeded { get; set; }

        public string Error { get; set; }

        public static Result Success()
        {
            return new Result(true, string.Empty);
        }

        public static Result Success(object data)
        {
            return new Result(true, data);
        }

        public static Result Failure(string error = "")
        {
            return new Result(false, error);
        }
    }
}
