using StepByStep.Application.UseCases.Add;
using StepByStep.Application.UseCases.Add.RequestHandlers;

namespace StepByStep.Application.UseCases.Add
{
    public class AddUseCase : IAddUseCase
    {
        private readonly MountAddressHandler mountAddressHandler;

        public AddUseCase(MountAddressHandler mountAddressHandler, MountCustomerHandler mountCustomerHandler, SaveCustomerHandler saveCustomerHandler)
        {
            mountAddressHandler.SetSucessor(mountCustomerHandler);
            mountCustomerHandler.SetSucessor(saveCustomerHandler);

            this.mountAddressHandler = mountAddressHandler;
        }

        public void Execute(AddRequest request)
        {
            mountAddressHandler.ProcessRequest(request);
        }
    }
}
