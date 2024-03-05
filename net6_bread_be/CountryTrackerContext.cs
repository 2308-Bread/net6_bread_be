﻿using Microsoft.EntityFrameworkCore;
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
        public DbSet<Country>? Countries { get; set; }

        public CountryTrackerContext(DbContextOptions<CountryTrackerContext> options)
           : base(options)
        {
        }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)

        //{
        //    optionsBuilder.UseNpgsql("Host=localhost;Username=postgres;Password=password123;Database=net6_bread_be").UseSnakeCaseNamingConvention();
        //}
    }
}

