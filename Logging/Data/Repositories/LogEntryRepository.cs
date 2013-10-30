using System;
using System.Collections.Generic;
using Whatsnexx.Logging.Data.Context;
using Whatsnexx.Logging.Entities;

namespace Whatsnexx.Logging.Data.Repositories
{
	public class LogEntryRepository : IRepository<LogEntry>
	{
		public bool Save(LogEntry entity)
		{
			var context = new LoggingContext(Settings.ConnectionString);
			context.LogEntries.Add(Mappers.LogEntryMapper.Map(entity));
			return context.SaveChanges() != 0;
		}

		public LogEntry Find(Guid id)
		{
			throw new NotSupportedException();
			//var context = new LoggingContext();
			//return context.LogEntries.Find(id);
		}

		public IList<LogEntry> FindAll()
		{
			throw new NotSupportedException();
		}

		public bool Delete(LogEntry entity)
		{
			throw new NotSupportedException();
		}
	}
}
