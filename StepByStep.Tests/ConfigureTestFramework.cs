using Autofac;
using StepByStep.Infrastructure.Modules;
using StepByStep.WebApi.Module;
using Xunit;
using Xunit.Abstractions;
using Xunit.Frameworks.Autofac;

[assembly: TestCollectionOrderer("Gcsb.Connect.Fines.Test.TestCaseOrdering", "Gcsb.Connect.Fines.Test")]
[assembly: CollectionBehavior(DisableTestParallelization = true)]
[assembly: TestFramework("Gcsb.Connect.Fines.Test.ConfigureTestFramework", "Gcsb.Connect.Fines.Test")]
namespace Gcsb.Connect.Fines.Test
{
    public class ConfigureTestFramework : AutofacTestFramework
    {
        public ConfigureTestFramework(IMessageSink diagnosticMessageSink) : base(diagnosticMessageSink)
        {

        }

        protected override void ConfigureContainer(ContainerBuilder builder)
        {
            builder.RegisterModule<ApplicationModule>();
            builder.RegisterModule<InfrastructureModule>();
            builder.RegisterModule<WebApiModule>();

           // SetMockedDependencies(builder);
        }

        //private static void SetMockedDependencies(ContainerBuilder builder)
        //{
            //builder.RegisterInstance(new GetInvoicesMock().GetInvoices().Object).As<IGetInvoices>();
           
        //}
    }
}
