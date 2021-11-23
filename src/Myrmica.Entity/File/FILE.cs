using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Myrmica.Entity.File
{
    public class FILE : BASE_ENTITY
    {
        public FILE() : base()
        {
        }

        public string PATH { get; set; }
        public string SAVED_NAME { get; set; }
        public string REAL_NAME { get; set; }
        public int SIZE { get; set; }
        public string FILETYPE { get; set; }
        public string CHECK_SUM { get; set; }
    }
}
