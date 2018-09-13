using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestApi.Shared.Errors
{
    public class ErrorDetail
    {
        public string Target { get; set; }
        public string Message { get; set; }
    }
}
