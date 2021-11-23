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
    public partial class PRODUCT_MAP : NopEntityTypeConfiguration<PRODUCT>
    {
        public override void Configure(EntityTypeBuilder<PRODUCT> builder)
        {
            builder.ToTable("PRODUCT");
            builder.HasKey(c => c.ID);

            builder.HasOne(p => p.CATEGORY)
                .WithMany(c => c.PRODUCTS)
                .HasForeignKey(p => p.CATEGORY_ID)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.SetNull);

            base.Configure(builder);
        }
    }
}
