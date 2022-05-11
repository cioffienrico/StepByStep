using StepByStep.Application.UseCases.Update;
using System;
using System.Collections.Generic;
using System.Text;

namespace StepByStep.Application.UseCases.Update
{
    public interface IUpdateUseCase
    {
        bool Execute(UpdateRequest request);

    }
}
