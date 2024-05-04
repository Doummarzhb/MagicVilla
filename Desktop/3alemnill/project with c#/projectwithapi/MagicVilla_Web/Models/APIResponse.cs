using System.Net;

namespace MagicVilla_VillaAPI.Models
{
	public class APIResponse
	{
		public HttpStatusCode StatusCode { get; set; }
		public bool IsSuccess { get; set; }	

		public List<string> ErrorMessages { get; set; }

		public object Result { get; set; }

		public static implicit operator APIResponse(void v)
		{
			throw new NotImplementedException();
		}
	}
}
