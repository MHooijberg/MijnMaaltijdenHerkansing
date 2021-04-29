using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MijnMaaltijdenHerkansing.Pages
{
    public class MaaltijdenModel : PageModel
    {
        private readonly MijnMaaltijdenHerkansing.Data.MijnMaaltijdenHerkansingContext _context;
        [BindProperty]
        public List<Models.Post> Posts { get; set; }
        public MaaltijdenModel(MijnMaaltijdenHerkansing.Data.MijnMaaltijdenHerkansingContext context)
        {
            _context = context;
        }

        public void OnGet()
        {
            Posts = _context.Posts.ToList();
        }

        //public void OnGet()
        //{

        //}
    }
}