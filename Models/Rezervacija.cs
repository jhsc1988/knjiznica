using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace knjiznica.Models
{
    public class Rezervacija
    {
        public int Id { get; set; }
        public Knjiga Knjiga { get; set; }
        public int KnjigaId { get; set; }
        public DateTime datumRezervacija { get; set; }
        public IdentityUser User { get; set; }
        public string UserId { get; set; }

    }
}
