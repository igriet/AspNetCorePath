using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.Data
{
    public class RestaurantDbContext : DbContext
    {
        public DbSet<Core.Restaurant> Restaurant { get; set; }
    }
}
