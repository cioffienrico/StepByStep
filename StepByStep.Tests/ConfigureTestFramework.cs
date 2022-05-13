using Autofac;
using StepByStep.Infrastructure.Modules;
using Xunit;
using Xunit.Abstractions;
using Xunit.Frameworks.Autofac;

[assembly: TestFramework("StepByStep.Test.ConfigureTestFramework", "StepByStep.Test")]
namespace StepByStep.Test
{
    public class ConfigureTestFramework : AutofacTestFramework
    {
        public ConfigureTestFramework(IMessageSink diagnosticMessageSink)
          : base(diagnosticMessageSink)
        {
        }
        protected override void ConfigureContainer(ContainerBuilder builder)
        {
            builder.RegisterModule<InfrastructureModule>();
            builder.RegisterModule<ApplicationModule>();
        }
    }
}