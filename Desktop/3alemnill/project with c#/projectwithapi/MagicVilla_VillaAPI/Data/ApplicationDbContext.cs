using MagicVilla_VillaAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace MagicVilla_VillaAPI.Data
{
	public class ApplicationDbContext : DbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
		{
			
		}
		public DbSet<Villa> Villas { get; set; }

		public DbSet<LocalUser> LocalUsers { get; set; }

		public DbSet<VillaNumber> VillaNumbers { get; set; }


		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Villa>().HasData(
			new Villa()
			{
				Id = 1,
				Name = "Test",
				Details = "dddddddddddddddddddd",
				ImageUrl = "",
				Occupancy = 5,
				Rate = 200,
				Sqft = 550,
				Amenity = "", 
				CreateDate = DateTime.Now,
			},

			new Villa()
			{
				Id = 2,
				Name = "Test",
				Details = "dddddddddddddddddddd",
				ImageUrl = "",
				Occupancy = 5,
				Rate = 200,
				Sqft = 550,
				Amenity = "",
				CreateDate = DateTime.Now,
			},
			new Villa()
			{
				Id = 3,
				Name = "Test",
				Details = "dddddddddddddddddddd",
				ImageUrl = "",
				Occupancy = 5,
				Rate = 200,
				Sqft = 550,
				Amenity = "",
				CreateDate = DateTime.Now,
			},
			new Villa()
			{
				Id = 4,
				Name = "Test",
				Details = "dddddddddddddddddddd",
				ImageUrl = "",
				Occupancy = 5,
				Rate = 200,
				Sqft = 550,
				Amenity = "",
				CreateDate = DateTime.Now,
			},
			new Villa()
			{
				Id = 5,
				Name = "Test",
				Details = "dddddddddddddddddddd",
				ImageUrl = "",
				Occupancy = 5,
				Rate = 200,
				Sqft = 550,
				Amenity = "",
				CreateDate =DateTime.Now,
			}
			);
		}
	}
}
