using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
//using MijnMaaltijdenHerkansing.Areas.Identity.Data;
using MijnMaaltijdenHerkansing.Models;

namespace MijnMaaltijdenHerkansing.Data
{
    public class MijnMaaltijdenHerkansingContext : IdentityDbContext<Gebruiker>
    {
        public MijnMaaltijdenHerkansingContext(DbContextOptions<MijnMaaltijdenHerkansingContext> options)
            : base(options)
        {
        }

        public DbSet<Gebruiker> Gebruikers { get; set; }
        public DbSet<Adres> Adressen { get; set; }
        public DbSet<Maaltijd> Maaltijden { get; set; }
        public DbSet<Post> Posts { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
    }
}
