using System.Diagnostics;

namespace SimpleInjectorPlayground
{
    public class SimpleRepository : IRepository
    {
        private readonly IDatabaseConnection _databaseConnection;
        private readonly ILogger _logger;

        public SimpleRepository(IDatabaseConnection databaseConnection, ILogger logger)
        {
            _databaseConnection = databaseConnection;
            _logger = logger;
        }

        public void SaveStuff(string stuff)
        {
            _databaseConnection.Open();

            _logger.LogError();

            Debug.Write("Saving stuff...");
        }
    }
}