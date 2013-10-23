using System;
using System.Diagnostics;
using System.Diagnostics.Tracing;
using Logging.Business.Entities;
using Logging.Business.Logic.Utilities;
using Logging.Data.Repositories;

namespace Logging.Business.Logic.Listeners
{
	public class ApplicationLoggingListener :EventListener
	{
		private IRepository<LogEntry> GatewayStorageRepository { get; set; }

		internal ApplicationLoggingListener(IRepository<LogEntry> gatewayStorageRepository)
		{
			GatewayStorageRepository = gatewayStorageRepository;
		}
		protected ApplicationLoggingListener(){}

		protected override void OnEventWritten(EventWrittenEventArgs eventData)
		{
			var logEntry = eventData.Map<LogEntry>();

			try
			{
				GatewayStorageRepository.Save(logEntry);
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
