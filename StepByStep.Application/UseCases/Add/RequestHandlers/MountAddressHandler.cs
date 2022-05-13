using StepByStep.Application.UseCases.Add;
using StepByStep.Domain;
using System;
using System.Linq;

namespace StepByStep.Application.UseCases.Add.RequestHandlers
{
    public class MountAddressHandler : Handler<AddRequest>
    {
        public override void ProcessRequest(AddRequest request)
        {
            request.Adress = new Address(Guid.NewGuid(), request.Cep, request.Road, request.Number, request.Complement, request.Neighborhood, request.City, request.State);

            if (request.Adress.IsValid)
            {
                request.Erros.AddRange(request.Adress.ValidationResult.Errors.Select(s => s.ErrorMessage).ToArray());
                return;
            }

            sucessor?.ProcessRequest(request);
        }
    }
}
