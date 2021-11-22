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
    public class CATEGORY : BASE_ENTITY
    {
        public CATEGORY() : base()
        {
        }

        public string NAME { get; set; }
        public string ROUTE { get; set; }

        //PARENT_CATEGORY
        public Guid? CATEGORY_PARENT_ID { get; set; }
        public virtual CATEGORY PARENT_CATEGORY { get; set; }

        //quan he 1-1 1 category - co 1 file banner
        public Guid? BANNER_ID { get; set; }

        public Guid? CLIENT_ID { get; set; }
        public virtual CLIENT CLIENT { get; set; }

        //quan he 1-n  voi service Type
        public Guid? SERVICE_TYPE_ID { get; set; }
        public virtual SERVICE_TYPE SERVICE_TYPE { get; set; }

        //CHILD CATEGORY
        public virtual ICollection<CATEGORY> CHILD_CATEGORY { get; set; }
        //1 category co the chua nhieu product
        public virtual ICollection<PRODUCT> PRODUCTS { get; set; }
        //1 category co the chua nhieu news
        public virtual ICollection<NEWS> NEWS { get; set; }
    }

}
