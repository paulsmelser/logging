using System;
using System.ComponentModel.DataAnnotations;

namespace Whatsnexx.Logging.Data.Entities
{
	public class LogEntry
	{

		[Key]
		public Guid Id { get; set; }
		public int EventId { get; set; }
		public int Keyword { get; set; }
		public int Opcode { get; set; }
		public int Task { get; set; }
		public int Level { get; set; }
		public string EventSource { get; set; }
		public DateTime Created { get; set; }
		public int Version { get; set; }
		public string Message { get; set; }
		public string Payload { get; set; }
	}
}
