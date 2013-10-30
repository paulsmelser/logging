using System;
using Whatsnexx.Logging.Utilities;
using ErrorLogEntry = Whatsnexx.Logging.Data.Entities.ErrorLogEntry;
using LogEntry = Whatsnexx.Logging.Data.Entities.LogEntry;

namespace Whatsnexx.Logging.Data.Mappers
{
	internal class LogEntryMapper
	{
		public static LogEntry Map(Logging.Entities.LogEntry source)
		{
			return new LogEntry
			{
				Created = DateTime.UtcNow,
				EventId = source.EventId,
				EventSource = JsonSerializer.SerializeObject(source.EventSource),
				Id = Guid.NewGuid(),
				Opcode = (int)source.Opcode,
				Keyword = (int)source.Keyword,
				Level = (int)source.Level,
				Message = source.Message,
				Task = (int)source.Task,
				Version = source.Version,
				Payload = JsonSerializer.SerializeObject(source.Payload)
			};
		}

		public static ErrorLogEntry MapError(Logging.Entities.ErrorLogEntry source)
		{
			return new ErrorLogEntry
			{
				Created = DateTime.UtcNow,
				EventId = source.EventId,
				EventSource = JsonSerializer.SerializeObject(source.EventSource),
				Id = Guid.NewGuid(),
				Opcode = (int) source.Opcode,
				Keyword = (int)source.Keyword,
				Level = (int)source.Level,
				Message = source.Message,
				Task = (int)source.Task,
				Version = source.Version,
				ExceptionType = source.ExceptionType,
				ExceptionMessage = source.ExceptionMessage,
				StackTrace = source.StackTrace,
				Payload = JsonSerializer.SerializeObject(source.Payload)
			};
		}
	}
}
