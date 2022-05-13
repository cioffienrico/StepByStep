using Autofac;
using StepByStep.Application.UseCases;
using StepByStep.Application.UseCases.Add;
using StepByStep.Application.UseCases.GetAll;
using StepByStep.Application.UseCases.GetById;

namespace StepByStep.Infrastructure.Modules
{
    public class ApplicationModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<AddUseCase>().As<IAddUseCase>().AsImplementedInterfaces();
            builder.RegisterType<GetAllUseCase>().As<IGetAllUseCase>().AsImplementedInterfaces();
            builder.RegisterType<GetByIdUseCase>().As<IGetByIdUseCase>().AsImplementedInterfaces();

            builder.RegisterAssemblyTypes(typeof(Handler<>).Assembly).AsImplementedInterfaces().AsSelf().InstancePerDependency();
        }
    }
}
