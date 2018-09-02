using Autofac.Integration.WebApi;
using Microsoft.Owin;
using Nop.Core.Infrastructure;
using Nop.Services.Logging;
using Owin;
using System;
using System.Web.Http;

[assembly: OwinStartup(typeof(Assesment.WebApi.Startup))]

namespace Assesment.WebApi
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            //log application start
            try
            {
                // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=316888
                ConfigureAuth(app);

                EngineContext.Initialize(false);

                HttpConfiguration config = GlobalConfiguration.Configuration;
                config.DependencyResolver = new AutofacWebApiDependencyResolver(EngineContext.Current.ContainerManager.Container);

                WebApiConfig.Register(config);

                app.UseAutofacWebApi(config);
                app.UseWebApi(config);

                //log
                var logger = EngineContext.Current.Resolve<ILogger>();
                logger.Information("Application started", null, null);

                config.EnsureInitialized();

            }
            catch (Exception)
            {
                //don't throw new exception if occurs
            }
        }

        private static void ConfigureAuth(IAppBuilder app)
        {
        }
    }
}
