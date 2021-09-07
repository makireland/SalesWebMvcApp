﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SalesWebMvcApp.Models;

namespace SalesWebMvcApp.Data
{
    public class SalesWebMvcAppContext : DbContext
    {
        public SalesWebMvcAppContext (DbContextOptions<SalesWebMvcAppContext> options)
            : base(options)
        {
        }

        public DbSet<Department> Department { get; set; }
        public DbSet<Seller> Seller { get; set; }
        public DbSet<SalesRecord> SalesRecord { get; set; }
    }
}
