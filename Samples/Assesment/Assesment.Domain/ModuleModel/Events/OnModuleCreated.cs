using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assesment.Domain.ModuleModel.Events
{
    public class OnModuleCreated : BaseAggregateEvent<AssesmentModuleAggregate, AssesmentModuleId>
    {
        public OnModuleCreated(AssesmentModule assesmentModule)
        {
            AssesmentModule = assesmentModule;
        }

        public AssesmentModule AssesmentModule { get; }
    }
}
