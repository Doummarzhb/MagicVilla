using MagicVilla_Utility;
using MagicVilla_Web.Models;
using MagicVilla_Web.Models.Dto;
using MagicVilla_Web.Services.IServices;

namespace MagicVilla_Web.Services
{
	public class VillaNumberService : BaseService , IVillaNumberService


	{
		private readonly IHtppClientFactory _clientFactory;
		private string villaUrl;
		public VillaNumberService(IHttpClientFactory clientFactory, IConfiguration configuration) :base(clientFactory)
		{
			_clientFactory = clientFactory;
			villaUrl = configuration.GetValue<string>("ServiceUrls:VillaAPI");

		}
		public Task<T> CreateAsync<T>(VillaNumberCreateDTO dto )
		{
			return SendAsync<T>(new APIRequest()
			{
				ApiType = SD.ApiType.POST,
				Data = dto,
				Url = villaUrl + "/api/villaAPI"

			});
		}
		public Task<T> DeleteAsync<T>(int id )
		{
			return SendAsync<T>(new APIRequest()
			{
				ApiType = SD.ApiType.DELETE,
			 
				Url = villaUrl + "/api/villaAPI/"+id

			});

		}
		public Task<T> GetAllAsync<T>()
		{
			return SendAsync<T>(new APIRequest()
			{
				ApiType = SD.ApiType.GET,

				Url = villaUrl + "/api/villaA5PI"

			});

		}
		public Task<T>GetAsync<T>(int id ) 
		{
			return SendAsync<T>(new APIRequest()
			{
				ApiType = SD.ApiType.GET,

				Url = villaUrl + "/api/villaAPI"

			});
		}
		public Task<T> UpdateAsync<T>(VillaUpdateDTO dto )
		{
			return SendAsync<T>(new APIRequest()
			{
				ApiType = SD.ApiType.PUT,

				Url = villaUrl + "/api/villaAPI/" +dto.Id

			});
		}

	}
}
