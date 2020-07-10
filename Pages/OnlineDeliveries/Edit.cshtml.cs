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

namespace Online_Lunch_Delivery_Core_Web_App.Pages.OnlineDeliveries
{
    public class EditModel : PageModel
    {
        private readonly Online_Lunch_Delivery_Core_Web_App.Models.Online_Lunch_Delivery_DataContext _context;

        public EditModel(Online_Lunch_Delivery_Core_Web_App.Models.Online_Lunch_Delivery_DataContext context)
        {
            _context = context;
        }

        [BindProperty]
        public OnlineDelivery OnlineDelivery { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            OnlineDelivery = await _context.OnlineDelivery
                .Include(o => o.Customer)
                .Include(o => o.DeliveryAgent)
                .Include(o => o.LunchPack).FirstOrDefaultAsync(m => m.Id == id);

            if (OnlineDelivery == null)
            {
                return NotFound();
            }
           ViewData["CustomerId"] = new SelectList(_context.Customer, "Id", "Name");
           ViewData["DeliveryAgentId"] = new SelectList(_context.DeliveryAgent, "Id", "Name");
           ViewData["LunchPackId"] = new SelectList(_context.LunchPack, "Id", "Description");
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

            _context.Attach(OnlineDelivery).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OnlineDeliveryExists(OnlineDelivery.Id))
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

        private bool OnlineDeliveryExists(int id)
        {
            return _context.OnlineDelivery.Any(e => e.Id == id);
        }
    }
}
