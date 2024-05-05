using AutoMapper;
using MagicVilla_VillaAPI.Data;
//using MagicVilla_VillaAPI.Logging;
using MagicVilla_VillaAPI.Models;
using MagicVilla_VillaAPI.Models.Dto;
using MagicVilla_VillaAPI.Repository.IRepository;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Net;

namespace MagicVilla_VillaAPI.Controllers
{
	//[Route("api/[controller]")]
	[Route("api/VillaAPI")]
	[ApiController]
	public class VillaNumberAPIController : ControllerBase
	{
		//private readonly ILogging _logger;
		//private readonly ApplicationDbContext _db;
		protected APIResponse _response;
		private readonly IVillaNumberRepository _dbVillaNumber;
		private readonly IVillaRepository _dbVilla;
		private readonly IMapper _mapper;
		private object updateDTO;

		public object UpdateDTO { get; private set; }

		//public VillaAPIController(ApplicationDbContext db , IMapper mapper)
		//{
		//	_db=db;
		//	_mapper = mapper;

		//}
		public VillaNumberAPIController(IVillaRepository dbVilla, IMapper mapper)
		{
			_dbVilla = dbVilla;
			_mapper = mapper;
			this._response = new APIResponse();

		}
		// public VillaAPIController( )


		//{
		//	_logger = logger;
		//}
		//public readonly ILogger<VillaAPIController> _logger;
		//public VillaAPIController(ILogger<VillaAPIController> logger)
		//{
		//	_logger = logger;
		//}
		[HttpGet]
		[ProducesResponseType(StatusCodes.Status200OK)]
		public async Task<ActionResult<APIResponse>> GetVillas()
		{
			try
			{
				IEnumerable<Villa> villaList = await _dbVilla.GetAllAsync();
				_response.Result = _mapper.Map<List<VillaDTO>>(villaList);
				//_response.StatusCode = System.Net.HttpStatusCode.OK;
				_response.StatusCode = HttpStatusCode.OK;
				return Ok(_response);
			}
			catch (Exception ex)
			{
				_response.IsSuccess = false;
				_response.ErrorMessages
					= new List<string>() { ex.ToString() };
			}
			return _response;
			//return new List<VillaDTO> {`
			//new VillaDTO {Id=1,Name="Pool View" },
			//new VillaDTO { Id=2,Name ="Beach View"}
			//};
			//_logger.Log("Getting all villas", "");
			//return Ok(VillaStore.villaList);
			//IEnumerable<Villa> villaList = await _db.Villas.ToListAsync();

			//IEnumerable<Villa> villaList = await _dbVilla.GetAllAsync();
			//_response.Result = _mapper.Map<List<VillaDTO>>(villaList);
			////_response.StatusCode = System.Net.HttpStatusCode.OK;
			//_response.StatusCode = HttpStatusCode.OK;
			//return Ok(_response);

		}

			//return Ok(_mapper.Map<VillaDTO>(villaList));
			//return Ok(_mapper.Map<VillaDTO>(villaList));

			//return Ok( await _db.Villas.ToListAsync());
		
		[HttpGet("{id:int}", Name = "GetVilla")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		//[ProducesResponseType(200 , Type=typeof(VillaDTO))]
		//[ProducesResponseType(404)]
		//[ProducesResponseType(400)]

		//public  async Task < ActionResult<VillaDTO>> GetVilla(int id)
		public async Task<ActionResult<APIResponse>> GetVilla(int id)

		{
			try
			{
				if (id == 0)
				{
					_response.StatusCode = HttpStatusCode.BadRequest;
					//_logger.LogError("Get villa Error With Id " + id);
					//_logger.Log("Get villa Error With Id " + id,"error");
					return BadRequest(_response);
				}
				// var villa = VillaStore.villaList.FirstOrDefault(u => u.Id == id);
				//var villa = await _db.Villas.FirstOrDefaultAsync(u => u.Id == id);
				var villa = await _dbVilla.Get(u => u.Id == id);


				if (villa == null)
				{
					_response.StatusCode = HttpStatusCode.NotFound;
					return NotFound(_response);
				}
				_response.Result = _mapper.Map<VillaDTO>(villa);
				_response.StatusCode = HttpStatusCode.OK;
				return Ok(_response);
			}
			catch (Exception ex)
			{
				_response.IsSuccess = false;
				_response.ErrorMessages
					= new List<string>() { ex.ToString() };
			}
			return _response;
			//return Ok(VillaStore.villaList.FirstOrDefault(u => u.Id == id));
			//IEnumerable<Villa> villaList = await _dbVilla.GetAllAsync();
			//_response.Result = _mapper.Map<VillaDTO>(villa);
			////_response.StatusCode = System.Net.HttpStatusCode.OK;
			//_response.StatusCode = HttpStatusCode.OK;
			//return Ok(_response);
			//return Ok(_mapper.Map<VillaDTO>(villa));
		}


		[HttpPost]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		//public async Task <ActionResult<VillaDTO>> CreateVilla([FromBody] VillaCreateDTO createDTO)
		public async Task<ActionResult<APIResponse>> CreateVilla([FromBody] VillaCreateDTO createDTO)
		{
			try
			{
				//if (!ModelState.IsValid)
				//{
				//	return BadRequest(ModelState);
				//}
				if (await _dbVilla.GetAsync(u => u.Name.ToLower() == createDTO.Name.ToLower()) != null)
				{
					ModelState.AddModelError("CustomError", "Villa already Exists!");
					return BadRequest(ModelState);
				}
				if (createDTO == null)
				{
					return BadRequest(createDTO);
				}
				//if (villaDTO.Id > 0)
				//{
				//	return StatusCode(StatusCodes.Status500InternalServerError);
				//}
				//Villa model = _mapper.Map<Villa>(createDTO);
				Villa villa = _mapper.Map<Villa>(createDTO);

				//Villa model = new()
				//{
				//	Amenity = villaDTO.Amenity,
				//	Details = villaDTO.Details,
				//	Id = villaDTO.Id,
				//	ImageUrl = villaDTO.ImageUrl,
				//	Name = villaDTO.Name,
				//	Occupancy = villaDTO.Occupancy,
				//	Rate = villaDTO.Rate,
				//	Sqft = villaDTO.Sqft,
				//};
				//await _db.Villas.AddAsync(model);
				//await _db.SaveChangesAsync();

				await _dbVilla.CreateAsync(villa);

				//IEnumerable<Villa> villaList = await _dbVilla.GetAllAsync();
				_response.Result = _mapper.Map<VillaDTO>(villa);
				//_response.StatusCode = HttpStatusCode.OK;
				_response.StatusCode = HttpStatusCode.Created;
				//return Ok(_response);



				//villaDTO.Id = VillaStore.villaList.OrderByDescending(u => u.Id).FirstOrDefault().Id + 1;
				//VillaStore.villaList.Add(villaDTO);
				//_db.Villas.Add(villaDTO);


				return CreatedAtRoute("GetVilla", new { id = villa.Id }, _response);
			}
			catch (Exception ex)
			{
				_response.IsSuccess = false;
				_response.ErrorMessages
					= new List<string>() { ex.ToString() };
			}
			return _response;

		}


		[ProducesResponseType(StatusCodes.Status204NoContent)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]

		[HttpDelete("{id:int}", Name = "DeleteVilla")]
		public async Task<ActionResult<APIResponse>> DeleteVilla(int id)
		{
			try
			{
				if (id == 0)
				{
					return BadRequest();
				}
				//var villa = await _db.Villas.FirstOrDefaultAsync(u => u.Id == id);
				var villa = await _dbVilla.GetAsync(u => u.Id == id);
				if (villa == null)
				{
					return NotFound();

				}
				await _dbVilla.RemoveAsync(villa);


				//return NoContent();
				_response.StatusCode = HttpStatusCode.NoContent;
				_response.IsSuccess = true;
				return Ok(_response);
			}
			catch (Exception ex)
			{
				_response.IsSuccess = false;
				_response.ErrorMessages
					= new List<string>() { ex.ToString() };
			}
			return _response;

		}


		[HttpPut("{id:int}", Name = "UpdateVilla")]


		[ProducesResponseType(StatusCodes.Status204NoContent)]

		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		public async Task  <ActionResult<APIResponse>> UpdateVilla(int id, [FromBody] VillaUpdateDTO villaDTO)
		{
			try
			{
				if (UpdateDTO == null || id != updateDTO.Id)
				{
					return BadRequest();
				}
				Villa model = _mapper.Map<Villa>(updateDTO);
				//var villa = VillaStore.villaList.FirstOrDefault(u => u.Id == id);
				await _dbVilla.UpdateAsync(model);
				_response.StatusCode = HttpStatusCode.NoContent;
				_response.IsSuccess = true;
				return Ok(_response);
				//villa.Name = villaDTO.Name;
				//villa.Sqft = villaDTO.Sqft;
				//villa.Occupancy = villaDTO.Occupancy;
				//villa.Occupancy=villaDTO.Occupancy;
				//Villa model = new Villa()
				//{
				//	Amenity = villaDTO.Amenity,
				//	Details = villaDTO.Details,
				//	Id = villaDTO.Id,
				//	ImageUrl = villaDTO.ImageUrl,
				//	Name = villaDTO.Name,
				//	Occupancy = villaDTO.Occupancy,
				//	Rate = villaDTO.Rate,
				//	Sqft = villaDTO.Sqft,
				//};
				//await 	_dbVilla.UpdateAsync(model);
				//await _db.SaveChangesAsync();
				//return NoContent();
			}
			catch (Exception ex)
			{
				_response.IsSuccess = false;
				_response.ErrorMessages
					= new List<string>() { ex.ToString() };
			}
			return _response;
		}

		[HttpPatch("{id:int}", Name = "UpdatePartialVilla")]

		[ProducesResponseType(StatusCodes.Status204NoContent)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		public async Task <IActionResult> UpdatePartialVilla(int id, JsonPatchDocument<VillaUpdateDTO> patchDTO)
		{
			if (patchDTO == null || id == 0)
			{
				return BadRequest();
			}
			// var villa =VillaStore.villaList.FirstOrDefault(u => u.Id == id);
			var villa = await _dbVilla.GetAsync(u => u.Id == id, tracked :false);
			//villa.Name = "new name";
			//_db.SaveChanges();

			VillaUpdateDTO villaDTO = _mapper.Map<VillaUpdateDTO>(villa);
			   
			//VillaUpdateDTO villaDTO = new ()
			//{
			//	Amenity = villa.Amenity,
			//	Details = villa.Details,
			//	Id = villa.Id,
			//	ImageUrl = villa.ImageUrl,
			//	Name = villa.Name,
			//	Occupancy = villa.Occupancy,
			//	Rate = villa.Rate,
			//	Sqft = villa.Sqft,
			//};

			if (villa == null )
			{
				return BadRequest();

			}

			//var villa = _db.Villas.FirstOrDefault(u => u.Id == id);
			patchDTO.ApplyTo(villaDTO, ModelState);
			//patchDTO.ApplyTo(VillaDTO, ModelState);
			Villa model =_mapper.Map<Villa>(villaDTO);

			//VillaDTO model = new Villa()
			//{
			//	Amenity = villaDTO.Amenity,
			//	Details = villaDTO.Details,
			//	Id = villaDTO.Id,
			//	ImageUrl = villaDTO.ImageUrl,
			//	Name = villaDTO.Name,
			//	Occupancy = villaDTO.Occupancy,
			//	Rate = villaDTO.Rate,
			//	Sqft = villaDTO.Sqft,
			//};
			//_db.Villas.Update(model);
			//await _db.SaveChangesAsync();

			await _dbVilla.UpdateAsync(model);

			//_db.Villas.Update(model);
			//_db.SaveChanges();
			if (!ModelState.IsValid) 
			{
				return BadRequest(ModelState);
			}
			return NoContent() ;

		}
	}

}
