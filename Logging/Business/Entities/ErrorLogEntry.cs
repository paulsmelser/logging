using System;
using System.ComponentModel.DataAnnotations;
using Logging.Business.Enums;
using Logging.Business.Logic.Utilities;

namespace Logging.Business.Entities
{
	public class ErrorLogEntry
	{
		public ErrorLogEntry() { }

		protected ErrorLogEntry(Guid id, Guid accountId, int eventId, Keywords keyword, Opcodes opcode, Tasks task, Levels level,
			EventSource eventSource, int version, string message, string exceptionType, string exceptionMessage, string stackTrace, Payload payload, DateTime created)
		{
			Id = id;
			AccountId = accountId;
			EventId = eventId;
			Keyword = keyword;
			Opcode = opcode;
			Task = task;
			Level = level;
			EventSource = eventSource;
			Version = version;
			Message = message; 
			ExceptionType = exceptionType;
			ExceptionMessage = exceptionMessage;
			StackTrace = stackTrace;
			Payload = payload;
			Created = created;
		}

		protected ErrorLogEntry(int eventId, Keywords keyword, Opcodes opcode, Tasks task, Levels level, EventSource eventSource, int version,
			string message, string exceptionType, string exceptionMessage, string stackTrace, Payload payload, DateTime created)
		{
			Id = Guid.NewGuid();
			EventId = eventId;
			Keyword = keyword;
			Opcode = opcode;
			Task = task;
			Level = level;
			EventSource = eventSource;
			Version = version;
			Message = message;
			ExceptionType = exceptionType;
			ExceptionMessage = exceptionMessage;
			Payload = payload;
			StackTrace = stackTrace;
			Created = created;
		}

		public static ErrorLogEntry CreateNew(int eventId, Keywords keyword, Opcodes opcode,
			Tasks task, Levels level, string eventSource, int version, string message, string exceptionType, string exceptionMessage, Payload payload, string stackTrace)
		{

			return new ErrorLogEntry(eventId, keyword, opcode, task, level, JsonSerializer.DeserializeObject<EventSource>(eventSource), version, message, exceptionType, exceptionMessage, stackTrace, payload, DateTime.UtcNow);
		}

		public static ErrorLogEntry CreateClean(Guid id, Guid accountId, int eventId, Keywords keyword, Opcodes opcode,
			Tasks task, Levels level, string eventSource, int version, string message, string exceptionType, string exceptionMessage, string staceTrace,
			Payload payload, DateTime created)
		{
			return new ErrorLogEntry(id, accountId, eventId, keyword, opcode, task, level, JsonSerializer.DeserializeObject<EventSource>(eventSource), version, message, exceptionType, exceptionMessage, staceTrace, payload, created);
		}

		public override bool Equals(object obj)
		{
			if (ReferenceEquals(null, obj)) return false;
			if (ReferenceEquals(this, obj)) return true;
			if (obj.GetType() != GetType()) return false;
			return Equals((ErrorLogEntry)obj);
		}

		protected bool Equals(ErrorLogEntry other)
		{
			var created = new DateTime(((Created.Ticks + TimeSpan.TicksPerSecond - 1) / TimeSpan.TicksPerSecond) * TimeSpan.TicksPerSecond);
			var otherCreated = new DateTime(((other.Created.Ticks + TimeSpan.TicksPerSecond - 1) / TimeSpan.TicksPerSecond) * TimeSpan.TicksPerSecond);
			var eventId = EventId == other.EventId;
			var accountId = AccountId.Equals(other.AccountId);
			var keywords = Keyword == other.Keyword;
			var opcodes = Opcode == other.Opcode;
			var tasks = Task == other.Task;
			var level = Level == other.Level;
			var eventSource = Equals(EventSource, other.EventSource);
			var createdEqual = created.Equals(otherCreated);
			var version = Version == other.Version;
			var message = string.Equals(Message, other.Message);
			var payload = Payload.Equals(other.Payload);
			var exceptionMessage = string.Equals(ExceptionMessage, other.ExceptionMessage);
			var exceptionType = string.Equals(ExceptionType, other.ExceptionType);
			return eventId && accountId && keywords && opcodes && tasks && level && eventSource && createdEqual && version && message && exceptionMessage && exceptionType && payload;
		}

		public override int GetHashCode()
		{
			unchecked
			{
				var hashCode = EventId;
				hashCode = (hashCode * 397) ^ AccountId.GetHashCode();
				hashCode = (hashCode * 397) ^ (int)Keyword;
				hashCode = (hashCode * 397) ^ (int)Opcode;
				hashCode = (hashCode * 397) ^ (int)Task;
				hashCode = (hashCode * 397) ^ (int)Level;
				hashCode = (hashCode * 397) ^ (EventSource != null ? EventSource.GetHashCode() : 0);
				hashCode = (hashCode * 397) ^ Created.GetHashCode();
				hashCode = (hashCode * 397) ^ Version;
				hashCode = (hashCode * 397) ^ (Message != null ? Message.GetHashCode() : 0);
				hashCode = (hashCode * 397) ^ (ExceptionMessage != null ? ExceptionMessage.GetHashCode() : 0);
				hashCode = (hashCode * 397) ^ (ExceptionType != null ? ExceptionType.GetHashCode() : 0);
				return hashCode;
			}
		}

		[Key]
		public Guid Id { get; set; }
		public int EventId { get; set; }
		public Guid AccountId { get; set; }
		public Keywords Keyword { get; set; }
		public Opcodes Opcode { get; set; }
		public Tasks Task { get; set; }
		public Levels Level { get; set; }
		public EventSource EventSource { get; set; }
		public DateTime Created { get; set; }
		public int Version { get; set; }
		public string Message { get; set; }
		public string ExceptionType { get; set; }
		public string ExceptionMessage { get; set; }
		public string StackTrace { get; set; }
		public Payload Payload { get; set; }
	}
}
