﻿using SalesWebMvcApp.Models;
using SalesWebMvcApp.Models.Enums;
using System;
using System.Linq;

namespace SalesWebMvcApp.Data
{
    public class SeedingService
    {
        private readonly SalesWebMvcAppContext _context;

        public SeedingService(SalesWebMvcAppContext context)
        {
            _context = context;
        }

        public void Seed()
        {
            if (_context.Department.Any() || _context.Seller.Any() || _context.SalesRecord.Any())
            {
                return; // Database has been seeded 
            }

            var department1 = new Department(1, "Computer");
            var department2 = new Department(2, "Electronic");
            var department3 = new Department(3, "Books");
            var department4 = new Department(4, "Fashion");

            var seller1 = new Seller(1, "Maria", "maria@", new DateTime(1989, 4, 1), 1000.00, department1);
            var seller2 = new Seller(2, "Pedro", "pedro@", new DateTime(1984, 4, 1), 1000.00, department3);
            var seller3 = new Seller(3, "Jose", "jose@", new DateTime(1989, 8, 1), 1000.00, department4);
            var seller4 = new Seller(4, "Joao", "joao@", new DateTime(1989, 4, 11), 1000.00, department2);

            var salesRecord1 = new SalesRecord(1, new DateTime(2018, 6, 3), 11000.00, SaleStatus.BILLED, seller2);
            var salesRecord2 = new SalesRecord(2, new DateTime(2010, 7, 13), 12000.00, SaleStatus.PENDING, seller3);
            var salesRecord3 = new SalesRecord(3, new DateTime(2018, 12, 31), 21000.00, SaleStatus.CANCELED, seller4);
            var salesRecord4 = new SalesRecord(4, new DateTime(2017, 8, 23), 18000.00, SaleStatus.BILLED, seller1);

            _context.Department.AddRange(department1, department2, department3, department4);
            _context.Seller.AddRange(seller1, seller2, seller3, seller4);
            _context.SalesRecord.AddRange(salesRecord1, salesRecord2, salesRecord3, salesRecord4);

            _context.SaveChanges();
        }
    }
}
