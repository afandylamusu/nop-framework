using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assesment.Domain.ModuleModel.Events
{
    public class OnAssesmentModuleUpdated : BaseAggregateEvent<AssesmentModuleAggregate, AssesmentModuleId>
    {
        public OnAssesmentModuleUpdated(AssesmentModule assesmentModule)
        {
            AssesmentModule = assesmentModule;
        }

        public AssesmentModule AssesmentModule { get; }
    }
}
