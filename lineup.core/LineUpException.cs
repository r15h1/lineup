using System;
using System.Collections.Generic;
using System.Text;

namespace LineUp.Core
{
    public class LineUpException:Exception
    {
        public LineUpException(IEnumerable<string> errors)
        {
            Errors = errors;
        }

        public IEnumerable<string> Errors { get; }
    }
}
