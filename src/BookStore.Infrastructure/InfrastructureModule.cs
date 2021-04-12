using System.Collections.Generic;
using System.Reflection;
using Autofac;
using BookStore.Core;
using BookStore.Infrastructure.Data;
using BookStore.SharedKernel.Interfaces;

namespace BookStore.Infrastructure
{
    public class InfrastructureModule : Autofac.Module
    {
        private List<Assembly> _assemblies = new List<Assembly>();

        public InfrastructureModule(Assembly callingAssembly = null)
        {
            var coreAssembly = Assembly.GetAssembly(typeof(DatabasePopulator));
            var infrastructureAssembly = Assembly.GetAssembly(typeof(EfRepository));

            _assemblies.Add(coreAssembly);
            _assemblies.Add(infrastructureAssembly);
            if (callingAssembly != null)
            {
                _assemblies.Add(callingAssembly);
            }
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder
                .RegisterAssemblyTypes(_assemblies.ToArray())
                .AsImplementedInterfaces();

            builder.RegisterType<EfRepository>().As<IRepository>()
                .InstancePerLifetimeScope();
        }
    }
}