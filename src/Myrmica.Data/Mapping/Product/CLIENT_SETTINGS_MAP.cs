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
    public partial class CLIENT_SETTINGS_MAP : NopEntityTypeConfiguration<CLIENT_SETTINGS>
    {
        public override void Configure(EntityTypeBuilder<CLIENT_SETTINGS> builder)
        {
            builder.ToTable("CLIENT_SETTINGS");
            builder.HasKey(c => c.ID);

            base.Configure(builder);
        }
    }
}
