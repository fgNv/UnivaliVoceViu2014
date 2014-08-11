using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VoceViuWeb.Exceptions
{
    public class ValidationException : Exception
    {
        public IEnumerable<string> Messages { get; private set; }

        public ValidationException(IEnumerable<string> messages)
        {
            Messages = messages;
        }
    }
}