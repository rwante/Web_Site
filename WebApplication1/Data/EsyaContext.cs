﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Data
{
    public class EsyaContext : DbContext
    {
        public EsyaContext (DbContextOptions<EsyaContext> options)
            : base(options)
        {
        }

        public DbSet<WebApplication1.Models.Esya> Esyalar { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder) { modelBuilder.Entity<Esya>().ToTable("Esya"); }
    }
}
