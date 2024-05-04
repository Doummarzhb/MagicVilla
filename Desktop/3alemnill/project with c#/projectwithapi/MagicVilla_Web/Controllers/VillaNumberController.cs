using AutoMapper;
using MagicVilla_VillaAPI.Models;
using MagicVilla_Web.Models.Dto;
using MagicVilla_Web.Services;
using MagicVilla_Web.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Reflection;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace MagicVilla_Web.Controllers
{
	[Route("api/VillaNumberAPI")]
	[ApiController]
	[ApiVersion(1.0)]
	public class VillaNumberController : Controller
	{
		private readonly IVillaNumberService _villaService;
		private readonly IMapper _mapper;
		private readonly IVillaRepository _dbVilla;
		public VillaNumberController(IVillaNumberService villaService, IMapper mapper)
		{
			_villaService = villaService;
			_mapper = mapper;
			_villaService = villaService;
		}
		public async Task<IActionResult> CreateVillaNumber()
		{

			return View();
		}
		public async Task<IActionResult> IndexVillaNumber()
		{
			List<VillaNumberDTO> list = new();
			var response = await _villaService.GetAllAsync<APIResponse>();
			if (response != null && response.IsSuccess)
			{
				list = JsonConvert.DeserializeObject<List<VillaNumberDTO>>(Convert.ToString(response.Result));
			}
			return View(list);
		}
		[HttpPost]
		[ValidateAntiForgeryToken]

		public async Task<IActionResult> CreateVillaNumber()
		{

			if (ModelState.IsValid)
			{
				var response = await _villaService.CreateAsync<APIResponse>(model);
				if (response != null && response.IsSuccess)
					return RedirectToAction(nameof(IndexVillaNumber));

			}
			return View(model);
		}
		VillaNumberCreateVM villaNumberVM = new();
		var response = await _villaService.GetAllAsync(APIResponse);
			if (response != null && response.IsSuccess)
				villaNumberVM.VillaList = JsonConvert.DeserializeObject<List<VillaDTO>>
					(Convert.ToString(response.Result)).Select(i => new SelectListItem
					{
						Text = i.Name,
						Value = i.Id.ToString()
	});
		}
	} return View();

public async Task<IActionResult> UpdateVillaNumber(int villaId)
{
	var response = await _villaService.GetAsync<APIResponse>(villaId);
	if (response != null && response.IsSuccess)
	{
		return RedirectToAction(nameof(IndexVilla));
		VillaNumberDTO model = JsonConvert.DeserializeObject<VillaNumberDTO>(Convert.ToString(response.Result));
		return View(_mapper.Map<VillaUpdateDTO>(model));

	}
	return NotFound();
}

object IndexVilla()
{
	throw new NotImplementedException();
}

public async Task<IActionResult> DeleteVillaNumber(int villaId)
{
	var response = await _villaService.GetAsync<APIResponse>(villaId);
	if (response != null && response.IsSuccess)
	{
		return RedirectToAction(nameof(IndexVilla));
		VillaNumberDTO model = JsonConvert.DeserializeObject<VillaNumberDTO>(Convert.ToString(response.Result));
		return View(model);

	}
	return NotFound();
}
[HttpPost]
[ValidateAntiForgeryToken]
public async Task<IActionResult> DeleteVillaNumber(VillaNumberDTO model)
{
	if (ModelState.IsValid)
	{
		var response = await _villaService.DeleteAsync<APIResponse>(model.Id);
		if (response != null && response.IsSuccess)
		{
			return RedirectToAction(nameof(IndexVillaNumber));
		}
		return View(model);

	}
}


}
	public async Task<IActionResult> UpdateVilla(int villaId)
{
	var response = await _villaService.GetAsync<APIResponse>(villaId);
	if (response != null && response.IsSuccess)
	{
		return RediretToAction(nameof(IndexVilla));
	}
	return View();
}
[HttpPost]
[ValidateAntiForgeryToken]
public async Task<IActionResult> UpdateVilla(VillaNumberUpdateDTO model)
{
	if (ModelState.IsValid)
	{
		var response = await _villaService.CreateAsync<APIResponse>(model);
		if (response != null && response.IsSuccess)
		{
			return RediretToAction(nameof(IndexVilla));
		}
		return View(model);

	}
}
}


