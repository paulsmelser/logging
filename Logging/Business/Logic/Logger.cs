using System;
using Logging.Business.Logic.EventSources;

namespace Logging.Business.Logic
{
	public static class Logger
	{
		internal static readonly ExceptionEvents ExceptionEventsLog = new ExceptionEvents();
		internal static readonly ApplicationEvents ApplicationEventsLog = new ApplicationEvents();

		public static void PublishingException(string interactions, Exception exception)
		{
			ExceptionEventsLog.PublishingException(interactions, exception.GetType().Name, exception.Message, exception.StackTrace);
		}

		public static void ApplictionStartupFailure(Exception exception)
		{
			ExceptionEventsLog.ApplictionStartupFailure(exception.GetType().Name, exception.Message, exception.StackTrace);
		}

		public static void ApplicationStartup()
		{
			ApplicationEventsLog.ApplicationStartup();
		}

		public static void ApplicationTrace(string message)
		{
			ApplicationEventsLog.ApplicationTrace(message);
		}

		public static void ApplicationTraceInformation(string message)
		{
			ApplicationEventsLog.ApplicationTraceInformation(message);
		}
	}
}
