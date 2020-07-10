using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Online_Lunch_Delivery_Core_Web_App.BusinessLayer;

namespace Online_Lunch_Delivery_Core_Web_App.Models
{
    public class Online_Lunch_Delivery_DataContext : DbContext
    {
        public Online_Lunch_Delivery_DataContext (DbContextOptions<Online_Lunch_Delivery_DataContext> options)
            : base(options)
        {
        }

        public DbSet<Online_Lunch_Delivery_Core_Web_App.BusinessLayer.Customer> Customer { get; set; }

        public DbSet<Online_Lunch_Delivery_Core_Web_App.BusinessLayer.DeliveryAgent> DeliveryAgent { get; set; }

        public DbSet<Online_Lunch_Delivery_Core_Web_App.BusinessLayer.LunchPack> LunchPack { get; set; }

        public DbSet<Online_Lunch_Delivery_Core_Web_App.BusinessLayer.OnlineDelivery> OnlineDelivery { get; set; }
    }
}
