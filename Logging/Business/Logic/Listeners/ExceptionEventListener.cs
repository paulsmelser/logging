using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Tracing;
using Whatsnexx.Logging.Data.Repositories;
using Whatsnexx.Logging.Entities;
using Whatsnexx.Logging.Utilities;

namespace Whatsnexx.Logging.Listeners
{

    public class ExceptionEventListener : EventListener
    {
		public IRepository<ErrorLogEntry> LoggingRepository { get; set; }

	    protected override void OnEventWritten(EventWrittenEventArgs eventData)
	    {
		    var errorLogEntry = LogEntryMapper.MapError(eventData);
            var payload = new List<object>();
            try
            {
				LoggingRepository.Save(errorLogEntry);
            }
            catch(Exception gatewayException)
            {
                payload.Add(gatewayException.GetType().Name);
                payload.Add(gatewayException.Message);
                Trace.TraceError(JsonSerializer.SerializeObject(errorLogEntry, true, true));
            }
        }

		public void EnableEvents(EventLevel level, EventKeywords keywords)
		{
			EnableEvents(Logger.ExceptionEventsLog, level, keywords);
		}
    }
}
