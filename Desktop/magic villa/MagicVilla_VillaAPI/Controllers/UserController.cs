using MagicVilla_VillaAPI.Models;
using MagicVilla_VillaAPI.Models.Dto;
using MagicVilla_VillaAPI.Repository;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace MagicVilla_VillaAPI.Controllers
{
	[Route("api/UsersAuth")]
	[ApiController]
	public class UserController : Controller
	{
		private readonly IUserRepository _userRepo;
		protected APIResponse _response;
		public UserController(IUserRepository userRepo)
		{
			_userRepo = userRepo;
		}
		[HttpPost("login")]
		public async Task<IActionResult> Login([FromBody] LoginResponseDTO model)
		{
			var LoginResponse = await _userRepo.Login(model);
			if(LoginResponse.User == null || string.IsNullOrEmpty(LoginResponse.Token))
			{
				_response.StatusCode = System.Net.HttpStatusCode.BadRequest;
				_response.IsSuccess = false;
				_response.ErrorMessages.Add("Username or pass is incorrect ");
				return BadRequest(_response); 
				//return BadRequest(new { message = "Username or password is incoreect " });
			}
			_response.StatusCode=HttpStatusCode.OK;
			_response.IsSuccess=true;
			_response.Result = LoginResponse;

			return View();
		}
		[HttpPost("register")]
		public async Task<IActionResult> Register([FromBody] RegistrationRequestDTO model)
		{
			bool ifUserNameUnique = _userRepo.IsUniqueUser(model.UserName);
			if(!ifUserNameUnique) 
			{
				_response.StatusCode=  HttpStatusCode.BadRequest;
				_response.IsSuccess = false;
				_response.ErrorMessages.Add("Username already exists");
				return BadRequest(_response);
			}
			var user = await _userRepo.Register(model);
			if(user == null) {
				_response.StatusCode =  HttpStatusCode.BadRequest;
				_response.IsSuccess = false;
				_response.ErrorMessages.Add("Username already exists");
				return BadRequest(_response);
			}
			_response.StatusCode = HttpStatusCode.OK;
			_response.IsSuccess = true ;
			return Ok(_response);


			//return View();
		}
		public IActionResult Index()
		{
			return View();
		}
	}
}
