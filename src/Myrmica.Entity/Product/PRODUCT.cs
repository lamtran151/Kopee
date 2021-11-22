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
    public class PRODUCT : BASE_ENTITY
    {
        public PRODUCT() : base()
        {
        }
        public string NAME { get; set; }
        public double PRICE { get; set; }
        public string ROUTE { get; set; }
        public string SHORT_DESCRIPTION { get; set; }
        public string FULL_DESCRIPTION { get; set; }
        public string CONTENT { get; set; }
        public bool IS_HOT { get; set; }
        public bool IS_NEW { get; set; }
        public bool IS_SPECIAL { get; set; }
        public bool IS_DISCOUNT { get; set; }

        //quan he 1-1 giua product va file
        public Guid? THUMBNAIL_ID { get; set; }
        public Guid? BANNER_ID { get; set; }
        public string SLIDE_IMAGE_IDS { get; set; }
        //khoa ngoai
        public Guid? CATEGORY_ID { get; set; }
        //1 product thuoc 1 category
        public virtual CATEGORY CATEGORY { get; set; }
    }
}
