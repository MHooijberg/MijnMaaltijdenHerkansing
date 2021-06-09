using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MijnMaaltijdenHerkansing.Data;
using MijnMaaltijdenHerkansing.Models;

namespace MijnMaaltijdenHerkansing.Pages
{
    public class MaaltijdenModel : PageModel
    {
        public readonly MijnMaaltijdenHerkansingContext _context;
        [BindProperty]
        public List<Post> Posts { get; set; }

        public MaaltijdenModel(MijnMaaltijdenHerkansingContext context)
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