using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MijnMaaltijdenHerkansing.Data;
using MijnMaaltijdenHerkansing.Models;

namespace MijnMaaltijdenHerkansing.Areas.Identity.Pages.Account.Manage
{
    public partial class IndexModel : PageModel
    {
        private readonly UserManager<Gebruiker> _userManager;
        private readonly SignInManager<Gebruiker> _signInManager;

        MijnMaaltijdenHerkansingContext mijnMaaltijdenHerkansingContext { get; set; }

        public IndexModel(
            UserManager<Gebruiker> userManager,
            SignInManager<Gebruiker> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public string Username { get; set; }

        [TempData]
        public string StatusMessage { get; set; }

        [BindProperty]
        public InputModel Input { get; set; }

        public class InputModel
        {
            [Required]
            [DataType(DataType.Text)]
            [Display(Name = "First Name")]
            public string FirstName { get; set; }
            [Required]
            [DataType(DataType.Text)]
            [Display(Name = "Last Name")]
            public string LastName { get; set; }

            [Required]
            [DataType(DataType.Text)]
            [Display(Name = "Straat")]
            public string Straat { get; set; }
            [Required]
            [Display(Name = "Huisnummer")]
            public int Huisnummer { get; set; }
            [Required]
            [DataType(DataType.PostalCode)]
            [Display(Name = "Postcode")]
            public string Postcode { get; set; }
            [Required]
            [DataType(DataType.Text)]
            [Display(Name = "Woonplaats")]
            public string Woonplaats { get; set; }
        }

        private async Task LoadAsync(Gebruiker user)
        {
            var userName = await _userManager.GetUserNameAsync(user);

            Username = userName;

            //List<Adres> adressen = mijnMaaltijdenHerkansingContext.Adressen.ToList();

            //user.Adres = mijnMaaltijdenHerkansingContext.Adressen.Where(x => x.AdresId == user.AdresId).First();

            Input = new InputModel
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Straat = user.Adres.Straat,
                Huisnummer = user.Adres.Huisnummer,
                Postcode = user.Adres.Postcode,
                Woonplaats = user.Adres.Woonplaats
            };
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            await LoadAsync(user);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            if (!ModelState.IsValid)
            {
                await LoadAsync(user);
                return Page();
            }

            //var phoneNumber = await _userManager.GetPhoneNumberAsync(user);
            //if (Input.PhoneNumber != phoneNumber)
            //{
            //    var setPhoneResult = await _userManager.SetPhoneNumberAsync(user, Input.PhoneNumber);
            //    if (!setPhoneResult.Succeeded)
            //    {
            //        StatusMessage = "Unexpected error when trying to set phone number.";
            //        return RedirectToPage();
            //    }
            //}

            if (Input.FirstName != user.FirstName)
            {
                user.FirstName = Input.FirstName;
            }
            if (Input.LastName != user.LastName)
            {
                user.LastName = Input.LastName;
            }
            if (Input.Straat != user.Adres.Straat)
            {
                user.Adres.Straat = Input.Straat;
            }
            if (Input.Huisnummer != user.Adres.Huisnummer)
            {
                user.Adres.Huisnummer = Input.Huisnummer;
            }
            if (Input.Postcode != user.Adres.Postcode)
            {
                user.Adres.Postcode = Input.Postcode;
            }
            if (Input.Woonplaats != user.Adres.Woonplaats)
            {
                user.Adres.Woonplaats = Input.Woonplaats;
            }

            await _signInManager.RefreshSignInAsync(user);
            StatusMessage = "Your profile has been updated";
            return RedirectToPage();
        }
    }
}
