﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Myrmica.Extensions.Product.Parameters
{
    public class EditClientParams
    {
        public string id { get; set; }
        public string name { get; set; }
    }
}
