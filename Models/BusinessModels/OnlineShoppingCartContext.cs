using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShoppingCart.Models.BusinessModels
{
    public class OnlineShoppingCartContext:DbContext
    {
        public OnlineShoppingCartContext(DbContextOptions<OnlineShoppingCartContext> options) : base(options)
        {

        }
        public DbSet<Administrative_regions> Administrative_Regions { get; set; }
        public DbSet<Administrative_units> Administrative_Units { get; set; }
        public DbSet<Categories> Categories { get; set; }
        public DbSet<Discounts> Discounts { get; set; }
        public DbSet<Districts> Districts { get; set; }
        public DbSet<FeedBacks> FeedBacks { get; set; }
        public DbSet<Products> Products { get; set; }
        public DbSet<Provinces> Provinces { get; set; }
        public DbSet<Users> Users { get; set; }
        public DbSet<Wards> Wards { get; set; }
    }
}
