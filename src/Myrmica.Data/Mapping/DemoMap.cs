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
    public partial class DemoMap : NopEntityTypeConfiguration<Demo>
    {
        public override void Configure(EntityTypeBuilder<Demo> builder)
        {
            builder.ToTable("Demo");
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Name).IsRequired();

            base.Configure(builder);
        }
    }
}
