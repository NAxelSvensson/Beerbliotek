using System.ComponentModel.DataAnnotations;

namespace BeerbliotekWebApplication.Models
{
	public class Beer2
	{
		/// <summary>
		/// Inside the database the different variables can be whatever type they want.
		/// In our code it's easier to display and work with them as strings that hold a reference to their original type in the database.
		/// </summary>

		[Key]
		public string Id { get; set; }
		[MaxLength(45)]
		public string Name { get; set; }
		public string Alcohol { get; set; }
		public string Price { get; set; }
		public string Volume { get; set; }
		public string Type { get; set; }
		[MaxLength(45)]
		public string Country { get; set; }

	}
}
