using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using knjiznica.Models;

namespace knjiznica.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<knjiznica.Models.Knjiga> Knjiga { get; set; }
        public DbSet<knjiznica.Models.Rezervacija> Rezervacija { get; set; }
    }
}
