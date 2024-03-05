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
    public class BreadTrackerContext : DbContext
    {
        public DbSet<Bread>? Breads { get; set; }

        public BreadTrackerContext(DbContextOptions<BreadTrackerContext> options)
            : base(options)
        {
        }
    }
}
