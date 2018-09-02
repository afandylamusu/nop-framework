using Autofac;
using Nop.Core.Configuration;
using Nop.Core.Infrastructure;
using Nop.Core.Infrastructure.DependencyManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Nop.WebApi.Infrastructure
{
    /// <summary>
    /// 
    /// </summary>
    public class DependencyRegistrar : IDependencyRegistrar
    {
        /// <summary>
        /// 
        /// </summary>
        public int Order => 1;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="typeFinder"></param>
        /// <param name="config"></param>
        public void Register(ContainerBuilder builder, ITypeFinder typeFinder, NopConfig config)
        {

        }
    }
}