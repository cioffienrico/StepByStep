using StepByStep.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace StepByStep.Application.UseCases.GetById
{
    public interface IGetByIdUseCase
    {
        Customer Execute(GetByIdRequest request);
        
    }
}
