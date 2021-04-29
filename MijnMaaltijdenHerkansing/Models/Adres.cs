using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MijnMaaltijdenHerkansing.Models
{
    public class Adres
    {
        public int AdresId { get; set; }
        [Required]
        public string Straat { get; set; }
        [Required]
        public int Huisnummer { get; set; }
        [Required]
        public string Postcode { get; set; }
        [Required]
        public string Woonplaats { get; set; }

        public ICollection<Gebruiker> Gebruikers { get; set; }
    }
}
