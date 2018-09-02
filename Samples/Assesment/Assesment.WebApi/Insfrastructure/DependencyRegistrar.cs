using Autofac;
using EventFlow;
using EventFlow.Autofac.Extensions;
using EventFlow.MsSql;
using EventFlow.MsSql.Extensions;
using Nop.Core.Configuration;
using Nop.Core.Data;
using Nop.Core.Infrastructure;
using Nop.Core.Infrastructure.DependencyManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Assesment.WebApi.Insfrastructure
{
    public class DependencyRegistrar : IDependencyRegistrar
    {
        public int Order => 1;

        public void Register(ContainerBuilder builder, ITypeFinder typeFinder, NopConfig config)
        {
            var resolver = EventFlowOptions.New
                .UseAutofacContainerBuilder(builder)
                //.PublishToRabbitMq(RabbitMqConfiguration.With(new Uri("amqp://moonlay:moonlay@192.168.99.100/")))
                .ConfigureMsSql(MsSqlConfiguration.New.SetConnectionString(DataSettings.Current.DataConnectionString))
                .UseMssqlEventStore()
                .ConfigureAggregates()
                .ConfigureReadModels();
        }
    }
}