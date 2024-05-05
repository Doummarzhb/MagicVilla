using MagicVilla_Utility;
using MagicVilla_Web.Models.Dto;
using MagicVilla_Web.Services.IServices;

namespace MagicVilla_Web.Services
{
	public class AuthServicess:BaseService, AuthService

	{
		private readonly IHttpClientFactory _clientFactory;
		private string villaUrl;
		public AuthServices(IHttpClientFactory clientFactory , IConfiguration configuration)
		{
			_clientFactory = clientFactory;
			villaUrl = configuration.GetValue<string>("ServiceUrls:VillaAPI");
		}
		public Task<T> LoginAsync<T>(LoginRequestDTO obj )
		{
			return SendAsync<T>(new Models.APIRequest()
			{
				ApiType =SD.ApiType.POST,
				Data = obj,
				Url = villaUrl + "/api/UsersAuth/login"
			});
		}
		public Task<T>RegisterAsync<T>(RegisterationRequestDTO objToCreate)
		{
			return SendAsync<T>(new Models.APIRequest()
			{
				ApiType = SD.ApiType.POST,
				Data = dto,
				Url = villaUrl + "/api/villarNumberAPI"
			});
		}

	}
}
