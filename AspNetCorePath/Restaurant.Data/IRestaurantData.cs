using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.Data
{
    public interface IRestaurantData
    {
        IEnumerable<Core.Restaurant> GetAll();
        IEnumerable<Core.Restaurant> GetRestaurantByName(string name);
    }
}
