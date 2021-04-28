using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MyMeals.Pages
{
    public class MaaltijdenModel : PageModel
    {
        private readonly MyMeals.Data.MijnMaaltijdContext _context;
        [BindProperty]
        public List<Models.Post> Posts { get; set; }
        public MaaltijdenModel(MyMeals.Data.MijnMaaltijdContext context)
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