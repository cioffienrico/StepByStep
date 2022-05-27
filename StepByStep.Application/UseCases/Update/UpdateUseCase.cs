using StepByStep.Application.UseCases.Update.Handlers;

namespace StepByStep.Application.UseCases.Update
{
    public class UpdateUseCase : IUpdateUseCase
    {
        private readonly UpdateCustomerHandler updateCustomerHandler;

        public UpdateUseCase(UpdateAddressHandler updateAddressHandler, UpdateCustomerHandler updateCustomerHandler, SaveUpdatedCustomerHandler saveUpdatedCustomerHandler)
        {
            updateCustomerHandler.SetSucessor(updateAddressHandler);
            updateAddressHandler.SetSucessor(saveUpdatedCustomerHandler);

            this.updateCustomerHandler = updateCustomerHandler;
        }

        public void Execute(UpdateRequest request)
        {
            updateCustomerHandler.ProcessRequest(request);
        }
    }
}
