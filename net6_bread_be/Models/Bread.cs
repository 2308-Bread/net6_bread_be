using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace net6_bread_be.Models
{
	public class Bread
	{
		public int BreadId { get; set;}
		public string Name { get; set; } = "";
		public string Recipe { get; set; } = "";
		public string Description { get; set; } = "";
	}
}
