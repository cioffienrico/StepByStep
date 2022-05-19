using StepByStep.Domain;
using System;
using System.Linq;

namespace StepByStep.Application.UseCases.Add.RequestHandlers
{
    public class MountCustomerHandler : Handler<AddRequest>
    {
        public override void ProcessRequest(AddRequest request)
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
