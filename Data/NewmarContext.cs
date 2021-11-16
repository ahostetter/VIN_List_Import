using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Newmar.Models;

namespace Newmar.Data
{
    public class NewmarContext : DbContext
    {
        public NewmarContext (DbContextOptions<NewmarContext> options)
            : base(options)
        {
        }

        public DbSet<Newmar.Models.VIN> VIN { get; set; }
    }
}
