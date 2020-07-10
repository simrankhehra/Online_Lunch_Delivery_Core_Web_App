using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Online_Lunch_Delivery_Core_Web_App.BusinessLayer
{
    public class OnlineDelivery
    {
        public int Id { get; set; }

        public int DeliveryAgentId { get; set; }

        public int LunchPackId { get; set; }

        public int CustomerId { get; set; }


        public DeliveryAgent DeliveryAgent { get; set;  }

        public Customer Customer { get; set; }

        public LunchPack LunchPack { get; set; }


        public int NumberOfPacks { get; set;  } 

        public string Address { get; set; }


        [NotMapped]
        public decimal TotalPrice { get {

                return this.LunchPack.Price * this.NumberOfPacks;
            
            } }


    }
}
