using System;
using Assesment.Domain.ModuleModel.Events;
using Assesment.Domain.ModuleModel.States;
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
        private readonly AssesmentModuleState _state = new AssesmentModuleState();

        public Name ModuleName => _state.ModuleName;
        public Code Code => _state.Code;

        public AssesmentModuleAggregate(AssesmentModuleId id, IUserEvent userEvent) : base(id)
        {
            Register(_state);
            _userEvent = userEvent;
        }

        internal IExecutionResult Create(Name name, Code code)
        {
            Emit(new OnAssesmentModuleCreated(new AssesmentModule(Id, name, code)) { User = _userEvent.User });
            return ExecutionResult.Success();
        }
    }

    
}
