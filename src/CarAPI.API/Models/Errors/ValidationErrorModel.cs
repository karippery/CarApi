using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarAPI.API.Models.Errors
{
    public class ValidationErrorModel
    {
        public string ErrorMessage { get; set; }
        public int StatusCode { get; set; }
    }
}
