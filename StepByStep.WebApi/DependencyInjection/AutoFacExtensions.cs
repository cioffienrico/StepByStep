using Autofac;
using StepByStep.Infrastructure.Modules;
using StepByStep.WebApi.Module;

namespace StepByStep.WebApi.DependencyInjection
{
    public static class AutoFacExtensions
    {    
        public static ContainerBuilder AddAutofacRegistration(this ContainerBuilder builder)
        {
            builder.RegisterModule<ApplicationModule>();
            builder.RegisterModule<InfrastructureModule>();
            builder.RegisterModule<WebApiModule>();

            return builder;
        }
    }
}
