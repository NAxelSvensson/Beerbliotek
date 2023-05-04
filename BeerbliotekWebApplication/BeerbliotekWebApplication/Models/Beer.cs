using System.ComponentModel.DataAnnotations;

namespace BeerbliotekWebApplication.Models
{
    public class Beer
    {
		[Key]
		public int Id { get; set; }
		[MaxLength(45)]
		public string Name { get; set; }
		public float Alcohol { get; set; }
		public float Price { get; set; }
		public int Volume { get; set; }
		[MaxLength(45)]
		public string Type { get; set; }
		[MaxLength(45)]
		public string Country { get; set; }

	}
}
