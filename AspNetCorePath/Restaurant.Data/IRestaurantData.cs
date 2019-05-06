using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.Data
{
    public interface IRestaurantData
    {
        IEnumerable<Core.Restaurant> GetAll();
        IEnumerable<Core.Restaurant> GetRestaurantByName(string name);
        Core.Restaurant GetById(int id);
        Core.Restaurant Update(Core.Restaurant updatedRestaurant);
        Core.Restaurant Add(Core.Restaurant newRestaurant);
        Core.Restaurant Delete(int id);
    }
}
