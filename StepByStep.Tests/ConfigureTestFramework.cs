using Autofac;
using StepByStep.Infrastructure.Modules;
using Xunit;
using Xunit.Abstractions;
using Xunit.Frameworks.Autofac;

[assembly: TestFramework("StepByStep.Tests.ConfigureTestFramework", "StepByStep.Tests")]
namespace StepByStep.Tests
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