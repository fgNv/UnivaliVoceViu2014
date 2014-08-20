using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VoceViuModel.Exceptions
{
    public static class ExceptionExtensions
    {
        public static IEnumerable<string> GetMessages(this Exception exception)
        {
            yield return exception.Message;

            if (exception.InnerException != null)
                foreach (var msg in GetMessages(exception.InnerException))
                    yield return msg;
        }
    }
}
