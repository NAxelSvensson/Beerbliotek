using BeerbliotekWebApplication.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace BeerbliotekWebApplication.Pages.Admin
{
    public class AdminMenuModel : PageModel
    {
        DatabaseContext databaseContext;
        public AdminMenuModel(DatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }
        public List<Beer> ListBeers;

        public void OnGet()
        {
            ListBeers = databaseContext.Beers.ToList();
            /*
            try
            {
                string connectionString = "Data Source = localhost; Initial Catalog = Beerbliotek; Integrated Security = True";

				using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string sql = "SELECT * FROM Beers";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                //save data into object
                                Beer2 beerInfo = new Beer2();

                                //id is of type string, but in the database it is of type int
                                //so we add empty string to be able to convert the int into string
                                beerInfo.Id = "" + reader.GetInt32(0);
                                beerInfo.Name = reader.GetString(1);
                                beerInfo.Alcohol = "" + reader.GetSqlSingle(2);
								beerInfo.Price = "" + reader.GetSqlSingle(3);
								beerInfo.Volume = "" + reader.GetInt32(4);
								beerInfo.Type = "" + reader.GetInt32(5);
								beerInfo.Country = reader.GetString(6);

								listBeers.Add(beerInfo);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {

            }
            */
        }
    }
}
