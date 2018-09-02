using Autofac;
using EventFlow.Aggregates;
using EventFlow.Extensions;
using EventFlow.Core;
using Nop.Core.Infrastructure;

namespace Assesment.Domain
{
    public abstract class BaseAggregateEvent<TAggregate, TIdentity> : AggregateEvent<TAggregate, TIdentity>, IUserEvent
        where TAggregate : IAggregateRoot<TIdentity>
        where TIdentity : IIdentity
    {
        public string User { get; set; }
    }

    public abstract class BaseAggregateRoot<TAggregate, TIdentity> : AggregateRoot<TAggregate, TIdentity>
        where TAggregate : AggregateRoot<TAggregate, TIdentity>
        where TIdentity : IIdentity
    {
        protected BaseAggregateRoot(TIdentity id) : this(id, EngineContext.Current.ContainerManager.Container) { }

        protected BaseAggregateRoot(TIdentity id, IContainer serviceProvider) : base(id)
        {
            ServiceProvider = serviceProvider;
            UserEvent = serviceProvider.Resolve<IUserEvent>();
        }

        public IContainer ServiceProvider { get; }
        protected IUserEvent UserEvent { get; }
    }
}
