using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MijnMaaltijdenHerkansing.Pages
{
    public class NieuweMaaltijdModel : PageModel
    {
        private readonly Data.MijnMaaltijdenHerkansingContext _context;
        [BindProperty]
        public Models.Post Post { get; set; }

        public NieuweMaaltijdModel(Data.MijnMaaltijdenHerkansingContext context)
        {
            _context = context;
        }

        public IActionResult OnGet(int uid)
        {
            Post = _context.Posts.FirstOrDefault(m => m.Naam == "Hallo");
            return Page();
        }
    }
}
