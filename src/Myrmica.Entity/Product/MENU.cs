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
    public class MENU : BASE_ENTITY
    {
        public MENU() : base()
        {
        }
        public string TITLE { get; set; }
        public string ROUTE { get; set; }
        public int ORDER { get; set; }
        public int MENU_TYPE_ID { get; set; }

        public Guid? CLIENT_ID { get; set; }
        public virtual CLIENT CLIENT { get; set; }

        public Guid? PARENT_ID { get; set; }
        public virtual MENU PARENT_MENU { get; set; }
        public virtual ICollection<MENU> CHILD_MENU { get; set; }
    }
}
