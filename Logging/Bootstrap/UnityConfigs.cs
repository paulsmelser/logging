using System.Diagnostics.Tracing;
using Microsoft.Practices.EnterpriseLibrary.SemanticLogging;
using Microsoft.Practices.Unity;
using Whatsnexx.Logging.Data.Repositories;
using Whatsnexx.Logging.Entities;
using Whatsnexx.Logging.Listeners;

namespace Whatsnexx.Logging.Bootstrap
{
	public class UnityConfigs
	{
		public static void RegisterTypes(IUnityContainer container)
		{
			RegisterLoggers(container);
		}

		private static void RegisterLoggers(IUnityContainer container)
		{
			container.RegisterType<IRepository<LogEntry>, LogEntryRepository>();
			container.RegisterType<ApplicationLoggingListener>(new ContainerControlledLifetimeManager(),
				new InjectionProperty("LoggingRepository", new ResolvedParameter<IRepository<LogEntry>>()));
			container.Resolve<ApplicationLoggingListener>().EnableEvents(EventLevel.Informational, Keywords.All);

			container.RegisterType<IRepository<ErrorLogEntry>, ErrorLogEntryRepository>();
			container.RegisterType<ExceptionEventListener>(new ContainerControlledLifetimeManager(),
				new InjectionProperty("LoggingRepository", new ResolvedParameter<IRepository<ErrorLogEntry>>()));
			container.Resolve<ExceptionEventListener>().EnableEvents(EventLevel.Error, Keywords.All);
		}
	}
}
