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
    public class CLIENT : BASE_ENTITY
    {
        public CLIENT() : base()
        {
        }
        public string NAME { get; set; }
        public virtual ICollection<CLIENT_SETTINGS> CLIENT_SETTINGS { get; set; }
        public virtual ICollection<CATEGORY> CATEGORIES { get; set; }
        public virtual ICollection<MENU> MENUS { get; set; }
        public virtual ICollection<BRANCH> BRANCHES { get; set; }
        public virtual ICollection<CONTACT> CONTACTS { get; set; }

    }
}
