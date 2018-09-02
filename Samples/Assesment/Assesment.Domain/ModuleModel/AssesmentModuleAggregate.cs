using System;
using Assesment.Domain.ModuleModel.Events;
using EventFlow.Aggregates;
using EventFlow.Aggregates.ExecutionResults;
using EventFlow.Core;

namespace Assesment.Domain.ModuleModel
{
    public class AssesmentModuleId : Identity<AssesmentModuleId>
    {
        public AssesmentModuleId(string value) : base(value)
        {
        }
    }

    public class AssesmentModuleAggregate : AggregateRoot<AssesmentModuleAggregate, AssesmentModuleId>
    {
        private readonly IUserEvent _userEvent;

        public AssesmentModuleAggregate(AssesmentModuleId id, IUserEvent userEvent) : base(id)
        {
            _userEvent = userEvent;
        }

        internal IExecutionResult Create(Name name, Code code)
        {
            Emit(new OnModuleCreated(new AssesmentModule(Id, name, code)) { User = _userEvent.User });
            return ExecutionResult.Success();
        }
    }

    
}
