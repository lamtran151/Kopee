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
    public class NEWS : BASE_ENTITY
    {
        public NEWS():base()
        {
        }
        public string TITLE { get; set; }
        public string ROUTE { get; set; }
        public string CONTENT { get; set; }
        public string SHORT_DESCRIPTION { get; set; }
        public string FULL_DESCRIPTION { get; set; }
        public bool IS_SPECIAL { get; set; }
        //quan he 1-1 voi file
        public Guid? BANNER_SPECIAL_ID { get; set; }
        //quan he 1-1 voi file
        public Guid? BANNER_ID { get; set; }
        //quan he 1-nhieu voi category
        public Guid? CATEGORY_ID { get; set; }
        public virtual CATEGORY CATEGORY { get; set; }
    }
}
