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
    public partial class BRANCH_MAP : NopEntityTypeConfiguration<BRANCH>
    {
        public override void Configure(EntityTypeBuilder<BRANCH> builder)
        {
            builder.ToTable("BRANCH");
            builder.HasKey(c => c.ID);

            base.Configure(builder);
        }
    }
}
