using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using Restaurant.Data;

namespace Restaurant.Pages.Restaurants
{
    public class ListModel : PageModel
    {
        private readonly IConfiguration _configuration;
        private readonly IRestaurantData _restaurantData;

        public string Message { get; set; }
        public IEnumerable<Core.Restaurant> Restaurants { get; set; }

        public ListModel(IConfiguration configuration,IRestaurantData data)
        {
            _configuration = configuration;
            _restaurantData = data;
        }

        public void OnGet()
        {
            Message = _configuration["Message"];//"Hola desde cshtml";
            Restaurants = _restaurantData.GetAll();
        }
    }
}