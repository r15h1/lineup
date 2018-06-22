using System;
using System.Collections.Generic;
using System.Text;

namespace LineUp.Core
{
    public class IllegalOperationException:Exception
    {
        public IllegalOperationException(IEnumerable<string> errors)
        {
            Errors = errors;
        }

        public IEnumerable<string> Errors { get; }
    }
}
