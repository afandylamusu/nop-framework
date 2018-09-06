using System.Collections.Generic;
using EventFlow.Core;
using EventFlow.Entities;
using EventFlow.ValueObjects;
using Newtonsoft.Json;

namespace Assesment.Domain.ModuleModel.Entities
{
    [JsonConverter(typeof(SingleValueObjectConverter))]
    public class AssesmentChecklistId : Identity<AssesmentChecklistId>
    {
        public AssesmentChecklistId(string value) : base(value)
        {
        }
    }

    public class AssesmentChecklist : Entity<AssesmentChecklistId>
    {
        public AssesmentChecklist(AssesmentChecklistId id, Name name, Code code) : base(id)
        {
            Name = name;
            Code = code;
            Attributes = new List<AssesmentAttribute>();
        }

        public Name Name { get; }
        public Code Code { get; }
        public List<AssesmentAttribute> Attributes { get; }
    }

    
}
