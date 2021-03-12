using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using MedicaTeams.Models;

namespace MedicaTeams.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<MedicaTeams.Models.Venue> Venue { get; set; }
        public DbSet<MedicaTeams.Models.VaccineCandidate> VaccineCandidate { get; set; }
        public DbSet<MedicaTeams.Models.ApplyOnline> ApplyOnlines { get; set; }

    }
}
