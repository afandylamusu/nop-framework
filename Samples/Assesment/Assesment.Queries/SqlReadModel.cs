using EventFlow.MsSql.ReadStores.Attributes;
using EventFlow.ReadStores;
using Nop.Domain;
using System;

namespace Assesment.Queries
{
    public interface IReadModelTest
    {
        bool IsModeTest { get; set; }
    }

    public interface ISqlReadModel : IReadModel
    {
        string AggregateId { get; set; }
        DateTimeOffset CreatedTime { get; set; }
        string CreatedBy { get; set; }
        DateTimeOffset? ModifiedTime { get; set; }
        string ModifiedBy { get; set; }
        int LastAggregateSequenceNumber { get; set; }
    }

    public class SqlReadModel : BaseEntity, ISqlReadModel
    {
        [MsSqlReadModelIgnoreColumn]
#pragma warning disable CS0108 // Member hides inherited member; missing new keyword
        public long Id { get; set; }
#pragma warning restore CS0108 // Member hides inherited member; missing new keyword

        public string AggregateId { get; set; }
        public DateTimeOffset CreatedTime { get; set; }
        public string CreatedBy { get; set; }
        public DateTimeOffset? ModifiedTime { get; set; }
        public string ModifiedBy { get; set; }
        public int LastAggregateSequenceNumber { get; set; }
    }
}
