using System;
using System.ComponentModel.DataAnnotations;

namespace net6_bread_be.Models
{
	public class Country
	{
		public int CountryId { get; set; }
		[Required(ErrorMessage = "Name is require")]
		public string Name { get; set; } = "";
		[Required(ErrorMessage = "Description is required")]
		public string Description { get; set; } = "";
	}
}

