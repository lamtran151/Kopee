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
    public partial class CLIENT_SETTINGS_MAP : NopEntityTypeConfiguration<CLIENT_SETTINGS>
    {
        public override void Configure(EntityTypeBuilder<CLIENT_SETTINGS> builder)
        {
            builder.ToTable("CLIENT_SETTINGS");
            builder.HasKey(c => c.ID);

            builder.HasOne(s => s.CLIENT)
                .WithMany(g => g.CLIENT_SETTINGS)
                .HasForeignKey(s => s.CLIENT_ID);
            builder.HasOne(s => s.SETTING_TYPE)
                .WithMany(g => g.CLIENT_SETTINGS)
                .HasForeignKey(s => s.SETTING_TYPE_ID);
            base.Configure(builder);
        }
    }
}
