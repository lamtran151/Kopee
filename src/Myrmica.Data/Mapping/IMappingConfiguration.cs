using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Myrmica.Data.Mapping
{
    /// <summary>
    /// Represents database context model mapping configuration
    /// </summary>
    public partial interface IMappingConfiguration
    {
        /// <summary>
        /// Apply this mapping configuration
        /// </summary>
        /// <param name="modelBuilder">The builder being used to construct the model for the database context</param>
        void ApplyConfiguration(ModelBuilder modelBuilder);
    }
}
