using AutoMapper;
using MagicVilla_VillaAPI.Models;
using MagicVilla_VillaAPI.Models.Dto;
using MagicVilla_Web.Services;
using MagicVilla_Web.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace MagicVilla_VillaAPI.Controllers
{
	public class VillaNumberController : Controller
	{
		private readonly IVillaNumberService _villaNumberService;
		private readonly IMapper _mapper;
		public VillaNumberController(IVillaNumberService villaNumberService, IMapper mapper VillaNumberService, IMapper mapper)
		{
			_villaNumberService = villaNumberService;
			_mapper = mapper;
		}

		public async Task<IActionResult> IndexVilla()
		{
			List<VillaNumberDTO> list = new();
			var response = await _villaNumberService.GetAllAsync<APIResponse>();
			if(response != null && response.IsSuccess) 
			{
				list =JsonConvert.DeserializeObject<List<VillaNumberDTO>>(Convert.ToString(response.Result));
			}
			return View(list);
		}

		public IActionResult Index()
		{
			return View();
		}
	}
}
