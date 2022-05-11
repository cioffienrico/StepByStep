using System;
using System.Collections.Generic;
using System.Text;

namespace StepByStep.Application.UseCases.Delete
{
    public class DeleteRequest
    { 
        public bool Active { get; private set; }
        public Guid Id { get; private set; }
        public DeleteRequest(bool active, Guid id)
        {
            Active = active;
            Id = id;
        }
    }
}
