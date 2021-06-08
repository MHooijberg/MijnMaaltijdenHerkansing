using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MijnMaaltijdenHerkansing.Data;
using MijnMaaltijdenHerkansing.Models;

namespace MijnMaaltijdenHerkansing.Pages
{
    public class ProfielModel : PageModel
    {
        private readonly MijnMaaltijdenHerkansingContext _context;

        [BindProperty]
        public Guid? _Id { get; set; }

        [BindProperty]
        public Gebruiker Gebruiker { get; set; }

        private readonly UserManager<IdentityUser> _userManager;

        public ProfielModel(MijnMaaltijdenHerkansingContext context)
        {
            _context = context;
            //_userManager = userManager;
        }

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            _Id = id;

            if(id == null)
            {
                return NotFound();
            }

            Gebruiker = _context.Gebruikers.Find(id.ToString());

            if(Gebruiker == null)
            {
                return NotFound();
            }

            Gebruiker.Adres = _context.Adressen.Find(Gebruiker.AdresId);

            return Page();
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
