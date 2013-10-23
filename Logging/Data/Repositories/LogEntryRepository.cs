using System;
using System.Collections.Generic;
using Logging.Business.Entities;
using Logging.Data.Context;

namespace Logging.Data.Repositories
{
	public class LogEntryRepository : IRepository<LogEntry>
	{
		public bool Save(LogEntry entity)
		{
			var context = new LoggingContext();
			context.LogEntries.Add(entity);
			return context.SaveChanges() != 0;
		}

		public LogEntry Find(Guid id)
		{
			var context = new LoggingContext();
			return context.LogEntries.Find(id);
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
