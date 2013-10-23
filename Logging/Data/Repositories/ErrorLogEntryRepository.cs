using System;
using System.Collections.Generic;
using Logging.Business.Entities;
using Logging.Data.Context;

namespace Logging.Data.Repositories
{
	internal class ErrorLogEntryRepository : IRepository<ErrorLogEntry>
	{
		public bool Save(ErrorLogEntry entity)
		{
			var context = new LoggingContext();
			context.ErrorLogEntries.Add(entity);
			return context.SaveChanges() != 0;
		}

		public ErrorLogEntry Find(Guid id)
		{
			var context = new LoggingContext();
			return context.ErrorLogEntries.Find(id);
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
