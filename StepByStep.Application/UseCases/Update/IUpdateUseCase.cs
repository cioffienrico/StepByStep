using StepByStep.Application.UseCases.Update;
using StepByStep.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace StepByStep.Application.UseCases.Update
{
    public interface IUpdateUseCase
    {
        Customer Execute(UpdateRequest request);

    }
}
