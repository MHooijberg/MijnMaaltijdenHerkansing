using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace MijnMaaltijdenHerkansing.Models
{
    // Add profile data for application users by adding properties to the Gebruiker class
    public class Gebruiker : IdentityUser
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public int AdresId { get; set; }
        [ForeignKey("AdresId")]
        public Adres Adres { get; set; }
    }
}
