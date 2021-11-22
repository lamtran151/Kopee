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
    public partial class SERVICE_TYPE_MAP : NopEntityTypeConfiguration<SERVICE_TYPE>
    {
        public override void Configure(EntityTypeBuilder<SERVICE_TYPE> builder)
        {
            builder.ToTable("SERVICE_TYPE");
            builder.HasKey(c => c.ID);

            base.Configure(builder);
        }
    }
}
