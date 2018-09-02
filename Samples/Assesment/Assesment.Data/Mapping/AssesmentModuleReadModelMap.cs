using Assesment.Queries.Module;
using Nop.Data.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assesment.Data.Mapping
{
    public class AssesmentModuleReadModelMap : NopEntityTypeConfiguration<AssesmentModuleReadModel>
    {
        public AssesmentModuleReadModelMap()
        {
            this.ToTable("ReadModel-AssesmentModule");
            this.ApplySqlModelConfig();

            this.Property(p => p.Name).HasMaxLength(255).IsRequired();
            this.Property(p => p.Code).HasMaxLength(255).IsRequired();
        }
    }
}
