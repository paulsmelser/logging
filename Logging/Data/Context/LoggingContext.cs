﻿using System.Configuration;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Whatsnexx.Logging.Entities;

namespace Whatsnexx.Logging.Data.Context
{
	internal class LoggingContext : DbContext
	{
		public LoggingContext() : base(ConfigurationManager.AppSettings["LoggingConnectionString"] ?? Resources.LoggingConnectionString)
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
