using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Online_Lunch_Delivery_Core_Web_App.BusinessLayer;
using Online_Lunch_Delivery_Core_Web_App.Models;

namespace Online_Lunch_Delivery_Core_Web_App.Pages.Customers
{
    public class IndexModel : PageModel
    {
        private readonly Online_Lunch_Delivery_Core_Web_App.Models.Online_Lunch_Delivery_DataContext _context;

        public IndexModel(Online_Lunch_Delivery_Core_Web_App.Models.Online_Lunch_Delivery_DataContext context)
        {
            _context = context;
        }

        public IList<Customer> Customer { get;set; }

        public async Task OnGetAsync()
        {
            Customer = await (from customer in _context.Customer select customer).ToListAsync();
        }
    }
}
