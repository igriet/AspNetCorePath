using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Restaurant.Core;
using Restaurant.Data;

namespace Restaurant.Pages.Restaurants
{
    public class EditModel : PageModel
    {
        private IRestaurantData _restaurantData;
        private IHtmlHelper _htmlHelper;

        [BindProperty]//Poder usar esta propiedad con un binding bidireccional(read,update)
        public Core.Restaurant Restaurant { get; set; }
        public IEnumerable<SelectListItem> Cuisines { get; set; }

        public EditModel(IRestaurantData data,IHtmlHelper htmlHelper)
        {
            _restaurantData = data;
            _htmlHelper = htmlHelper;
        }

        public IActionResult OnGet(int restaurantId)
        {
            Cuisines = _htmlHelper.GetEnumSelectList<CuisineType>();
            Restaurant = _restaurantData.GetById(restaurantId);
            if (Restaurant == null)
            {
                return RedirectToPage("./NotFound");
            }

            return Page();
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                Restaurant = _restaurantData.Update(Restaurant);
                return RedirectToPage("./Detail", new { restaurantId = Restaurant.Id });
            }
            Cuisines = _htmlHelper.GetEnumSelectList<CuisineType>();
            return Page();
        }
    }
}