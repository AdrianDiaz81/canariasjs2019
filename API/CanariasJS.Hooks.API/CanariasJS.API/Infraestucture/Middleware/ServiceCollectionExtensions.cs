namespace CanariasJS.API.Infraestucture.Middleware
{
    using Autofac;
    using Autofac.Extensions.DependencyInjection;
    using CanariasJS.Hooks.API.Data;
    using CanariasJS.Hooks.API.Domain;
    using CanariasJS.Hooks.API.Repository;
    using CanariasJS.Hooks.API.Service;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Logging;
    using System;

    public static class ServiceCollectionExtensions
    {
        public static IServiceProvider ConfigureContainer(this IServiceCollection services)
        {
            var builder = new ContainerBuilder();

            builder.Populate(services);
            builder.RegisterType<AvengersService>().As<IAvengersService>();
            builder.RegisterType<AvengerDomain>().As<IAvengerDomain>();
            builder.RegisterType<AvengerRepository>().As<IAvengerRepository>();
            builder.RegisterType<AvengerDbContext>().AsSelf();

            builder.Register(c =>
            {
                ILoggerFactory loggerFactory = new LoggerFactory();
                return loggerFactory.CreateLogger("logger");
            }).As<ILogger>();
            return new AutofacServiceProvider(builder.Build());

        }

    }
}
