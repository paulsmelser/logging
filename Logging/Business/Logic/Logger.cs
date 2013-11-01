using System;
using System.Data.Entity;
using Microsoft.Practices.Unity;
using Whatsnexx.Logging.Bootstrap;
using Whatsnexx.Logging.Data;
using Whatsnexx.Logging.Data.Context;
using Whatsnexx.Logging.EventSources;

namespace Whatsnexx.Logging
{
	public static class Logger
	{
		internal static readonly ExceptionEvents ExceptionEventsLog = new ExceptionEvents();
		internal static readonly ApplicationEvents ApplicationEventsLog = new ApplicationEvents();

		static Logger()
		{
			UnityConfigs.RegisterTypes(new UnityContainer());
			Database.SetInitializer(new DropCreateDatabaseIfModelChanges<LoggingContext>());
		}

		public static void ApplictionStartupFailure(Exception exception)
		{
			ExceptionEventsLog.ApplictionStartupFailure(exception.GetType().Name, exception.Message, exception.StackTrace);
		}

		public static void ExceptionHandled(Exception exception, string payload)
		{
			ExceptionEventsLog.ExceptionHandled(payload, exception.GetType().Name, exception.Message, exception.StackTrace);
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

		public static void RegisterDatabase(string connectionString)
		{
			Settings.SetDatabase(connectionString);
		}
	}
}
