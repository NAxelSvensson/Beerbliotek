using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace BeerbliotekWebApplication.Pages.Clients
{
    public class IndexModel : PageModel
    {
        public List<BeerInfo> listBeers = new List<BeerInfo>();

        public void OnGet()
        {
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
                                //save data into clientInfo object
                                BeerInfo beerInfo = new BeerInfo();

                                //id is of type string, but in the database it is of type int
                                //so we add empty string to be able to convert the int into string
                                beerInfo.Id = "" + reader.GetInt32(0);
                                beerInfo.Name = reader.GetString(1);
                                beerInfo.Alcohol = "" + reader.GetSqlSingle(2);
								beerInfo.Price = "" + reader.GetSqlSingle(3);
								beerInfo.Volume = "" + reader.GetInt32(4);
								beerInfo.Type = "" + reader.GetInt32(5);
								beerInfo.Country = reader.GetString(6);

								//now lets add the object to our list
								listBeers.Add(beerInfo);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }
    }

    public class BeerInfo
    {
        public string Id;
        public string Name;
        public string Alcohol;
        public string Price;
        public string Volume;
        public string Type;
        public string Country;

    }

}
