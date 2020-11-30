using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Distribuidora.Models;

namespace Distribuidora.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Distribuidora.Models.Distribuidor> Distribuidor { get; set; }
        public DbSet<Distribuidora.Models.Produto> Produto { get; set; }
    }
}
