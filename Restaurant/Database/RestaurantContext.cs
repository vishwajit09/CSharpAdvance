//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Metadata.Internal;
//using Restaurant.Database.Model;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using Table = Restaurant.Database.Model.Table;

//namespace Restaurant.Database
//{
//    internal class RestaurantContext : DbContext
//    {
//        public DbSet<Table> tables { get; set; }
//        public DbSet<OrderItem> orders { get; set; }
//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//          => optionsBuilder.UseSqlServer($"@\"Server=(localDB)\\MSSQLLocalDB;Database=Restaurant;Trusted_Connection=True;\"");

//    }
//}
