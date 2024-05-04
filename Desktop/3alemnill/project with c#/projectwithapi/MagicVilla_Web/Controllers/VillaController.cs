using AutoMapper;
using MagicVilla_VillaAPI.Models;
using MagicVilla_Web.Models.Dto;
using MagicVilla_Web.Services;
using MagicVilla_Web.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Reflection;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace MagicVilla_Web.Controllers
{
	public class VillaController : Controller
	{
		private readonly IVillaNumberService _villaService;
		private readonly IMapper _mapper;
		public VillaController(IVillaNumberService villaService, IMapper mapper)
		{
			_villaService = villaService;
			_mapper = mapper;
		}
		public async Task<IActionResult> CreateVilla()
		{

			return View();
		}
		public async Task<IActionResult> IndexVilla()
		{
			List<VillaDTO> list = new();
			var response = await _villaService.GetAllAsync<APIResponse>();
			if (response != null && response.IsSuccess)
			{
				list = JsonConvert.DeserializeObject<List<VillaDTO>>(Convert.ToString(response.Result));
			}
			return View(list);
		}
		[HttpPost]
		[ValidateAntiForgeryToken]

		public async Task<IActionResult> CreateVilla(VillaCreateDTO model)
		{

			if (ModelState.IsValid)
			{
				var response = await _villaService.CreateAsync<APIResponse>(model);
				if (response != null && response.IsSuccess)
					return RedirectToAction(nameof(IndexVilla));

			}
			return View(model);
		}

		public async Task<IActionResult> UpdateVilla(int villaId)
		{
			var response = await _villaService.GetAsync<APIResponse>(villaId);
			if (response != null && response.IsSuccess)
			{
				//return RedirectToAction(nameof(IndexVilla));
				VillaDTO model = JsonConvert.DeserializeObject<VillaDTO>(Convert.ToString(response.Result));	
				return View(_mapper.Map<VillaUpdateDTO>(model));

			}
			return NotFound();
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> UpdateVilla(VillaUpdateDTO model)
		{
			if (ModelState.IsValid)
			{
				var response = await _villaService.UpdateAsync<APIResponse>(model);
				if (response != null && response.IsSuccess)
				{
					return RedirectToAction(nameof(IndexVilla));
				}
				return View(model);

			}
		}
		public async Task<IActionResult> DeleteVilla(int villaId)
		{
			var response = await _villaService.GetAsync<APIResponse>(villaId);
			if (response != null && response.IsSuccess)
			{
				//return RedirectToAction(nameof(IndexVilla));
				VillaDTO model = JsonConvert.DeserializeObject<VillaDTO>(Convert.ToString(response.Result));
				return View(model);

			}
			return NotFound();
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> DeleteVilla(VillaDTO model)
		{
			if (ModelState.IsValid)
			{
				var response = await _villaService.DeleteAsync<APIResponse>(model.Id);
				if (response != null && response.IsSuccess)
				{
					return RedirectToAction(nameof(IndexVilla));
				}
				return View(model);

			}
		}


	}
	//public async Task<IActionResult> UpdateVilla(int villaId)
	//{
	//	var response = await _villaService.GetAsync<APIResponse>(villaId);
	//	if (response != null && response.IsSuccess)
	//	{
	//		return RediretToAction(nameof(IndexVilla));
	//	}
	//	return View();
	//} 
	//[HttpPost]
	//[ValidateAntiForgeryToken]
	//public async Task<IActionResult> UpdateVilla(VillaNumberUpdateDTO model)
	//{
	//	if (ModelState.IsValid)
	//	{
	//		var response = await _villaService.CreateAsync<APIResponse>(model);
	//		if(response !=null && response.IsSuccess)
	//		{
	//			return RediretToAction(nameof(IndexVilla));
	//		}
	//		return View(model);

	//	}
	//}
}


