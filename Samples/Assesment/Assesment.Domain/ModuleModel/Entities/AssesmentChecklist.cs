using EventFlow.Core;
using EventFlow.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assesment.Domain.ModuleModel.Entities
{
    public class AssesmentChecklist : Entity<AssesmentChecklistId>
    {
        public AssesmentChecklist(AssesmentChecklistId id, Name name) : base(id)
        {
            Name = name;
        }

        public Name Name { get; }
    }

    public class AssesmentChecklistId : Identity<AssesmentChecklistId>
    {
        public AssesmentChecklistId(string value) : base(value)
        {
        }
    }
}
