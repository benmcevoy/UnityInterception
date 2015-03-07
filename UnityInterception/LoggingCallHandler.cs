using System;
using Microsoft.Practices.Unity.InterceptionExtension;

namespace UnityInterception
{
    public class LoggingCallHandler : ICallHandler
    {
        private readonly ILogger _logger;

        public LoggingCallHandler(ILogger logger)
        {
            _logger = logger;
        }

        public IMethodReturn Invoke(IMethodInvocation input,
            GetNextHandlerDelegate getNext)
        {
            // Before invoking the method on the original target
            WriteLog(String.Format("Invoking method from attribute {0} at {1}",
                input.MethodBase, DateTime.Now.ToLongTimeString()));

            // Invoke the next handler in the chain
            var result = getNext().Invoke(input, getNext);

            // After invoking the method on the original target
            if (result.Exception != null)
            {
                WriteLog(String.Format("Method {0} threw exception {1} at {2}",
                    input.MethodBase, result.Exception.Message,
                    DateTime.Now.ToLongTimeString()));
            }
            else
            {
                WriteLog(String.Format("Method from attribute {0} returned {1} at {2}",
                    input.MethodBase, result.ReturnValue,
                    DateTime.Now.ToLongTimeString()));
            }

            return result;
        }

        public int Order { get; set; }

        private void WriteLog(string message)
        {
            _logger.Log(message);
        }
    }
}