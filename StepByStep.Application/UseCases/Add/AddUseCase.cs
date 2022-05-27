using StepByStep.Application.UseCases.Add.RequestHandlers;

namespace StepByStep.Application.UseCases.Add
{
    public class AddUseCase : IAddUseCase
    {
        private readonly MountCustomerHandler mountCustomerHandler;

        public AddUseCase(MountAddressHandler mountAddressHandler, MountCustomerHandler mountCustomerHandler, SaveCustomerHandler saveCustomerHandler)
        {
            mountCustomerHandler.SetSucessor(mountAddressHandler);
            mountAddressHandler.SetSucessor(saveCustomerHandler);

            this.mountCustomerHandler = mountCustomerHandler;
        }

        public void Execute(AddRequest request)
        {
            mountCustomerHandler.ProcessRequest(request);
        }
    }
}
