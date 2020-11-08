using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using MobileStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MobileStore.Context
{
    public class DbContextPhone : DbContext
    {
        public DbSet<Phone> Phones { get; set; }
        public DbSet<Order> Orders { get; set; }

        public DbContextPhone(DbContextOptions<DbContextPhone> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
