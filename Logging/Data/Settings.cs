using System.Resources;

namespace Whatsnexx.Logging.Data
{
	public static class Settings
	{
		public static void SetDatabase(string connectionString)
		{
			const string path = @".\Resources.resx";

			var writer = new ResXResourceWriter(path);
			writer.AddResource("LoggingConnectionString", connectionString);
			writer.Close();
		}
	}
}
