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
    public class CLIENT_SETTINGS : BASE_ENTITY
    {
        public CLIENT_SETTINGS() : base()
        {
        }
        public string KEY { get; set; }
        public string VALUE { get; set; }
        //quan he 1-n voi client
        public Guid CLIENT_ID { get; set; }
        public virtual CLIENT CLIENT { get; set; }
        // quan he 1-n voi setting type
        public Guid SETTING_TYPE_ID { get; set; }
        public virtual SETTING_TYPE SETTING_TYPE { get; set; }
    }
}
