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

            builder.HasOne(s => s.SERVICE_TYPE)
                .WithMany(g => g.CATEGORIES)
                .HasForeignKey(s => s.SERVICE_TYPE_ID);
            builder.HasOne(s => s.CLIENT)
                .WithMany(g => g.CATEGORIES)
                .HasForeignKey(s => s.CLIENT_ID);
            builder.HasOne(s => s.PARENT_CATEGORY)
                .WithMany(g => g.CHILD_CATEGORY)
                .HasForeignKey(s => s.CATEGORY_PARENT_ID)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.SetNull);
            base.Configure(builder);
        }
    }
}
