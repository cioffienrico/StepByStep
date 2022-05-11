using System;
using System.Collections.Generic;
using System.Text;

namespace StepByStep.Application.UseCases.Delete
{
    public interface IDeleteUseCase
    {
        bool Execute(DeleteRequest request);

    }
}
