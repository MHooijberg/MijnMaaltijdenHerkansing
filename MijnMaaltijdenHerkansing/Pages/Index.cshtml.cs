using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using MijnMaaltijdenHerkansing.Data;
using MijnMaaltijdenHerkansing.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MijnMaaltijdenHerkansing.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public readonly MijnMaaltijdenHerkansingContext _context;

        public List<Post> posts { get; set; }

        public IndexModel(ILogger<IndexModel> logger, MijnMaaltijdenHerkansingContext context)
        {
            _logger = logger;
            _context = context;

            posts = context.Posts.ToList();
        }

        public void OnGet()
        {

        }
    }
}
