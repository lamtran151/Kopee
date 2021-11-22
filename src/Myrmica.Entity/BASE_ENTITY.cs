using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Myrmica.Entity
{
    public abstract partial class BASE_ENTITY
    {
        public BASE_ENTITY()
        {
            CREATED_DATE = DateTime.Now;
            IS_DELETED = false;
            IS_ACTIVE = true;
        }
        /// <summary>
        /// Gets or sets the entity identifier
        /// </summary>
        [Key]
        public Guid ID { get; set; }
        public DateTime CREATED_DATE { get; set; }
        public DateTime? UPDATED_DATE { get; set; }
        public DateTime? DELETED_DATE { get; set; }
        public bool IS_DELETED { get; set; }
        public bool IS_ACTIVE { get; set; }
    }
}
