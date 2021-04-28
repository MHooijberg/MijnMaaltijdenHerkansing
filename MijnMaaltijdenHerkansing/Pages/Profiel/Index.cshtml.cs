using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace MyMeals.Pages
{
    public class ProfielModel : PageModel
    {
        private readonly MyMeals.Data.MijnMaaltijdContext _context;
        [BindProperty]
        public Models.Gebruiker Gebruiker { get; set; }

        public ProfielModel(MyMeals.Data.MijnMaaltijdContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> OnGetAsync(int? uid)
        {
            if (uid == null)
            {
                return NotFound();
            }

            Gebruiker = await _context.Gebruikers
                .Include(g => g.Adres).FirstOrDefaultAsync(m => m.GebruikerId == uid);

            if (Gebruiker == null)
            {
                return NotFound();
            }
            return Page();

            //DefaultValues();
            //UserName = uid;
        }

        //private void DefaultValues()
        //{
        //    UserName = "Gebruiker";
        //    Location = "Locatie";
        //    Email = "Email";
        //    Phone = "Telefoonnummer";
        //    About = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. " +
        //    "Proin feugiat enim eget massa ornare, a varius justo sagittis. " +
        //    "Interdum et malesuada fames ac ante ipsum primis in faucibus. " +
        //    "Duis magna enim, feugiat a venenatis id, placerat at nulla. " +
        //    "Mauris efficitur ante lorem, non pellentesque libero feugiat ut. " +
        //    "Vivamus interdum porta ex ut fermentum. Sed rhoncus, augue vitae euismod pellentesque, " +
        //    "nunc tortor dapibus nulla, ac condimentum urna ante in leo.Donec quis tristique odio. " +
        //    "Nam vel faucibus libero. Proin tellus sem, venenatis id leo sit amet, " +
        //    "egestas tempus dui.Nam id tempus eros, vel consectetur risus. " +
        //    "Mauris tincidunt feugiat diam nec malesuada. Vestibulum sem dolor, " +
        //    "maximus et pulvinar at, consequat nec neque. " +
        //    "Nunc vel sem at elit placerat mollis.";
        //}
    }
}
