using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Restaurant.Data;

namespace Restaurant.Pages.Restaurants
{
    public class DetailModel : PageModel
    {
        public Core.Restaurant Restaurant { get; set; }
        private IRestaurantData _restaurantData;

        public DetailModel(IRestaurantData data)
        {
            _restaurantData = data;
        }

        public IActionResult OnGet(int restaurantId)
        {
            Restaurant = _restaurantData.GetById(restaurantId);
            if (Restaurant == null)
            {
                return RedirectToPage("./NotFound");
            }
            return Page();
        }
    }
}