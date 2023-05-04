using BeerbliotekWebApplication.Models;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.IdentityModel.Tokens;
using System.Data.SqlClient;

namespace BeerbliotekWebApplication.Pages.Clients
{
    public class CreateModel : PageModel
    {
        DatabaseContext databaseContext;
        //public Beer beerInfo = new Beer();
        public string errorMessage = "";
        public string successMessage = "";
        public CreateModel(DatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }

        [BindProperty]
        public Beer Beer { get; set; }

		public void OnGet()
        {
        }

		public ActionResult OnPost()
		{
            if (ModelState.IsValid)
            {
                databaseContext.Add(Beer);
                databaseContext.SaveChanges();
                return RedirectToPage("/AdminMenu");
            }
            return Page();

            /*
            //link the clientinfo parameters with the html form parameters
            beerInfo.Name = Request.Form["Name"];
            beerInfo.Alcohol = Request.Form["Alcohol"];
            beerInfo.Price = Request.Form["Price"];
            beerInfo.Volume = Request.Form["Volume"];
            beerInfo.Type = Request.Form["Type"];
            beerInfo.Country = Request.Form["Country"];

            //if one of the fields are empty, display errorMessage to the user
            if(beerInfo.Name.IsNullOrEmpty() || beerInfo.Alcohol.Length == 0 ||
                beerInfo.Price.Length == 0 || beerInfo.Volume.Length == 0
				|| beerInfo.Type.Length == 0 || beerInfo.Country.Length == 0)
            {
                errorMessage = "All the fields are required.";
                return;
			}

			//save the new client into the database
			try
            {
				string connectionString = "Data Source = localhost; Initial Catalog = Beerbliotek; Integrated Security = True";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string sql = "INSERT INTO Beers " +
                        "(Name, Alcohol, Price, Volume, Type, Country) VALUES " +
						"(@name, @alcohol, @price, @volume, @type, @country);";

                    //replace @name, @email parameters with what the user entered into the form

                    using(SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@name", beerInfo.Name);
                        command.Parameters.AddWithValue("@alcohol", beerInfo.Alcohol);
                        command.Parameters.AddWithValue("@price", beerInfo.Price);
                        command.Parameters.AddWithValue("@volume", beerInfo.Volume);
                        command.Parameters.AddWithValue("@type", beerInfo.Type);
                        command.Parameters.AddWithValue("@country", beerInfo.Country);

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
            beerInfo.Name = ""; beerInfo.Alcohol = ""; beerInfo.Price = ""; beerInfo.Volume = ""; beerInfo.Type = ""; beerInfo.Country = "";
            successMessage = "New beer added successfully.";
            */
		}
	}
}
