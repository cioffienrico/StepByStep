using StepByStep.Domain;
using System;
using System.Linq;

namespace StepByStep.Application.UseCases.Update.Handlers
{
    public class UpdateAddressHandler : Handler<UpdateRequest>
    {
        public override void ProcessRequest(UpdateRequest request)
        {
            request.Address = new Address(Guid.NewGuid(), request.Customer.Id, request.Cep, request.Road, request.Number, request.Complement, request.Neighborhood, request.City, request.State);

            if (request.Address.IsValid)
            {
                request.Erros.AddRange(request.Address.ValidationResult.Errors.Select(s => s.ErrorMessage).ToArray());
                return;
            }

            sucessor?.ProcessRequest(request);
        }
    }
}
