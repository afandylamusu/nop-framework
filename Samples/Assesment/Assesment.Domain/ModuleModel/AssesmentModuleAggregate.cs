using System;
using System.Collections.Generic;
using Assesment.Domain.ModuleModel.Entities;
using Assesment.Domain.ModuleModel.Events;
using Assesment.Domain.ModuleModel.States;
using Autofac;
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

    public class AssesmentModuleAggregate : BaseAggregateRoot<AssesmentModuleAggregate, AssesmentModuleId>
    {
        private readonly AssesmentModuleState _state = new AssesmentModuleState();

        public Name ModuleName => _state.ModuleName;
        public Code Code => _state.Code;
        public IReadOnlyList<AssesmentChecklist> Checklists => _state.Checklists;

        public AssesmentModuleAggregate(AssesmentModuleId id) : base(id)
        {
            Register(_state);
        }

        internal IExecutionResult Create(Name name, Code code)
        {
            Emit(new OnAssesmentModuleCreated(new AssesmentModule(Id, name, code)) { User = UserEvent.User });
            return ExecutionResult.Success();
        }

        internal IExecutionResult AddChecklist(Name name)
        {
            Emit(new OnAssesmentChecklistAdded(new AssesmentChecklist(AssesmentChecklistId.New, name)) { User = UserEvent.User });
            return ExecutionResult.Success();
        }

        internal IExecutionResult Update(Name name)
        {
            Emit(new OnAssesmentModuleUpdated(new AssesmentModule(Id, name, this.Code)) { User = UserEvent.User });
            return ExecutionResult.Success();
        }
    }

    
}
