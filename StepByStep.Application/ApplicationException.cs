using System;
using System.Collections.Generic;
using System.Text;

namespace StepByStep.Application
{
    public class ApplicationException : Exception
    {
        internal ApplicationException(string businessMessage)
               : base(businessMessage)
        {
        }
    }
}
