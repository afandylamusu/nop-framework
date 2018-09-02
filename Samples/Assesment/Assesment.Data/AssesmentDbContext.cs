using Assesment.Queries;
using Nop.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assesment.Data
{
    public static class SqlModelEntityTypeConfigExtensions
    {
        public static void ApplySqlModelConfig<TEntity>(this EntityTypeConfiguration<TEntity> builder, bool aggregateIdIsUnique = true)
            where TEntity : SqlReadModel
        {
            builder.HasKey(k => k.Id);

            builder.Property(p => p.AggregateId).HasMaxLength(255).IsRequired();
            if (aggregateIdIsUnique)
                builder.HasIndex(p => p.AggregateId).IsUnique();

            builder.Property(p => p.CreatedBy).HasMaxLength(255).IsRequired();
            builder.Property(p => p.CreatedTime).IsRequired();

            builder.Property(p => p.ModifiedBy).HasMaxLength(255);
            builder.Property(p => p.ModifiedTime);

            builder.Property(p => p.LastAggregateSequenceNumber).IsRequired();

        }
    }

    public  class AssesmentDbContext : NopObjectContext
    {
        public AssesmentDbContext() : base(GetConnectionString())
        {

        }

        public AssesmentDbContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        { }
    }
}
