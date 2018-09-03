namespace Assesment.Domain.ModuleModel.Events
{
    public class OnAssesmentAttributeAdded : BaseAggregateEvent<AssesmentModuleAggregate, AssesmentModuleId>
    {
        public OnAssesmentAttributeAdded(AssesmentAttribute assesmentAttribute)
        {
            this.AssesmentAttribute = assesmentAttribute;
        }

        public AssesmentAttribute AssesmentAttribute { get; }
    }
}
