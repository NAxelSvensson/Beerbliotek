using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MySql.Data.MySqlClient;

namespace BeerbliotekWebApplication.Pages.Clients
{
    public class CreateModel : PageModel
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
        }

		public void OnPost()
		{
            //link the clientinfo parameters with the html form parameters
            clientInfo.name = Request.Form["name"];
            clientInfo.email = Request.Form["email"];
            clientInfo.phone = Request.Form["phone"];
            clientInfo.address = Request.Form["address"];

            //if one of the fields are empty, display errorMessage to the user
            if(clientInfo.name.Length == 0 || clientInfo.email.Length == 0 ||
                clientInfo.phone.Length == 0 || clientInfo.address.Length == 0)
            {
                errorMessage = "All the fields are required.";
                return;
			}

			//save the new client into the database
			try
            {
				string connectionString = $"SERVER={server};DATABASE={database};UID={user};PASSWORD={password};";
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    string sql = "INSERT INTO clients " +
                        "(name, email, phone, address) VALUES " +
                        "(@name, @email, @phone, @address);";

                    //replace @name, @email parameters with what the user entered into the form

                    using(MySqlCommand command = new MySqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@name", clientInfo.name);
                        command.Parameters.AddWithValue("@email", clientInfo.email);
                        command.Parameters.AddWithValue("@phone", clientInfo.phone);
                        command.Parameters.AddWithValue("@address", clientInfo.address);

                        //execute query
                        command.ExecuteNonQuery();
                    }
                }
			}
            catch (Exception ex)
            {
                //fill the errorMessage with the error of the Exception
                errorMessage = ex.Message;
                return;
            }

            //clear the fields of the clientInfo object
            clientInfo.name = ""; clientInfo.email = ""; clientInfo.phone = ""; clientInfo.address = "";
            successMessage = "New client added successfully.";
		}
	}
}
