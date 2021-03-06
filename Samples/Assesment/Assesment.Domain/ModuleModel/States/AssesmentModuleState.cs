﻿using Assesment.Domain.ModuleModel.Entities;
using Assesment.Domain.ModuleModel.Events;
using EventFlow.Aggregates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assesment.Domain.ModuleModel.States
{
    public class AssesmentModuleState : AggregateState<AssesmentModuleAggregate, AssesmentModuleId, AssesmentModuleState>,
        IApply<OnAssesmentModuleCreated>,
        IApply<OnAssesmentModuleUpdated>,
        IApply<OnAssesmentChecklistAdded>,
        IApply<OnAssesmentAttributeAdded>
    {
        public Code Code { get; private set; }
        public Name ModuleName { get; private set; }
        public IReadOnlyList<AssesmentChecklist> Checklists { get; private set; }
        public IReadOnlyList<AssesmentAttribute> Attributes { get; private set; }
        public AssesmentModuleStatus ModuleStatus { get; private set; }
        public AssesmentModuleType ModuleType { get; private set; }

        public void Apply(OnAssesmentModuleCreated aggregateEvent)
        {
            Code = aggregateEvent.AssesmentModule.Code;
            ModuleName = aggregateEvent.AssesmentModule.Name;
            ModuleStatus = aggregateEvent.AssesmentModule.Status;
        }

        public void Apply(OnAssesmentModuleUpdated aggregateEvent)
        {
            Code = aggregateEvent.AssesmentModule.Code;
            ModuleName = aggregateEvent.AssesmentModule.Name;
        }

        public void Apply(OnAssesmentChecklistAdded aggregateEvent)
        {
            if (Checklists == null)
            {
                Checklists = new List<AssesmentChecklist>();
            }

            var list = Checklists.ToList();
            list.Add(aggregateEvent.AssesmentChecklist);

            Checklists = list;
        }

        public void Apply(OnAssesmentAttributeAdded aggregateEvent)
        {
            if (Attributes == null)
            {
                Attributes = new List<AssesmentAttribute>();
            }

            var list = Attributes.ToList();
            list.Add(aggregateEvent.AssesmentAttribute);

            Attributes = list;
        }
    }
}
