using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.SqlServer;

namespace Whatsnexx.Logging.Data.Configuration
{
	public class LoggingDbConfig : DbConfiguration
	{
		public LoggingDbConfig()
		{
			SetDefaultConnectionFactory(new SqlConnectionFactory("v11.0"));
			SetProviderServices("System.Data.SqlClient", SqlProviderServices.Instance);
		}
	}
}
