using System.Configuration;

namespace Whatsnexx.Logging.Data
{
	public static class Settings
	{
		public static string ConnectionString = ConfigurationManager.AppSettings["LoggingConnectionString"];

		public static void SetDatabase(string connectionString)
		{
			ConnectionString = connectionString;
		}
	}
}
