using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MusicApp.Model;

namespace MusicApp.Pages.MusicPages
{
    public class EditModel : PageModel
    {
        private ApplicationDbContext _db;
        public EditModel(ApplicationDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public Music Connection { set; get; }

        [TempData]
        public string afterAddMessage { set; get; }

        public void OnGet(int id)
        {
            Connection = _db.MusicList.Find(id);
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                var ConnectionInDb = _db.MusicList.Find(Connection.ID);
                ConnectionInDb.Album = Connection.Album;
                ConnectionInDb.Artist = Connection.Artist;
                ConnectionInDb.Likes = Connection.Likes;

                await _db.SaveChangesAsync();
                afterAddMessage = "Music List updated successfully!";

                return RedirectToPage("Index");
            }
            else
            {
                return RedirectToPage();
            }
        }
    }
}