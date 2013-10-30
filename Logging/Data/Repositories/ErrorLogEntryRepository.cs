using System;
using System.Collections.Generic;
using Whatsnexx.Logging.Data.Context;
using Whatsnexx.Logging.Entities;

namespace Whatsnexx.Logging.Data.Repositories
{
	internal class ErrorLogEntryRepository : IRepository<ErrorLogEntry>
	{
		public bool Save(ErrorLogEntry entity)
		{
			var context = new LoggingContext(Settings.ConnectionString);
			context.ErrorLogEntries.Add(Mappers.LogEntryMapper.MapError(entity));
			return context.SaveChanges() != 0;
		}

		public ErrorLogEntry Find(Guid id)
		{
			throw new NotSupportedException();
			//var context = new LoggingContext();
			//return context.ErrorLogEntries.Find(id);
		}

		public IList<ErrorLogEntry> FindAll()
		{
			throw new NotSupportedException();
		}

		public bool Delete(ErrorLogEntry entity)
		{
			throw new NotSupportedException();
		}
	}
}
