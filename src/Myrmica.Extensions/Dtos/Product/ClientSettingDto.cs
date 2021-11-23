using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Myrmica.Extensions.Dtos.Product
{
    public class ClientSettingDto
    {
        public string id { get; set; }
        public string key { get; set; }
        public string value { get; set; }
        public string clientId { get; set; }
        public string settingTypeId { get; set; }
    }
}
