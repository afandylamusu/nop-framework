using EventFlow.Aggregates.ExecutionResults;
using EventFlow.Commands;
using System.Threading;
using System.Threading.Tasks;

namespace Assesment.Domain.ModuleModel.Commands
{
    public class AddAssesmentChecklistCommand : Command<AssesmentModuleAggregate, AssesmentModuleId>
    {
        public AddAssesmentChecklistCommand(AssesmentModuleId aggregateId, Name name) : base(aggregateId)
        {
            Name = name;
        }

        public Name Name { get; }
    }

    public class AddAssesmentChecklistCommandHandler : CommandHandler<AssesmentModuleAggregate, AssesmentModuleId, IExecutionResult, AddAssesmentChecklistCommand>
    {
        public override Task<IExecutionResult> ExecuteCommandAsync(AssesmentModuleAggregate aggregate, AddAssesmentChecklistCommand command, CancellationToken cancellationToken)
        {
            IExecutionResult result = aggregate.AddChecklist(command.Name);

            return Task.FromResult(result);
        }
    }
}
