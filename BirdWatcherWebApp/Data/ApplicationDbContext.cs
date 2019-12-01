using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using BirdWatcherWebApp.Models;

namespace BirdWatcherWebApp.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<BirdWatcherWebApp.Models.Bird> Bird { get; set; }
        public DbSet<BirdWatcherWebApp.Models.spotted> spotted { get; set; }
    }
}
