using System.Diagnostics;

namespace Webservice
{
    public class DebugLogger : ILogger
    {
        public void Write(string message)
        {
            Debug.WriteLine(message);
        }
    }
}