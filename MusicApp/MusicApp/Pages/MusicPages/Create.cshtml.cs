using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MusicApp.Model;

namespace MusicApp.Pages.MusicPages
{
    public class CreateModel : PageModel
    {
        private ApplicationDbContext _db;
        public CreateModel(ApplicationDbContext db)
        {
            _db = db;
        }

        [TempData]
        public String afterAddMessage { get; set; }
        [BindProperty]
        public Music Connection { get; set; }
        public void OnGet()
        {
        }
        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            else
            {
                _db.MusicList.Add(Connection);
                await _db.SaveChangesAsync();
                afterAddMessage = "New List Added!";
                return RedirectToPage("Index");
            }

        }
    }
}