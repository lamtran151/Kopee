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
    public partial class CONTACT_MAP : NopEntityTypeConfiguration<CONTACT>
    {
        public override void Configure(EntityTypeBuilder<CONTACT> builder)
        {
            builder.ToTable("CONTACT");
            builder.HasKey(c => c.ID);

            base.Configure(builder);
        }
    }
}
