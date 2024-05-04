using MagicVilla_VillaAPI.Data;
using MagicVilla_VillaAPI.Models;
using MagicVilla_VillaAPI.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace MagicVilla_VillaAPI.Repository
{
	public class VillaRepository : Repository <Villa> ,IVillaRepository

	{
		private readonly ApplicationDbContext _db;
		public VillaRepository(ApplicationDbContext db) :base(db)
		{
			_db = db;
		}
		//public async  Task CreateAsync(Villa entity)
		//{
		//	 await _db.Villas.AddAsync(entity); 
		//	await SaveAsync();

		//}

		////private Task SaveAsync()
		////{
		////	throw new NotImplementedException();
		////}

		//public async Task<Villa> GetAsync(Expression<Func<Villa , bool >> filter = null, bool tracked = true)
		//{
		//	IQueryable<Villa> query = _db.Villas;
		//	if (filter != null)
		//	{
		//		query = query.AsNoTracking();
		//	}
		//	return await query.FirstOrDefaultAsync();
		//}

		////public async Task<List<Villa>> GetAll(Expression<Func<Villa, bool>> filter = null)
		//public async Task<List<Villa>>GetAllAsync(Expression<Func<Villa,bool>> filter)
		//{
		//	IQueryable<Villa> query = _db.Villas;
		//	if(filter != null)
		//	{
		//		query = query.Where(filter);
		//	}
		//	return await query.ToListAsync();

		//}

		//public async  Task RemoveAsync(Villa entity)
		//{
		//	_db.Villas.Remove(entity);
		//	await SaveAsync();


		//}

		//public async Task SaveAsync()
		//{
		//	await _db.SaveChangesAsync();
		//}

		//public Task<List<Villa>> GetAllasync(Expression<Func<Villa, bool>> filter = null)
		//{
		//	throw new NotImplementedException();
		//}

		//public Task<Villa> Get(Expression<Func<Villa, bool>> filter = null, bool tracked = true)
		//{
		//	throw new NotImplementedException();
		//}

		//public Task GetAsync(Func<object, bool> value)
		//{
		//	throw new NotImplementedException();
		//}

		//public Task<IEnumerable<Villa>> GetAllAsync()
		//{
		//	throw new NotImplementedException();
		//}

		public async Task<Villa> UpdateAsync(Villa entity)
		{
			//_db.Villas.Update(entity);
			//await SaveAsync();
			entity.UpdateDate = DateTime.Now;
			_db.Villas.Update(entity);
			await _db.SaveChangesAsync();
			return entity;
		}
	}
}
