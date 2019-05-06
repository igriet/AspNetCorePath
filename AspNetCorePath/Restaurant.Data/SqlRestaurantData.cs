using System.Collections.Generic;
using System.Linq;

namespace Restaurant.Data
{
    public class SqlRestaurantData : IRestaurantData
    {
        private readonly RestaurantDbContext _context;

        public SqlRestaurantData(RestaurantDbContext context)
        {
            _context = context;
        }

        public Core.Restaurant Add(Core.Restaurant newRestaurant)
        {
            _context.Restaurant.Add(newRestaurant);
            return newRestaurant;
        }

        public int Commit()
        {
            return _context.SaveChanges();
        }

        public Core.Restaurant Delete(int id)
        {
            var restaurant = this.GetById(id);
            if (restaurant != null)
                _context.Restaurant.Remove(restaurant);

            return restaurant;
        }

        public IEnumerable<Core.Restaurant> GetAll()
        {
            return from r in _context.Restaurant
                   orderby r.Name
                   select r;
        }

        public Core.Restaurant GetById(int id)
        {
            return _context.Restaurant.FirstOrDefault(r => r.Id == id);
        }

        public int GetCountRestaurants()
        {
            return _context.Restaurant.Count();
        }

        public IEnumerable<Core.Restaurant> GetRestaurantByName(string name)
        {
            return from r in _context.Restaurant
                   where string.IsNullOrEmpty(name) || r.Name.StartsWith(name)
                   orderby r.Name
                   select r;

        }

        public Core.Restaurant Update(Core.Restaurant updatedRestaurant)
        {
            Core.Restaurant restaurant = _context.Restaurant.FirstOrDefault(r => r.Id == updatedRestaurant.Id);

            if (restaurant != null)
            {
                restaurant.Name = updatedRestaurant.Name;
                restaurant.Location = updatedRestaurant.Location;
                restaurant.Cuisine = updatedRestaurant.Cuisine;
            }

            return restaurant;
        }
    }
}
