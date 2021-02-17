using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace knjiznica.Models
{
    public class Rezervacija
    {
        public int Id { get; set; }
        [Display(Name = "Naslov")]
        public Knjiga Knjiga { get; set; }
        [Display(Name = "Naslov")]
        public int KnjigaId { get; set; }

        [Display(Name = "Datum Rezervacije")]
        public DateTime datumRezervacija { get; set; }

        [Display(Name = "Korisnik")]
        public IdentityUser User { get; set; }
        [Display(Name = "Korisnik")]
        public string UserId { get; set; }

    }
}
