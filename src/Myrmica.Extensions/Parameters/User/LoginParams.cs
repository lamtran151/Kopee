using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Myrmica.Extensions.Product.Parameters
{
    public class LoginParams
    {
        public string username { get; set; }
        public string password { get; set; }
    }
}
