using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MijnMaaltijdenHerkansing.Pages
{
    public class IndexModel : PageModel
    {
        private readonly MijnMaaltijdenHerkansing.Data.MijnMaaltijdenHerkansingContext _context;
        [BindProperty]
        public List<Models.Post> Posts { get; set; }
        public IndexModel(MijnMaaltijdenHerkansing.Data.MijnMaaltijdenHerkansingContext context)
        {
            _context = context;
        }

        public void OnGet()
        {
            Posts = _context.Posts.ToList();
        }
    }
}
