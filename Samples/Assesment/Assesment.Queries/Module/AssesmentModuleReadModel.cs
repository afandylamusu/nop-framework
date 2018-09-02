using Assesment.Domain.ModuleModel;
using Assesment.Domain.ModuleModel.Events;
using EventFlow.Aggregates;
using EventFlow.ReadStores;

namespace Assesment.Queries.Module
{
    public class AssesmentModuleReadModel : SqlReadModel,
      IAmReadModelFor<AssesmentModuleAggregate, AssesmentModuleId, OnAssesmentModuleCreated>
    {
        public string Name { get; set; }
        public string Code { get; set; }

        public void Apply(IReadModelContext context, IDomainEvent<AssesmentModuleAggregate, AssesmentModuleId, OnAssesmentModuleCreated> domainEvent)
        {
            this.Name = domainEvent.AggregateEvent.AssesmentModule.Name.Value;
            this.Code = domainEvent.AggregateEvent.AssesmentModule.Code.Value;

            this.AggregateId = domainEvent.AggregateIdentity.Value;
            this.CreatedTime = domainEvent.Timestamp;
            this.CreatedBy = domainEvent.AggregateEvent.User;
            this.LastAggregateSequenceNumber = domainEvent.AggregateSequenceNumber;
        }
    }
}
