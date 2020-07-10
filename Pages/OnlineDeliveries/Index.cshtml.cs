using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Online_Lunch_Delivery_Core_Web_App.BusinessLayer;
using Online_Lunch_Delivery_Core_Web_App.Models;

namespace Online_Lunch_Delivery_Core_Web_App.Pages.OnlineDeliveries
{
    public class IndexModel : PageModel
    {
        private readonly Online_Lunch_Delivery_Core_Web_App.Models.Online_Lunch_Delivery_DataContext _context;

        public IndexModel(Online_Lunch_Delivery_Core_Web_App.Models.Online_Lunch_Delivery_DataContext context)
        {
            _context = context;
        }

        public IList<OnlineDelivery> OnlineDelivery { get;set; }

        public async Task OnGetAsync()
        {
            OnlineDelivery = await _context.OnlineDelivery
                .Include(o => o.Customer)
                .Include(o => o.DeliveryAgent)
                .Include(o => o.LunchPack).ToListAsync();
        }
    }
}
