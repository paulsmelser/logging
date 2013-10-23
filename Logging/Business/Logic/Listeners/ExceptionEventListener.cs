using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Tracing;
using Logging.Business.Entities;
using Logging.Business.Logic.Utilities;
using Logging.Data.Repositories;

namespace Logging.Business.Logic.Listeners
{

    public class ExceptionEventListener : EventListener
    {
		private IRepository<ErrorLogEntry> GatewayStorageRepository { get; set; }

		internal ExceptionEventListener(IRepository<ErrorLogEntry> gatewayStorageRepository)
        {
            GatewayStorageRepository = gatewayStorageRepository;
        }

	    protected ExceptionEventListener(){}

	    protected override void OnEventWritten(EventWrittenEventArgs eventData)
        {
            var profileEngineError = eventData.Map<ErrorLogEntry>();
            var payload = new List<object>();
            try
            {
				GatewayStorageRepository.Save(profileEngineError);
            }
            catch(Exception gatewayException)
            {
                payload.Add(gatewayException.GetType().Name);
                payload.Add(gatewayException.Message);
                Trace.TraceError(JsonSerializer.SerializeObject(profileEngineError, true, true));
            }
        }

		public void EnableEvents(EventLevel level, EventKeywords keywords)
		{
			EnableEvents(Logger.ExceptionEventsLog, level, keywords);
		}
    }
}
