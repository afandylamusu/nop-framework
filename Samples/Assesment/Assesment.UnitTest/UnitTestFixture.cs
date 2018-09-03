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
using Nop.Data;
using System;
using System.Data.Entity;
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
            EngineContext.Initialize(false);

            SP = EngineContext.Current.ContainerManager.Container;
           
            var dbMigrate = SP.Resolve<EventFlow.MsSql.IMsSqlDatabaseMigrator>();
            EventFlow.MsSql.EventStores.EventFlowEventStoresMsSql.MigrateDatabase(dbMigrate);
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
