using EventFlow.Aggregates;
using EventFlow.Core;
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


    public class AssesmentAttributeAggregate : AggregateRoot<AssesmentAttributeAggregate, AssesmentAttributeId>
    {
        public AssesmentAttributeAggregate(AssesmentAttributeId id) : base(id)
        {

        }
    }

    
}
