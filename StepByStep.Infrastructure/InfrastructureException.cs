using System;

namespace StepByStep.Infrastructure
{
        public class InfrastructureException : Exception
        {
            internal InfrastructureException(string businessMessage)
                   : base(businessMessage)
            {
            
        }
    }
}
