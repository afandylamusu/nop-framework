using Assesment.Domain.ModuleModel.Entities;
using Assesment.Domain.ModuleModel.Events;
using Assesment.Domain.ModuleModel.States;
using EventFlow.Aggregates.ExecutionResults;
using EventFlow.Core;
using EventFlow.ValueObjects;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Assesment.Domain.ModuleModel
{
    [JsonConverter(typeof(SingleValueObjectConverter))]
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

        internal IExecutionResult AddAttribute(AssesmentChecklistId checklistId, AssesmentAttributeId newId, Name name, Code code)
        {
            Emit(new OnAssesmentAttributeAdded(new AssesmentAttribute(newId, checklistId, name, code)) { User = UserEvent.User });
            return ExecutionResult.Success();
        }

        internal IExecutionResult AddChecklist(AssesmentChecklistId newId, Name name, Code code)
        {
            Emit(new OnAssesmentChecklistAdded(new AssesmentChecklist(newId, name, code)) { User = UserEvent.User });
            return ExecutionResult.Success();
        }

        internal IExecutionResult Update(Name name)
        {
            Emit(new OnAssesmentModuleUpdated(new AssesmentModule(Id, name, this.Code)) { User = UserEvent.User });
            return ExecutionResult.Success();
        }
    }

    
}
