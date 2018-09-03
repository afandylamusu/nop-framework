using EventFlow.Entities;

namespace Assesment.Domain.ModuleModel
{
    public class AssesmentModule : Entity<AssesmentModuleId>
    {
        public AssesmentModule(AssesmentModuleId id, Name name, Code code, Description description = null) : base(id)
        {
            Name = name;
            Code = code;
            Description = description;
        }

        public Name Name { get; }
        public Code Code { get; }
        public Description Description { get; }
    }
}