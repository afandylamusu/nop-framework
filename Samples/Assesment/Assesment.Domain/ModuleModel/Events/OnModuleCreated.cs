using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assesment.Domain.ModuleModel.Events
{
    public class OnAssesmentModuleCreated : BaseAggregateEvent<AssesmentModuleAggregate, AssesmentModuleId>
    {
        public OnAssesmentModuleCreated(AssesmentModule assesmentModule)
        {
            AssesmentModule = assesmentModule;
        }

        public AssesmentModule AssesmentModule { get; }
    }
}
