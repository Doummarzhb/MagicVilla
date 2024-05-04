using AutoMapper;
using MagicVilla_VillaAPI.Models;
using MagicVilla_VillaAPI.Models.Dto;
using MagicVilla_Web.Models.Dto;

namespace MagicVilla_VillaAPI
{
	public class MappingConfig :Profile 
	{
		public MappingConfig()
		{
			CreateMap<Villa, VillaDTO>();
			CreateMap<VillaDTO, VillaDTO>();

			CreateMap<VillaDTO,VillaCreateDTO>().ReverseMap();
			CreateMap<VillaDTO, VillaUpdateDTO>().ReverseMap();
		}
	}
}
