using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MijnMaaltijdenHerkansing.Models
{
    public class Maaltijd
    {
        public int MaaltijdId { get; set; }
        [Required]
        public string Naam { get; set; }
        [Required]
        public string Beschrijving { get; set; }
        public string Ingredienten { get; set; }
        [Required]
        public bool IsVegatarisch { get; set; }
        [DataType(DataType.ImageUrl)]
        public string Afbeelding { get; set; }


        public string GebruikerId { get; set; }
        [ForeignKey("GebruikerId")]
        public Gebruiker Gebruiker { get; set; }
        public ICollection<Post> Posts { get; set; }
    }
}
