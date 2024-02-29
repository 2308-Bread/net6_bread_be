using Microsoft.EntityFrameworkCore;
using net6_bread_be;
using net6_bread_be.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace net6_bread_be
{
	public class CountryTrackerContext : DbContext
    {
        public DbSet<Bread>? Countries { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)

        {
            optionsBuilder.UseNpgsql("Host=localhost;Username=postgres;Password=password123;Database=breadDb").UseSnakeCaseNamingConvention();
        }
    }
}

