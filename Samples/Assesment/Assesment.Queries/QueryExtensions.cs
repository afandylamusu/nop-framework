using Assesment.Queries.Module;
using EventFlow;
using EventFlow.Extensions;
using EventFlow.MsSql.Extensions;
using System.Reflection;

namespace Assesment
{
    public static class QueryExtensions
    {
        public static Assembly Assembly { get; } = typeof(QueryExtensions).Assembly;

        public static IEventFlowOptions ConfigureReadModels(
            this IEventFlowOptions eventFlowOptions)
        {
            return eventFlowOptions
                .AddQueryHandlers(Assembly)
                .UseMssqlReadModel<AssesmentModuleReadModel>();

        }
    }
}
