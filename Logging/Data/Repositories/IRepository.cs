using System;
using System.Collections.Generic;

namespace Whatsnexx.Logging.Data.Repositories
{
	public interface IRepository<T>
	{
		bool Save(T entity);

		T Find(Guid id);

		//bool Delete(T entity);
		IList<T> FindAll();

		bool Delete(T entity);
	}
}
