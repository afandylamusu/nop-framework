﻿using EventFlow.Aggregates.ExecutionResults;
using EventFlow.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Assesment.Domain.ModuleModel.Commands
{
    public class CreateAssesmentModuleCommand : Command<AssesmentModuleAggregate, AssesmentModuleId>
    {
        public CreateAssesmentModuleCommand(AssesmentModuleId aggregateId, Name name, Code code) : base(aggregateId)
        {
            Name = name;
            Code = code;
        }

        public Name Name { get; }
        public Code Code { get; }
    }

    public class CreateAssesmentModuleCommandHandler : CommandHandler<AssesmentModuleAggregate, AssesmentModuleId, IExecutionResult, CreateAssesmentModuleCommand>
    {
        public override Task<IExecutionResult> ExecuteCommandAsync(AssesmentModuleAggregate aggregate, CreateAssesmentModuleCommand command, CancellationToken cancellationToken)
        {
            IExecutionResult result = aggregate.Create(command.Name, command.Code);

            return Task.FromResult(result);
        }
    }
}
