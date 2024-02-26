using System.ComponentModel.DataAnnotations;

namespace net6_bread_be.Models
{
	public class Bread
	{
		public int BreadId { get; set;}
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; } = "";
        [Required(ErrorMessage = "Recipe is required")]
        public string Recipe { get; set; } = "";
        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; } = "";
	}
}
