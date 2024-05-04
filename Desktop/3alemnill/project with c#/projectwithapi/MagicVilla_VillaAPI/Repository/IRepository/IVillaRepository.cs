using MagicVilla_VillaAPI.Models;
using System.Linq.Expressions;

namespace MagicVilla_VillaAPI.Repository.IRepository
{
	public interface IVillaRepository : IRepository<Villa>
	{
		Task<IEnumerable<Villa>> GetAllAsync();

		//Task <List<Villa>> GetAll (Expression<Func<Villa , bool>> filter = null);
		//Task<List<Villa>> GetAllasync(Expression<Func<Villa, bool>> filter = null);
		//Task<Villa>Get(Expression<Func<Villa , bool >> filter = null , bool tracked = true );
		////Task Create(Villa entity);
		////Task Remove (Villa entity);
		//Task CreateAsync(Villa entity);
		//Task RemoveAsync(Villa entity);

		Task<Villa> UpdateAsync(Villa entity);


		//Task SaveAsync();
		//Task GetAsync(Func<object, bool> value);
		//Task<IEnumerable<Villa>> GetAllAsync();
	}
}
