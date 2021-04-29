using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MijnMaaltijdenHerkansing.Models
{
    public class Post
    {
        public int PostId { get; set; }
        [Required]
        public string Naam { get; set; }
        [Required]
        public string Beschrijving { get; set; }
        [Required]
        public bool IsBevroren { get; set; }
        [Required]
        public DateTime BereidOp { get; set; }
        [Required]
        public DateTime HoudbaarheidsDatum { get; set; }
        [Required]
        public int aantalPorties { get; set; }
        [Required]
        public int Waardering { get; set; }

        public string GebruikerId { get; set; }
        [ForeignKey("GebruikerId")]
        public Gebruiker Gebruiker { get; set; }
        public int MaaltijdId { get; set; }
        [ForeignKey("MaaltijdId")]
        public Maaltijd Maaltijd { get; set; }
    }
}
