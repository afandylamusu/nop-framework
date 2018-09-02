using EventFlow.Aggregates.ExecutionResults;
using EventFlow.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Assesment.Domain.ModuleModel.Commands
{
    public class UpdateAssesmentModuleCommand : Command<AssesmentModuleAggregate, AssesmentModuleId>
    {
        public UpdateAssesmentModuleCommand(AssesmentModuleId aggregateId, Name name) : base(aggregateId)
        {
            Name = name;
        }

        public Name Name { get; }
    }

    public class UpdateAssesmentModuleCommandHandler : CommandHandler<AssesmentModuleAggregate, AssesmentModuleId, IExecutionResult, UpdateAssesmentModuleCommand>
    {
        public override Task<IExecutionResult> ExecuteCommandAsync(AssesmentModuleAggregate aggregate, UpdateAssesmentModuleCommand command, CancellationToken cancellationToken)
        {
            IExecutionResult result = aggregate.Update(command.Name);

            return Task.FromResult(result);
        }
    }
}
