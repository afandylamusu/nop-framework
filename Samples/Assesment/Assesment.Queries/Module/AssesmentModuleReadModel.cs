using Assesment.Domain.ModuleModel;
using Assesment.Domain.ModuleModel.Events;
using EventFlow.Aggregates;
using EventFlow.ReadStores;
using Nop.Data;
using System.Linq;

namespace Assesment.Queries.Module
{
    public class AssesmentModuleReadModel : SqlReadModel,
      IAmReadModelFor<AssesmentModuleAggregate, AssesmentModuleId, OnAssesmentModuleCreated>,
      IAmReadModelFor<AssesmentModuleAggregate, AssesmentModuleId, OnAssesmentModuleUpdated>,
      IAmReadModelFor<AssesmentModuleAggregate, AssesmentModuleId, OnAssesmentChecklistAdded>,
      IAmReadModelFor<AssesmentModuleAggregate, AssesmentModuleId, OnAssesmentAttributeAdded>
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

        /// <summary>
        /// Update module
        /// </summary>
        /// <param name="context"></param>
        /// <param name="domainEvent"></param>
        public void Apply(IReadModelContext context, IDomainEvent<AssesmentModuleAggregate, AssesmentModuleId, OnAssesmentModuleUpdated> domainEvent)
        {
            this.Name = domainEvent.AggregateEvent.AssesmentModule.Name.Value;
            this.Code = domainEvent.AggregateEvent.AssesmentModule.Code.Value;

            this.AggregateId = domainEvent.AggregateIdentity.Value;
            this.ModifiedTime = domainEvent.Timestamp;
            this.ModifiedBy = domainEvent.AggregateEvent.User;
            this.LastAggregateSequenceNumber = domainEvent.AggregateSequenceNumber;
        }

        /// <summary>
        /// Add Checklist item into module
        /// </summary>
        /// <param name="context"></param>
        /// <param name="domainEvent"></param>
        public void Apply(IReadModelContext context, IDomainEvent<AssesmentModuleAggregate, AssesmentModuleId, OnAssesmentChecklistAdded> domainEvent)
        {
            var dbContext = context.Resolver.Resolve<IDbContext>();
            var checklistSet = dbContext.Set<AssesmentChecklistReadModel>();

            checklistSet.Add(new AssesmentChecklistReadModel
            {
                ModuleId = domainEvent.AggregateIdentity.Value,
                Name = domainEvent.AggregateEvent.AssesmentChecklist.Name.Value,
                Code = domainEvent.AggregateEvent.AssesmentChecklist.Code.Value,
                AggregateId = domainEvent.AggregateEvent.AssesmentChecklist.Id.Value,
                CreatedTime = domainEvent.Timestamp,
                CreatedBy = domainEvent.AggregateEvent.User,
                LastAggregateSequenceNumber = 1
            });

            dbContext.SaveChanges();

            this.AggregateId = domainEvent.AggregateIdentity.Value;
            this.ModifiedTime = domainEvent.Timestamp;
            this.ModifiedBy = domainEvent.AggregateEvent.User;
            this.LastAggregateSequenceNumber = domainEvent.AggregateSequenceNumber;
        }

        public void Apply(IReadModelContext context, IDomainEvent<AssesmentModuleAggregate, AssesmentModuleId, OnAssesmentAttributeAdded> domainEvent)
        {
            var dbContext = context.Resolver.Resolve<IDbContext>();
            //var checklistSet = dbContext.Set<AssesmentChecklistReadModel>();
            var attributeSet = dbContext.Set<AssesmentAttributeReadModel>();

            //var checklist = checklistSet.First(o => o.AggregateId == domainEvent.AggregateEvent.AssesmentAttribute.ChecklistId.Value);
            //checklist.ModifiedTime = domainEvent.Timestamp;
            //checklist.ModifiedBy = domainEvent.AggregateEvent.User;
            //checklist.LastAggregateSequenceNumber++;

            attributeSet.Add(new AssesmentAttributeReadModel
            {
                //ChecklistId = domainEvent.AggregateEvent.AssesmentAttribute.ChecklistId.Value,
                Name = domainEvent.AggregateEvent.AssesmentAttribute.Name.Value,
                Code = domainEvent.AggregateEvent.AssesmentAttribute.Code.Value,

                AggregateId = domainEvent.AggregateIdentity.Value,
                CreatedTime = domainEvent.Timestamp,
                CreatedBy = domainEvent.AggregateEvent.User,
                LastAggregateSequenceNumber = 1
            });

            dbContext.SaveChanges();

            this.AggregateId = domainEvent.AggregateIdentity.Value;
            this.ModifiedTime = domainEvent.Timestamp;
            this.ModifiedBy = domainEvent.AggregateEvent.User;
            this.LastAggregateSequenceNumber = domainEvent.AggregateSequenceNumber;
        }
    }
}
