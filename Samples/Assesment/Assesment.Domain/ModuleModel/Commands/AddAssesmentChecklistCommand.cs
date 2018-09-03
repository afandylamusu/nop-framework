using Assesment.Domain.ModuleModel.Entities;
using EventFlow.Aggregates.ExecutionResults;
using EventFlow.Commands;
using System.Threading;
using System.Threading.Tasks;

namespace Assesment.Domain.ModuleModel.Commands
{
    public class AddAssesmentChecklistCommand : Command<AssesmentModuleAggregate, AssesmentModuleId>
    {
        public AddAssesmentChecklistCommand(AssesmentModuleId aggregateId, AssesmentChecklistId newId, Name name, Code code) : base(aggregateId)
        {
            Name = name;
            Code = code;
            NewId = newId;
        }

        public Name Name { get; }
        public Code Code { get; }
        public AssesmentChecklistId NewId { get; }
    }

    public class AddAssesmentChecklistCommandHandler : CommandHandler<AssesmentModuleAggregate, AssesmentModuleId, IExecutionResult, AddAssesmentChecklistCommand>
    {
        public override Task<IExecutionResult> ExecuteCommandAsync(AssesmentModuleAggregate aggregate, AddAssesmentChecklistCommand command, CancellationToken cancellationToken)
        {
            IExecutionResult result = aggregate.AddChecklist(command.NewId, command.Name, command.Code);

            return Task.FromResult(result);
        }
    }
}
