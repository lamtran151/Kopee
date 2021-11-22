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
    public class SERVICE_TYPE : BASE_ENTITY
    {
        public SERVICE_TYPE() : base()
        {
        }
        public string TITLE { get; set; }
        public virtual ICollection<CATEGORY> CATEGORIES { get; set; }
    }
}
