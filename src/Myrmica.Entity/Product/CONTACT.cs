using Myrmica.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Myrmica.Entity
{
    public class CONTACT : BASE_ENTITY
    {
        public string FULLNAME { get; set; }
        public string PHONENUMBER { get; set; }
        public string EMAIL { get; set; }
        public string LOCATION { get; set; }
        public string CONTENT { get; set; }
        public Guid CLIENT_ID { get; set; }
        public virtual CLIENT CLIENT { get; set; }
    }
}
