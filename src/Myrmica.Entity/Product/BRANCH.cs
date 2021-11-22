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
    public class BRANCH : BASE_ENTITY
    {
        public string NAME { get; set; }
        public string IMAGE { get; set; }
        public string MAP { get; set; }
        public string ADDRESS { get; set; }
        public Guid CLIENT_ID { get; set; }
        public virtual CLIENT CLIENT { get; set; }
    }
}
