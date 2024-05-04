using MagicVilla_VillaAPI.Models;
using MagicVilla_Web.Models.Dto;
using MagicVilla_Web.Services;
using MagicVilla_Web.Services.IServices;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;

namespace MagicVilla_Web.Controllers
{
	public class AuthController : Controller
	{
		private readonly AuthService _authService;
		public AuthController(AuthServicess authService)
		{
			_authService = authService;
		}
		[HttpGet]
		public IActionResult Index()
		{
			LoginRequestDTO obj = new();
			return View(obj);
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Login(LoginRequestDTO obj)
		{
			return View(obj);
		}
		[HttpGet]
		public IActionResult Register()
		{
			return View();

		}

		public Task<IActionResult> Register(RegisterRequest obj)
		{
			return Register(obj, _authService);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Register(RegisterRequest obj, AuthService _authService) 
		{
			APIResponse result = await _authService.RegisterAsync<APIResponse>(obj);
			if(result != null&& result.IsSuccess)
			{
				return RedirectToAction("Login");

			}
			return View();
		}
		public async Task<IActionResult> Logout()
		{
			return View();
		}
		public IActionResult AccessDenied()
		{
			return View();
		}
	}
}
