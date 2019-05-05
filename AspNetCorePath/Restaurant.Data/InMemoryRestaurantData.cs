using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Restaurant.Core;

namespace Restaurant.Data
{
    public class InMemoryRestaurantData : IRestaurantData
    {
        public readonly List<Core.Restaurant> restaurants;

        public InMemoryRestaurantData()
        {
            restaurants = new List<Core.Restaurant>() {
                new Core.Restaurant { Id = 1, Name = "Domino's Pizza", Location = "Seattle", Cuisine = CuisineType.Italian },
                new Core.Restaurant { Id = 2, Name = "Apu's Home", Location = "Delhi", Cuisine = CuisineType.Indian },
                new Core.Restaurant { Id = 3, Name = "Chon&Chano", Location = "CDMX", Cuisine = CuisineType.Mexican },
                new Core.Restaurant { Id = 4, Name = "El Pechugon", Location = "Tlaquepaque", Cuisine = CuisineType.None }
            };
        }

        public IEnumerable<Core.Restaurant> GetAll()
        {
            return from r in restaurants
                   orderby r.Name
                   select r;
        }

        public IEnumerable<Core.Restaurant> GetRestaurantByName(string name = null)
        {
            return from r in restaurants
                   where string.IsNullOrEmpty(name) || r.Name.StartsWith(name)
                   orderby r.Name
                   select r;
        }
    }
}
