using MagicVilla_VillaAPI.Models;
using MagicVilla_VillaAPI.Models.Dto;
using Microsoft.AspNetCore.Identity.Data;

namespace MagicVilla_VillaAPI.Repository
{
	public interface IUserRepository
	{
		 bool IsUniqueUser(string username);

		Task<LoginResponseDTO> Login(LoginRequestDTO loginRequestDTO);

		Task<LocalUser> Register(RegistrationRequestDTO registerationRequestDTO);
	}
}
