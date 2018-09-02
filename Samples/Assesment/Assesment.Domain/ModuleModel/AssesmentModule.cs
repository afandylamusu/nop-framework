using EventFlow.Entities;

namespace Assesment.Domain.ModuleModel
{
    public class AssesmentModule : Entity<AssesmentModuleId>
    {
        public AssesmentModule(AssesmentModuleId id, Name name, Code code) : base(id)
        {
            Name = name;
            Code = code;
        }

        public Name Name { get; }
        public Code Code { get; }
    }
}