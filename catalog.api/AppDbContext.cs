using catalog.api.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace catalog.api
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Producto>(entity =>
            {
                entity.HasKey(x => x.Id);

                entity.ToTable("PRODUCTOS");
            });

            base.OnModelCreating(builder);
        }

        public DbSet<Producto> Productos { get; set; }
    }
}
