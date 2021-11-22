﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Myrmica.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Myrmica.Data.Mapping
{
    public partial class NEWS_MAP : NopEntityTypeConfiguration<NEWS>
    {
        public override void Configure(EntityTypeBuilder<NEWS> builder)
        {
            builder.ToTable("NEWS");
            builder.HasKey(c => c.ID);

            base.Configure(builder);
        }
    }
}
