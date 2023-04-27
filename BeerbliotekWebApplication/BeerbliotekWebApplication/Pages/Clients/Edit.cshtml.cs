using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MySql.Data.MySqlClient;

namespace BeerbliotekWebApplication.Pages.Clients
{
    public class EditModel : PageModel
    {
		public ClientInfo clientInfo = new ClientInfo();
		public string errorMessage = "";
		public string successMessage = "";

		//db conn
		string server = "localhost";
		string database = "mystore";
		string user = "root";
		string password = "root9";
		//db conn

		public void OnGet()
        {
			//read the id of the client

			//fill the clientInfo object which will be displayed on the page
			string id = Request.Query["id"];

			try
			{
				string connectionString = $"SERVER={server};DATABASE={database};UID={user};PASSWORD={password};";

				using (MySqlConnection connection = new MySqlConnection(connectionString))
				{
					connection.Open();
					string sql = "SELECT * FROM clients WHERE id=@id";
					using (MySqlCommand command = new MySqlCommand(sql, connection))
					{
						command.Parameters.AddWithValue("@id", id);
						using (MySqlDataReader reader = command.ExecuteReader())
						{
							if (reader.Read())
							{
								clientInfo.id = "" + reader.GetInt32(0);
								clientInfo.name = reader.GetString(1);
								clientInfo.email = reader.GetString(2);
								clientInfo.phone = reader.GetString(3);
								clientInfo.address = reader.GetString(4);
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
			clientInfo.id = Request.Form["id"];
			clientInfo.name = Request.Form["name"];
			clientInfo.email = Request.Form["email"];
			clientInfo.phone = Request.Form["phone"];
			clientInfo.address = Request.Form["address"];

			//if any field is empty, display errorMessage
			if (clientInfo.name.Length == 0 || clientInfo.email.Length == 0 ||
				clientInfo.phone.Length == 0 || clientInfo.address.Length == 0)
			{
				errorMessage = "All the fields are required.";
				return;
			}

			try
			{
				string connectionString = $"SERVER={server};DATABASE={database};UID={user};PASSWORD={password};";
				using (MySqlConnection connection = new MySqlConnection(connectionString))
				{
					connection.Open();

					string sql = "UPDATE clients " +
								"SET name=@name, email=@email, phone=@phone, address=@address " +
								"WHERE id=@id";

					using (MySqlCommand command = new MySqlCommand(sql, connection))
					{
						command.Parameters.AddWithValue("@name", clientInfo.name);
						command.Parameters.AddWithValue("@email", clientInfo.email);
						command.Parameters.AddWithValue("@phone", clientInfo.phone);
						command.Parameters.AddWithValue("@address", clientInfo.address);
						command.Parameters.AddWithValue("@id", clientInfo.id);

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
			Response.Redirect("/Clients/Index");

		}

    }
}
