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
    public partial class CLIENT_MAP : NopEntityTypeConfiguration<CLIENT>
    {
        public override void Configure(EntityTypeBuilder<CLIENT> builder)
        {
            builder.ToTable("CLIENT");
            builder.HasKey(c => c.ID);

            base.Configure(builder);
        }
    }
}
