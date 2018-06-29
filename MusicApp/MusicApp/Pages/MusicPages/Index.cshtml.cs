using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MusicApp.Model;

namespace MusicApp.Pages.MusicPages
{
    public class IndexModel : PageModel
    {
        private ApplicationDbContext _db;
        [TempData]
        public String afterAddMessage { get; set; }

        public IndexModel(ApplicationDbContext db)
        {
            _db = db;
        }
        public IEnumerable<Music> myMusic { get; set; }

        
        public async Task OnGet()
        {
            myMusic = await _db.MusicList.ToListAsync();

        }
        public async Task<IActionResult> OnPostDelete(int id)
        {
            var theConnection = _db.MusicList.Find(id);
            _db.MusicList.Remove(theConnection);
            await _db.SaveChangesAsync();
            afterAddMessage = "Music List Deleted Successfully!";
            return RedirectToPage();
        }
    }
}