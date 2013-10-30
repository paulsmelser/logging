using System.Diagnostics.Tracing;

namespace Whatsnexx.Logging.EventSources
{
    [EventSource(Name = "ExceptionEvents")]
    internal class ExceptionEvents : EventSource
    {
		public static class Keywords
        {
            public const EventKeywords BusinessLogic = (EventKeywords)1L;
            public const EventKeywords DataAccess = (EventKeywords)2L;
            public const EventKeywords Application = (EventKeywords) 4L;
        }
		public static class Tasks
        {
			public const EventTask Start = (EventTask)1;
            public const EventTask PublishMessage = (EventTask)101;
        }

		public static class Opcodes
        {
            public const EventOpcode UnknownError = (EventOpcode)120;
            public const EventOpcode TimeOut = (EventOpcode) 121;
        }

        [Event(100, Level = EventLevel.Error, Message = "An error occured publishing message(s) to queue", Keywords = Keywords.DataAccess, Task = Tasks.PublishMessage, Opcode = Opcodes.UnknownError, Version = 1)]
		internal void ExceptionHandled(string payload, string exceptionType, string exceptionMessage, string stackTrace)
        {
            if (IsEnabled(EventLevel.Error, Keywords.DataAccess))
            {
				WriteEvent(100, exceptionType, exceptionMessage, stackTrace, payload);
            }
        }

        [Event(101, Level = EventLevel.Critical, Message = "A critcal error occurred during application startup", Keywords = Keywords.Application, Task = Tasks.Start, Opcode = Opcodes.UnknownError, Version = 1)]
		internal void ApplictionStartupFailure(string exceptionType, string exceptionMessage, string stackTrace)
        {
            if (IsEnabled(EventLevel.Critical, Keywords.Application))
            {
				WriteEvent(101, exceptionType, exceptionMessage, stackTrace);
            }
        }

    }
}
