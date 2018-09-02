using EventFlow.Aggregates;
using EventFlow.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Assesment.Domain
{
    public abstract class BaseAggregateEvent<TAggregate, TIdentity> : AggregateEvent<TAggregate, TIdentity>, IUserEvent
        where TAggregate : IAggregateRoot<TIdentity>
        where TIdentity : IIdentity
    {
        public string User { get; set; }
    }
}
