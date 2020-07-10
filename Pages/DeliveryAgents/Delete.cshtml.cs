using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Online_Lunch_Delivery_Core_Web_App.BusinessLayer;
using Online_Lunch_Delivery_Core_Web_App.Models;

namespace Online_Lunch_Delivery_Core_Web_App.Pages.DeliveryAgents
{
    public class DeleteModel : PageModel
    {
        private readonly Online_Lunch_Delivery_Core_Web_App.Models.Online_Lunch_Delivery_DataContext _context;

        public DeleteModel(Online_Lunch_Delivery_Core_Web_App.Models.Online_Lunch_Delivery_DataContext context)
        {
            _context = context;
        }

        [BindProperty]
        public DeliveryAgent DeliveryAgent { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            DeliveryAgent = await _context.DeliveryAgent.FirstOrDefaultAsync(m => m.Id == id);

            if (DeliveryAgent == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            DeliveryAgent = await _context.DeliveryAgent.FindAsync(id);

            if (DeliveryAgent != null)
            {
                _context.DeliveryAgent.Remove(DeliveryAgent);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
