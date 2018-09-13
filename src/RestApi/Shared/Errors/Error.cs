using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestApi.Shared.Errors
{
    public class Error
    {
        public string Message { get; set; }
        public ErrorDetail[] Details { get; set; }
    }
}
