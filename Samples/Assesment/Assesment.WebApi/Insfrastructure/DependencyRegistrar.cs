using Assesment.Data;
using Assesment.Domain;
using Assesment.Services;
using Autofac;
using EventFlow;
using EventFlow.Autofac.Extensions;
using EventFlow.MsSql;
using EventFlow.MsSql.Extensions;
using Nop.Core.Configuration;
using Nop.Core.Data;
using Nop.Core.Infrastructure;
using Nop.Core.Infrastructure.DependencyManagement;
using Nop.Data;

namespace Assesment.WebApi.Insfrastructure
{
    public class DependencyRegistrar : IDependencyRegistrar
    {
        public int Order => 1;

        public void Register(ContainerBuilder builder, ITypeFinder typeFinder, NopConfig config)
        {
            //data layer
            var dataSettingsManager = new DataSettingsManager();
            var dataProviderSettings = dataSettingsManager.LoadSettings();
            builder.Register(c => dataSettingsManager.LoadSettings()).As<DataSettings>();
            builder.Register(x => new EfDataProviderManager(x.Resolve<DataSettings>())).As<BaseDataProviderManager>().InstancePerDependency();
            builder.Register(x => x.Resolve<BaseDataProviderManager>().LoadDataProvider()).As<IDataProvider>().InstancePerDependency();

            if (dataProviderSettings != null && dataProviderSettings.IsValid())
            {
                var efDataProviderManager = new EfDataProviderManager(dataSettingsManager.LoadSettings());
                var dataProvider = efDataProviderManager.LoadDataProvider();
                dataProvider.InitConnectionFactory();
                builder.Register<IDbContext>(c => new AssesmentDbContext(dataProviderSettings.DataConnectionString)).InstancePerLifetimeScope();
            }
            else
            {
                builder.Register<IDbContext>(c => new AssesmentDbContext(dataSettingsManager.LoadSettings().DataConnectionString)).InstancePerLifetimeScope();
            }

            EventFlowOptions.New
                .UseAutofacContainerBuilder(builder)
                //.PublishToRabbitMq(RabbitMqConfiguration.With(new Uri("amqp://moonlay:moonlay@192.168.99.100/")))
                .ConfigureMsSql(MsSqlConfiguration.New.SetConnectionString(DataSettings.Current.DataConnectionString))
                .UseMssqlEventStore()
                .ConfigureAggregates()
                .ConfigureReadModels();


            builder.RegisterType<AssesmentModuleService>().As<IAssesmentModuleService>().InstancePerLifetimeScope();

            builder.Register<IUserEvent>(c => new UserEvent { User = "guest@local.com" });
        }
    }
}