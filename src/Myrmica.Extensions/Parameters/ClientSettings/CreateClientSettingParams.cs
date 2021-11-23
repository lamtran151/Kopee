using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Myrmica.Extensions.Product.Parameters
{
    public class CreateClientSettingParams
    {
        public string key { get; set; }
        public string value { get; set; }
        public string clientId { get; set; }
        public string settingTypeId { get; set; }
    }
}
