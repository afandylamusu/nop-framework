using Assesment.Domain.ModuleModel.Entities;

namespace Assesment.Domain.ModuleModel.Events
{
    public class OnAssesmentChecklistAdded : BaseAggregateEvent<AssesmentModuleAggregate, AssesmentModuleId>
    {
        public OnAssesmentChecklistAdded(AssesmentChecklist assesmentChecklist)
        {
            AssesmentChecklist = assesmentChecklist;
        }

        public AssesmentChecklist AssesmentChecklist { get; }
    }
}
