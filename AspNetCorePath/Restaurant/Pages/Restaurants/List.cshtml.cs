using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Restaurant.Data;

namespace Restaurant.Pages.Restaurants
{
    public class ListModel : PageModel
    {
        private readonly IConfiguration _configuration;
        private readonly IRestaurantData _restaurantData;
        private readonly ILogger<ListModel> _logger;

        public string Message { get; set; }
        public IEnumerable<Core.Restaurant> Restaurants { get; set; }
        [BindProperty(SupportsGet =true)]
        public string SearchTerm { get; set; }

        public ListModel(IConfiguration configuration,
                            IRestaurantData data,
                            ILogger<ListModel> logger)
        {
            _configuration = configuration;
            _restaurantData = data;
            _logger = logger;
        }

        public void OnGet()
        {
            _logger.LogError("Excecuting List Get");
            Message = _configuration["Message"];//"Hola desde cshtml";
            Restaurants = _restaurantData.GetRestaurantByName(SearchTerm);
        }
    }
}