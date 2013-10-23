using System;
using System.ComponentModel.DataAnnotations;
using Logging.Business.Enums;
using Logging.Business.Logic.Utilities;

namespace Logging.Business.Entities
{
    public class LogEntry
    {
		public LogEntry() { }

		protected LogEntry(Guid id, int eventId, Keywords keyword, Opcodes opcode, Tasks task, Levels level, EventSource eventSource, int version, string message, Payload payload, DateTime created)
        {
		    Id = id;
            EventId = eventId;
            Keyword = keyword;
            Opcode = opcode;
            Task = task;
            Level = level;
            EventSource = eventSource;
            Version = version;
            Message = message;
			Payload = payload;
            Created = created;
        }

		protected LogEntry(int eventId, Keywords keyword, Opcodes opcode, Tasks task, Levels level, EventSource eventSource, int version, string message, Payload payload, DateTime created)
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
			Payload = payload;
            Created = created;
        }

        public static LogEntry CreateNew(int eventId, Keywords keyword, Opcodes opcode, 
			Tasks task, Levels level, string eventSource, int version, string message,Payload payload)
        {

            return new LogEntry(eventId, keyword, opcode, task, level, JsonSerializer.DeserializeObject<EventSource>(eventSource), version, message, payload, DateTime.UtcNow);
        }

        public static LogEntry CreateClean(Guid id, int eventId, Keywords keyword, Opcodes opcode, 
			Tasks task, Levels level, string eventSource, int version, string message, Payload payload,
            DateTime created)
        {
            return new LogEntry(id, eventId, keyword, opcode, task, level, JsonSerializer.DeserializeObject<EventSource>(eventSource), version, message, payload, created);
        }
        
		public override bool Equals(object obj)
		{
			if (ReferenceEquals(null, obj)) return false;
			if (ReferenceEquals(this, obj)) return true;
			if (obj.GetType() != this.GetType()) return false;
			return Equals((LogEntry)obj);
		}

		protected bool Equals(LogEntry other)
		{
			var created = new DateTime(((Created.Ticks + TimeSpan.TicksPerSecond - 1) / TimeSpan.TicksPerSecond) * TimeSpan.TicksPerSecond);
			var otherCreated = new DateTime(((other.Created.Ticks + TimeSpan.TicksPerSecond - 1)/TimeSpan.TicksPerSecond)*TimeSpan.TicksPerSecond); 
			var eventId = EventId == other.EventId;
			var keywords = Keyword == other.Keyword;
			var opcodes = Opcode == other.Opcode;
			var tasks = Task == other.Task;
			var level = Level == other.Level;
			var eventSource = Equals(EventSource, other.EventSource);
			var createdEqual = created.Equals(otherCreated);
			var version = Version == other.Version;
			var message = string.Equals(Message, other.Message);
			var payload = Equals(Payload, other.Payload);
			return eventId && keywords && opcodes && tasks && level && eventSource && createdEqual && version && message && payload;
		}

		public override int GetHashCode()
		{
			unchecked
			{
				var hashCode = EventId;
				hashCode = (hashCode * 397) ^ (int)Keyword;
				hashCode = (hashCode * 397) ^ (int)Opcode;
				hashCode = (hashCode * 397) ^ (int)Task;
				hashCode = (hashCode * 397) ^ (int)Level;
				hashCode = (hashCode * 397) ^ (EventSource != null ? EventSource.GetHashCode() : 0);
				hashCode = (hashCode * 397) ^ Created.GetHashCode();
				hashCode = (hashCode * 397) ^ Version;
				hashCode = (hashCode * 397) ^ (Message != null ? Message.GetHashCode() : 0);
				hashCode = (hashCode * 397) ^ (Payload != null ? Payload.GetHashCode() : 0);
				return hashCode;
			}
		}

		[Key]
		public Guid Id { get; set; }
        public int EventId { get; set; }
        public Keywords Keyword { get; set; }
		public Opcodes Opcode { get; set; }
		public Tasks Task { get; set; }
		public Levels Level { get; set; }
        public EventSource EventSource { get; set; }
        public DateTime Created { get; set; }
        public int Version { get; set; }
        public string Message { get; set; }
        public Payload Payload { get; set; }
    }
}
