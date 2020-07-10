using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Online_Lunch_Delivery_Core_Web_App.BusinessLayer;
using Online_Lunch_Delivery_Core_Web_App.Models;

namespace Online_Lunch_Delivery_Core_Web_App.Pages.DeliveryAgents
{
    public class EditModel : PageModel
    {
        private readonly Online_Lunch_Delivery_Core_Web_App.Models.Online_Lunch_Delivery_DataContext _context;

        public EditModel(Online_Lunch_Delivery_Core_Web_App.Models.Online_Lunch_Delivery_DataContext context)
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

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(DeliveryAgent).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DeliveryAgentExists(DeliveryAgent.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool DeliveryAgentExists(int id)
        {
            return _context.DeliveryAgent.Any(e => e.Id == id);
        }
    }
}
