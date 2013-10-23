using System.Diagnostics.Tracing;

namespace Logging.Business.Logic.EventSources
{

    [EventSource(Name = "ApplicationEvents")]
    internal class ApplicationEvents : EventSource
    {
		public static class Keywords
        {
            public const EventKeywords BusinessLogic = (EventKeywords)1L;
            public const EventKeywords DataAccess = (EventKeywords)2L;
            public const EventKeywords Application = (EventKeywords)4L;
        }
		public static class Tasks
        {
            public const EventTask Start = (EventTask)1;
            public const EventTask Unknown = (EventTask)2;
        }

		public static class Opcodes
        {
            public const EventOpcode Success = (EventOpcode) 20;
            public const EventOpcode Trace = (EventOpcode) 21;
        }

        [Event(200, Message = "Application OnStart completed.", Level = EventLevel.Informational, Keywords = Keywords.Application, Task = Tasks.Start, Opcode = Opcodes.Success, Version = 1)]
		internal void ApplicationStartup()
        {
            if (IsEnabled(EventLevel.Informational, Keywords.Application))
            {
                WriteEvent(200);
            }
        }

		[Event(201, Message = "ApplicationTrace", Level = EventLevel.Verbose, Keywords = Keywords.Application, Task = Tasks.Unknown, Opcode = Opcodes.Trace, Version = 1)]
		internal void ApplicationTrace(string message)
        {
            if (IsEnabled(EventLevel.Verbose, Keywords.Application))
            {
                WriteEvent(201, message);
            }
        }

		[Event(202, Message = "ApplicationTraceInformation", Level = EventLevel.Informational, Keywords = Keywords.Application, Task = Tasks.Unknown, Opcode = Opcodes.Trace, Version = 1)]
		internal void ApplicationTraceInformation(string message)
        {
            if (IsEnabled(EventLevel.Informational, Keywords.Application))
            {
                WriteEvent(202, message);
            }
        }
    }
}
