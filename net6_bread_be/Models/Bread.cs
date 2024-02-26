using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace net6_bread_be.Models
{
	public class Bread
	{
		public int BreadId { get; set;}
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; } = "";
        [Required(ErrorMessage = "Date is required")]
        public string Recipe { get; set; } = "";
		public string Description { get; set; } = "";
	}
}
