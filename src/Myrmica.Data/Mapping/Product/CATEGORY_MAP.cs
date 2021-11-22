using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Myrmica.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Myrmica.Data.Mapping
{
    public partial class CATEGORY_MAP : NopEntityTypeConfiguration<CATEGORY>
    {
        public override void Configure(EntityTypeBuilder<CATEGORY> builder)
        {
            builder.ToTable("CATEGORY");
            builder.HasKey(c => c.ID);

            base.Configure(builder);
        }
    }
}
