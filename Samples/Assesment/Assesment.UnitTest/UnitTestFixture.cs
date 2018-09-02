//using Autofac;
//using Autofac.Extensions.DependencyInjection;
//using Edukasi.EntityFrameworkCore;
//using EventFlow;
//using EventFlow.Autofac.Extensions;
//using EventFlow.Extensions;
//using EventFlow.MsSql;
//using EventFlow.MsSql.Extensions;
//using EventFlow.RabbitMQ;
//using EventFlow.RabbitMQ.Extensions;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.Extensions.DependencyInjection;
using Autofac;
using Nop.Core.Infrastructure;
using System;
//using Xunit;

namespace Assesment.UnitTest
{
    public class UnitTestFixture: IDisposable
    {
        public IContainer SP { get; }
        //public static string ConnectionString => "Server=(LocalDb)\\MSSQLLocalDB;Database=EduSchool.Dev;Trusted_Connection=True;MultipleActiveResultSets=true";

        public void Dispose()
        {
        }

        public UnitTestFixture()
        {
            //var services = new ServiceCollection();

            //services.AddDbContext<AppDbContext>(builder =>
            //{
            //    builder
            //        .UseSqlServer(ConnectionString, providerOptions => providerOptions.CommandTimeout(60))
            //        .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            //});

            //services.AddApplicationServices();

            //services.AddEventFlow(opt =>
            //{
            //    opt
            //    .ConfigureMsSql(MsSqlConfiguration.New.SetConnectionString("Server=(LocalDb)\\MSSQLLocalDB;Database=EduSchool.Dev;Trusted_Connection=True;MultipleActiveResultSets=true"))
            //    .UseMssqlEventStore()
            //    .ConfigureAggregates()
            //    .ConfigureReadModels();
            //});

            //SP = services.BuildServiceProvider();

            //var container = new ContainerBuilder();

            //var resolver = EventFlowOptions.New
            //    .UseAutofacContainerBuilder(container)
            //    //.PublishToRabbitMq(RabbitMqConfiguration.With(new Uri("amqp://moonlay:moonlay@192.168.99.100/")))
            //    .ConfigureMsSql(MsSqlConfiguration.New.SetConnectionString(ConnectionString))
            //    .UseMssqlEventStore()
            //    .ConfigureAggregates()
            //    .ConfigureReadModels();

            //container.Populate(services);

            EngineContext.Initialize(false);

            SP = EngineContext.Current.ContainerManager.Container;

            //var context = SP.GetService<AppDbContext>();
            //context.Database.Migrate();

            //var dbMigrate = SP.GetService<EventFlow.MsSql.IMsSqlDatabaseMigrator>();
            //EventFlow.MsSql.EventStores.EventFlowEventStoresMsSql.MigrateDatabase(dbMigrate);
        }
    }

    public class TestFor<TSut>
    {
        protected readonly UnitTestFixture Fixture;

        protected TSut Sut { get; }

        public TestFor()
        {
            Fixture = new UnitTestFixture();

            Sut = Fixture.SP.Resolve<TSut>();
        }
    }


}
