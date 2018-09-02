using Assesment.Queries.Module;
using Nop.Data.Mapping;

namespace Assesment.Data.Mapping
{
    public class AssesmentChecklistReadModelMap : NopEntityTypeConfiguration<AssesmentChecklistReadModel>
    {
        public AssesmentChecklistReadModelMap()
        {
            this.ToTable("ReadModel-AssesmentChecklist");
            this.ApplySqlModelConfig();

            this.Property(p => p.Name).HasMaxLength(255).IsRequired();
            this.Property(p => p.ModuleId).HasMaxLength(255).IsRequired();

        }
    }
}
