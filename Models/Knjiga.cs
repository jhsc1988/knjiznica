using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace knjiznica.Models
{
    public class Knjiga
    {
        public int Id { get; set; }

        [Required]
        public string Naslov { get; set; }

        [Required]
        public string Autor { get; set; }

        [Required]
        [Display(Name = "Izdavač")]
        public string Izdavac { get; set; }

        [Required]
        public string ISBN { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Datum Izdavanja")]
        public DateTime DatumIzdavanja { get; set; }

    }
}
