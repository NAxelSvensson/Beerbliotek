using BeerbliotekWebApplication.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace BeerbliotekWebApplication.Pages.Admin
{
    public class EditModel : PageModel
    {
		public Beer beerInfo = new Beer();
		public string errorMessage = "";
		public string successMessage = "";

		/*
		public void OnGet()
        {
			//read the id of the client

			//fill the clientInfo object which will be displayed on the page
			string id = Request.Query["id"];

			try
			{
				string connectionString = "Data Source = localhost; Initial Catalog = Beerbliotek; Integrated Security = True";

				using (SqlConnection connection = new SqlConnection(connectionString))
				{
					connection.Open();
					string sql = "SELECT * FROM Beers WHERE id=@id";
					using (SqlCommand command = new SqlCommand(sql, connection))
					{
						command.Parameters.AddWithValue("@id", id);
						using (SqlDataReader reader = command.ExecuteReader())
						{
							if (reader.Read())
							{
								beerInfo.Id = "" + reader.GetInt32(0);
								beerInfo.Name = reader.GetString(1);
								beerInfo.Alcohol = "" + reader.GetSqlSingle(2);
								beerInfo.Price = "" + reader.GetSqlSingle(3);
								beerInfo.Volume = "" + reader.GetInt32(4);
								beerInfo.Type = "" + reader.GetInt32(5);
								beerInfo.Country = reader.GetString(6);
							}
						}
					}
				}
			}
			catch (Exception ex)
			{

				errorMessage = ex.Message;
				return;
			}
        }

		public void OnPost() 
		{
			//fill the client info with the data from the form
			beerInfo.Id = Request.Form["Id"];
			beerInfo.Name = Request.Form["Name"];
			beerInfo.Alcohol = Request.Form["Alcohol"];
			beerInfo.Price = Request.Form["Price"];
			beerInfo.Volume = Request.Form["Volume"];
			beerInfo.Type = Request.Form["Type"];
			beerInfo.Country = Request.Form["Country"];

			//if any field is empty, display errorMessage
			if (beerInfo.Name.Length == 0 || beerInfo.Alcohol.Length == 0 ||
				beerInfo.Price.Length == 0 || beerInfo.Volume.Length == 0
				|| beerInfo.Type.Length == 0 || beerInfo.Country.Length == 0)
			{
				errorMessage = "All the fields are required.";
				return;
			}

			try
			{
				string connectionString = "Data Source = localhost; Initial Catalog = Beerbliotek; Integrated Security = True";
				using (SqlConnection connection = new SqlConnection(connectionString))
				{
					connection.Open();

					string sql = "UPDATE Beers " +
								"SET name=@name, alcohol=@alcohol, price=@price, volume=@volume, type=@type, country=@country " +
								"WHERE id=@id";

					using (SqlCommand command = new SqlCommand(sql, connection))
					{
						command.Parameters.AddWithValue("@name", beerInfo.Name);
						command.Parameters.AddWithValue("@alcohol", beerInfo.Alcohol);
						command.Parameters.AddWithValue("@price", beerInfo.Price);
						command.Parameters.AddWithValue("@volume", beerInfo.Volume);
						command.Parameters.AddWithValue("@type", beerInfo.Type);
						command.Parameters.AddWithValue("@country", beerInfo.Country);
						command.Parameters.AddWithValue("@id", beerInfo.Id);

						command.ExecuteNonQuery();
					}
				}
			}
			catch (Exception ex)
			{
				errorMessage = ex.Message;
				return;
			}

			//redirect the user to the list of clients
			Response.Redirect("/Admin/AdminMenu");

		}
		*/

    }
}
