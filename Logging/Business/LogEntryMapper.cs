using System;
using System.Diagnostics.Tracing;
using System.Linq;
using Whatsnexx.Logging.Entities;
using Whatsnexx.Logging.Enums;
using Whatsnexx.Logging.Utilities;
using EventSource = Whatsnexx.Logging.Entities.EventSource;

namespace Whatsnexx.Logging
{
	public class LogEntryMapper
	{

		public static LogEntry Map(EventWrittenEventArgs source)
		{

			return new LogEntry
			{
				Created = DateTime.UtcNow,
				EventId = source.EventId,
				EventSource = JsonSerializer.DeserializeObject<EventSource>(JsonSerializer.SerializeObject(source.EventSource)),
				Id = Guid.NewGuid(),
				Opcode = (Opcodes)source.Opcode,
				Keyword = (Keywords)source.Keywords,
				Level = (Levels)source.Level,
				Message = source.Message,
				Task = (Tasks)source.Task,
				Version = source.Version,
				Payload = new Payload(source.Payload)
			};
		}

		public static ErrorLogEntry MapError(EventWrittenEventArgs source)
		{
			return new ErrorLogEntry
			{
				Created = DateTime.UtcNow,
				EventId = source.EventId,
				EventSource = JsonSerializer.DeserializeObject<EventSource>(JsonSerializer.SerializeObject(source.EventSource)),
				Id = Guid.NewGuid(),
				Opcode = (Opcodes)source.Opcode,
				Keyword = (Keywords)source.Keywords,
				Level = (Levels)source.Level,
				Message = source.Message,
				Task = (Tasks)source.Task,
				Version = source.Version,
				ExceptionType = (string) source.Payload[0],
				ExceptionMessage = (string) source.Payload[1],
				StackTrace = (string) source.Payload[2],
				Payload = new Payload(new[] { source.Payload.Last() })
			};
		}
	}
}
