using System;
using System.Collections.Generic;

namespace Logging.Data.Repositories
{
	internal interface IRepository<T>
	{
		bool Save(T entity);

		T Find(Guid id);

		//bool Delete(T entity);
		IList<T> FindAll();

		bool Delete(T entity);
	}
}
