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

        public IdentityUser User { get; set; }
        [Required]
        public string UserId { get; set; }

        public Knjiga Knjiga { get; set; }
        
        [Required]
        public int KnjigaId { get; set; }
        [Required]
        public DateTime datumPosudbe { get; set; }

        public DateTime? datumVraćanja { get; set; }

    }
}
