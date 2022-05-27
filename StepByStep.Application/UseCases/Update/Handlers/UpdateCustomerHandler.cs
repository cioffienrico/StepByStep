using StepByStep.Domain;
using System;
using System.Linq;

namespace StepByStep.Application.UseCases.Update.Handlers
{
    public class UpdateCustomerHandler : Handler<UpdateRequest>
    {
        public override void ProcessRequest(UpdateRequest request)
        {
            request.Customer = new Customer(Guid.NewGuid(), request.Name, request.Birthday, request.Rg, request.Cpf, DateTime.Now, true);

            if (!request.Customer.IsValid)
            {
                request.Erros.AddRange(request.Customer.ValidationResult.Errors.Select(s => s.ErrorMessage).ToArray());
                return;
            }

            sucessor?.ProcessRequest(request);
        }
    }
}
