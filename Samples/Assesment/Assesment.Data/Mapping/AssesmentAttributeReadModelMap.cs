using Assesment.Queries.Module;
using Nop.Data.Mapping;

namespace Assesment.Data.Mapping
{
    public class AssesmentAttributeReadModelMap : NopEntityTypeConfiguration<AssesmentAttributeReadModel>
    {
        public AssesmentAttributeReadModelMap()
        {
            this.ToTable("ReadModel-AssesmentAttribute");
            this.ApplySqlModelConfig();

            this.Property(p => p.Name).HasMaxLength(255).IsRequired();
            this.Property(p => p.Code).HasMaxLength(64).IsRequired();
            this.Property(p => p.ChecklistId).HasMaxLength(255).IsRequired();
        }
    }
}
