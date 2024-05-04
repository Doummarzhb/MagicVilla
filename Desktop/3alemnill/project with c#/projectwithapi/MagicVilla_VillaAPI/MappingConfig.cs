using AutoMapper;
using MagicVilla_VillaAPI.Models;
using MagicVilla_VillaAPI.Models.Dto;

namespace MagicVilla_Web
{
	public class MappingConfig :Profile 
	{
		public MappingConfig()
		{
			CreateMap < VillaDTO,VillaCreateDTO>().ReverseMap();
			CreateMap<VillaDTO, VillaUpdateDTO>().ReverseMap();

			//CreateMap<Villa, VillaDTO>();
			//CreateMap<VillaDTO, Villa>();
			CreateMap<VillaNumberDTO,VillaNumberCreateDTO>().ReverseMap();
			CreateMap<VillaNumber,VillaNumberUpdateDTO>().ReverseMap ();

			//CreateMap<VillaDTO,VillaCreateDTO>().ReverseMap();
			//CreateMap<VillaDTO, VillaUpdateDTO>().ReverseMap();
		}
	}
}
