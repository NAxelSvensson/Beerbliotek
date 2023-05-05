using BeerbliotekWebApplication.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
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
        }
    }
}
