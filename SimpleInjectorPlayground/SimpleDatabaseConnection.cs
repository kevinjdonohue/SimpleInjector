using System.Diagnostics;

namespace SimpleInjectorPlayground
{
    public class SimpleDatabaseConnection : IDatabaseConnection
    {
        public void Open()
        {
            Debug.Write("Opening database connection...");
        }
    }
}