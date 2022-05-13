using Autofac;
using StepByStep.Infrastructure.Modules;

namespace StepByStep.WebApi.DependencyInjection
{
    public static class AutoFacExtensions
    {    
        public static ContainerBuilder AddAutofacRegistration(this ContainerBuilder builder)
        {
            builder.RegisterModule<ApplicationModule>();
            builder.RegisterModule<InfrastructureModule>();

            return builder;
        }
    }
}
