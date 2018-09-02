using EventFlow.Core;
using EventFlow.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assesment.Domain.ModuleModel.Entities
{
    public class Checklist : Entity<ChecklistId>
    {
        public Checklist(ChecklistId id) : base(id)
        {
        }
    }

    public class ChecklistId : Identity<ChecklistId>
    {
        public ChecklistId(string value) : base(value)
        {
        }
    }
}
