using System;
using System.Diagnostics;
using System.Diagnostics.Tracing;
using Whatsnexx.Logging.Data.Repositories;
using Whatsnexx.Logging.Entities;
using Whatsnexx.Logging.Utilities;

namespace Whatsnexx.Logging.Listeners
{
	internal class ApplicationLoggingListener :EventListener
	{
		public IRepository<LogEntry> LoggingRepository { get; set; }

		//internal ApplicationLoggingListener(IRepository<LogEntry> gatewayStorageRepository)
		//{
		//	LoggingRepository = gatewayStorageRepository;
		//}
		//public ApplicationLoggingListener
		protected override void OnEventWritten(EventWrittenEventArgs eventData)
		{
			var logEntry = LogEntryMapper.Map(eventData);
			try
			{
				LoggingRepository.Save(logEntry);
			}
			catch (Exception e)
			{
				Trace.TraceError("Could not save log to Gateway database: " + e.Message + " : " + JsonSerializer.SerializeObject(logEntry));
			}
		}

		public void EnableEvents(EventLevel level, EventKeywords keywords)
		{
			EnableEvents(Logger.ApplicationEventsLog, level, keywords);
		}
	}
}
