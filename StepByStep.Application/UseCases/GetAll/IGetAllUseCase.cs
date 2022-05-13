using StepByStep.Domain;
using System.Collections.Generic;
using System.Text;

namespace StepByStep.Application.UseCases.GetAll
{
    public interface IGetAllUseCase
    {
        List<Customer> Execute();
    
    }
}
