using Microsoft.AspNetCore.Mvc;
using Restaurant.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Restaurant.Pages.ViewComponents
{
    public class RestaurantCountViewComponent:ViewComponent
    {
        private readonly IRestaurantData _restaurantData;

        public RestaurantCountViewComponent(IRestaurantData data)
        {
            _restaurantData = data;
        }

        public IViewComponentResult Invoke()
        {
            var count = _restaurantData.GetCountRestaurants();
            return View(count);
        }
    }
}
