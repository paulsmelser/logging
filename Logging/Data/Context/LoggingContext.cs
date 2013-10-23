using System.Configuration;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Logging.Business.Entities;

namespace Logging.Data.Context
{
	internal class LoggingContext : DbContext
	{
		public LoggingContext() : base(ConfigurationManager.AppSettings["LoggingConnectionString"])
		{
		}

		public DbSet<ErrorLogEntry> ErrorLogEntries { get; set; }
		public DbSet<LogEntry> LogEntries { get; set; }

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
			base.OnModelCreating(modelBuilder);
		}
	}
}
