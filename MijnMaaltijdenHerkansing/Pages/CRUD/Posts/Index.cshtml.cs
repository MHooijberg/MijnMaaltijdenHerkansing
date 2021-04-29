using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MijnMaaltijdenHerkansing.Data;
using MijnMaaltijdenHerkansing.Models;

namespace MijnMaaltijdenHerkansing.Pages.CRUD.Posts
{
    public class IndexModel : PageModel
    {
        private readonly MijnMaaltijdenHerkansing.Data.MijnMaaltijdenHerkansingContext _context;

        public IndexModel(MijnMaaltijdenHerkansing.Data.MijnMaaltijdenHerkansingContext context)
        {
            _context = context;
        }

        public IList<Post> Post { get;set; }

        public async Task OnGetAsync()
        {
            Post = await _context.Posts
                .Include(p => p.Gebruiker)
                .Include(p => p.Maaltijd).ToListAsync();
        }
    }
}
