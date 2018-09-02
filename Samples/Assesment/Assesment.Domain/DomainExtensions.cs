using EventFlow;
using EventFlow.Aggregates;
using EventFlow.Commands;
using EventFlow.Extensions;
using EventFlow.Provided.Specifications;
using EventFlow.Specifications;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Assesment
{
    
    public static class DomainExtensions
    {
        public static Assembly Assembly { get; } = typeof(DomainExtensions).Assembly;

        public static IEventFlowOptions ConfigureAggregates(
            this IEventFlowOptions eventFlowOptions)
        {
            bool commands(Type f) => f.GetInterfaces().Contains(typeof(ICommand));

            return eventFlowOptions
                .AddEvents(Assembly)
                .AddCommands(Assembly, commands)
                .AddCommandHandlers(Assembly);
        }

        public static T Deserialize<T>(this string json)
        {
            return JsonConvert.DeserializeObject<T>(json, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
        }

        public static string Serialize<T>(this T obj)
        {
            return JsonConvert.SerializeObject(obj);
        }

        public static List<T> ShouldNotEmpty<T>(this IEnumerable<T> collection, string nameOfCollection)
        {
            var list = (collection ?? Enumerable.Empty<T>()).ToList();

            if (!list.Any()) throw new ArgumentException(nameOfCollection);

            return list;
        }
    }

    public static class Specs
    {
        public static ISpecification<IAggregateRoot> AggregateIsNew { get; } = new AggregateIsNewSpecification();
        public static ISpecification<IAggregateRoot> AggregateIsCreated { get; } = new AggregateIsCreatedSpecification();

        private class AggregateIsCreatedSpecification : Specification<IAggregateRoot>
        {
            protected override IEnumerable<string> IsNotSatisfiedBecause(IAggregateRoot obj)
            {
                if (obj.IsNew)
                {
                    yield return $"Aggregate '{obj.Name}' with ID '{obj.GetIdentity()}' is new";
                }
            }
        }
    }
}
