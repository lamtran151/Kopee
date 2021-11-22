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
    public partial class SETTING_TYPE_MAP : NopEntityTypeConfiguration<SETTING_TYPE>
    {
        public override void Configure(EntityTypeBuilder<SETTING_TYPE> builder)
        {
            builder.ToTable("SETTING_TYPE");
            builder.HasKey(c => c.ID);

            base.Configure(builder);
        }
    }
}
