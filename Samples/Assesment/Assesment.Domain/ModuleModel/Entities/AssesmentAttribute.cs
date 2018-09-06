using Assesment.Domain.ModuleModel.Entities;
using EventFlow.Core;
using EventFlow.Entities;
using EventFlow.ValueObjects;
using Newtonsoft.Json;

namespace Assesment.Domain.ModuleModel
{
    [JsonConverter(typeof(SingleValueObjectConverter))]
    public class AssesmentAttributeId : Identity<AssesmentAttributeId>
    {
        public AssesmentAttributeId(string value) : base(value)
        {
        }
    }

    public class AssesmentAttribute : Entity<AssesmentAttributeId>
    {
        public AssesmentAttribute(AssesmentAttributeId id, Name name, Code code) : base(id)
        {
            //ChecklistId = checklistId;
            Name = name;
            Code = code;
        }

        //public AssesmentChecklistId ChecklistId { get; }
        public Name Name { get; }
        public Code Code { get; }
    }
}
