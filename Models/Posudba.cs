using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace knjiznica.Models
{
    public class Posudba
    {
        public int Id { get; set; }
        [Display(Name = "Korisnik")]
        public IdentityUser User { get; set; }
        [Required]
        [Display(Name = "Korisnik")]
        public string UserId { get; set; }
        [Display(Name = "Naslov")]
        public Knjiga Knjiga { get; set; }
        [Required]
        [Display(Name = "Naslov")]
        public int KnjigaId { get; set; }
        [Required]
        [Display(Name ="Datum Posudbe")]
        public DateTime datumPosudbe { get; set; }
        [Display(Name = "Datum Vraćanja")]
        public DateTime? datumVraćanja { get; set; }

    }
}
