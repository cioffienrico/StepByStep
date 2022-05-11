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
            request.Adress = new Adress(Guid.NewGuid(), request.Cep, request.Road, request.Number, request.Complement, request.Neighborhood, request.City, request.State);

            sucessor?.ProcessRequest(request);
        }
    }
}
