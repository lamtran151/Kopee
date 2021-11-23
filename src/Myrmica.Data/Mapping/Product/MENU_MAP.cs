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
    public partial class MENU_MAP : NopEntityTypeConfiguration<MENU>
    {
        public override void Configure(EntityTypeBuilder<MENU> builder)
        {
            builder.ToTable("MENU");
            builder.HasKey(c => c.ID);

            builder.HasOne(s => s.PARENT_MENU)
                .WithMany(g => g.CHILD_MENU)
                .HasForeignKey(s => s.PARENT_ID)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.SetNull);

            base.Configure(builder);
        }
    }
}
