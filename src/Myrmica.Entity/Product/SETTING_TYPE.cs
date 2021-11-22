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
    public class SETTING_TYPE : BASE_ENTITY
    {
        public SETTING_TYPE():base()
        {

        }
        public string TITLE { get; set; }
        public virtual ICollection<CLIENT_SETTINGS> CLIENT_SETTINGS { get; set; }
    }
}
