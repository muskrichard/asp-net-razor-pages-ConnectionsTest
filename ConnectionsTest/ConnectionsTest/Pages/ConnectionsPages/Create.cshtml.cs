using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConnectionsTest.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ConnectionsTest.Pages.ConnectionsPages
{
    public class CreateModel : PageModel
    {
        private ApplicationDbContext _db;

        public CreateModel(ApplicationDbContext db)
        {
            _db = db;
        }

        [TempData]
        public string afterAddMessage { get; set; }

        [BindProperty]
        public Connections Connection { get; set; }
        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
            {
                // return to the page
                return Page();
            }
            else
            {
                // if it IS valid, then we'll add our Connection
                _db.ConnectionItems.Add(Connection);

                await _db.SaveChangesAsync();

                
                afterAddMessage = "New Connnection made!";

                return RedirectToPage("Index");
            }
        }
    }
}