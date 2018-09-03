using Assesment.Domain.ModuleModel.Entities;
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
    public class AddAssesmentAttributeCommand : Command<AssesmentModuleAggregate, AssesmentModuleId>
    {
        public AddAssesmentAttributeCommand(AssesmentModuleId aggregateId, AssesmentChecklistId checklistId, AssesmentAttributeId newId, Name name, Code code) : base(aggregateId)
        {
            ChecklistId = checklistId;
            NewId = newId;
            Name = name;
            Code = code;
        }

        public AssesmentChecklistId ChecklistId { get; }
        public AssesmentAttributeId NewId { get; }
        public Name Name { get; }
        public Code Code { get; }
    }

    public class AddAssesmentAttributeCommandHandler : CommandHandler<AssesmentModuleAggregate, AssesmentModuleId, IExecutionResult, AddAssesmentAttributeCommand>
    {
        public override Task<IExecutionResult> ExecuteCommandAsync(AssesmentModuleAggregate aggregate, AddAssesmentAttributeCommand command, CancellationToken cancellationToken)
        {
            IExecutionResult result = aggregate.AddAttribute(command.ChecklistId, command.NewId, command.Name, command.Code);

            return Task.FromResult(result);
        }
    }
}
