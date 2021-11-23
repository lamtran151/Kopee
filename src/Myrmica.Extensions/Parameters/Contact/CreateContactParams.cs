using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Myrmica.Extensions.Product.Parameters
{
    public class CreateContactParams
    {
        public string fullname { get; set; }
        public string phonenumber { get; set; }
        public string email { get; set; }
        public string location { get; set; }
        public string content { get; set; }
        public string clientId { get; set; }
    }
}
