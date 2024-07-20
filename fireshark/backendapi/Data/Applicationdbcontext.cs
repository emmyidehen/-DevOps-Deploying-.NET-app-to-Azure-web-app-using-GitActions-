using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backendapi.Models;
using Microsoft.EntityFrameworkCore;

namespace backendapi.Data
{
    public class Applicationdbcontext : DbContext
    {
        public Applicationdbcontext(DbContextOptions dbContextOptions)
        : base(dbContextOptions)
        {
            
        }

        public DbSet<Stock> Stock { get; set;}

        public DbSet<comment> Comments { get; set;}

    }
}