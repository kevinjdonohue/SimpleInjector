using System.Diagnostics;

namespace SimpleInjectorPlayground
{
    public class SimpleLogger : ILogger 
    {
        public void LogError()
        {
            Debug.Write("An error occured!");
        }
    }
}