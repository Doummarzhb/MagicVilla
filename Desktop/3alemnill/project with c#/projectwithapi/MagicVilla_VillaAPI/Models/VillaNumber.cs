using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MagicVilla_VillaAPI.Models
{
	public class VillaNumber
	{
		[Key , DatabaseGenerated(DatabaseGeneratedOption.None)]
		 public int VillaNo { get; set; }

		public string SpecialDetails { get; set; }

		public DateTime CreateDate { get; set; }

		public DateTime UpdateDate { get; set; }

	 

			 



		
	}
}
