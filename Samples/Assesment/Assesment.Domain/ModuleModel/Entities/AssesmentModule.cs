using EventFlow.Entities;

namespace Assesment.Domain.ModuleModel
{
    public class AssesmentModule : Entity<AssesmentModuleId>
    {
        public AssesmentModule(AssesmentModuleId id, Name name, Code code, AssesmentModuleType type, Description description = null) : base(id)
        {
            Name = name;
            Code = code;
            Description = description;
            Type = type;
            Status = AssesmentModuleStatus.Draft;
        }

        public Name Name { get; }
        public Code Code { get; }
        public Description Description { get; }
        public AssesmentModuleType Type { get; }
        public AssesmentModuleStatus Status { get; }
    }
}