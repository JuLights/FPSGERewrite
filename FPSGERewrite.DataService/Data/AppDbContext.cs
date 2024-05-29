using FPSGERewrite.Entities.DbSet;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPSGERewrite.DataService.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {   }
        
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<Keyboard> Keyboard { get; set; }
        public virtual DbSet<Mouse> Mouse { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>()
                .HasKey(k => k.ProductId);

            modelBuilder.Entity<Keyboard>()
                .HasKey(k=>k.KeyboardId);
            
            modelBuilder.Entity<Mouse>()
                .HasKey(m=>m.MouseId);

            modelBuilder.Entity<Product>()
                .HasOne(p => p.Mouse)
                .WithOne(m => m.Product)
                .HasForeignKey<Product>(p => p.MouseId);

            modelBuilder.Entity<Product>()
                .HasOne(p => p.Keyboard)
                .WithOne(k => k.Product)
                .HasForeignKey<Product>(k => k.KeyboardId);
        }

    }
}
