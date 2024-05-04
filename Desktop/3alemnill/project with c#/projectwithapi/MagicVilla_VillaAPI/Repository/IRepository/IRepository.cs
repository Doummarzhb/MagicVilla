using MagicVilla_VillaAPI.Models;
using System.Linq.Expressions;

namespace MagicVilla_VillaAPI.Repository
{
	public interface IRepository<T> where T : class
	{
		Task<List<Villa>> GetAllasync(Expression<Func<T, bool>>? filter = null);
		Task<Villa> Get(Expression<Func<T, bool>> filter = null, bool tracked = true);
		//Task Create(Villa entity);
		//Task Remove (Villa entity);
		Task CreateAsync(T entity);
		Task RemoveAsync(T entity);

		//Task UpdateAsync(T entity);


		Task SaveAsync();
	}
}
