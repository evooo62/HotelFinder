using HotelFinder.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotelFinder.DataAccess
{
    public class HotelDbContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            //optionsBuilder.UseSqlServer(@"Server=DESKTOP-QC06IIT\SQLEXPRESS; Database=HotelDb; uid=sa; pwd=1234");
            //optionsBuilder.UseSqlServer("Server=(LocalDB)\\MSSQLLocalDB");
            optionsBuilder.UseNpgsql("User ID=postgres;Password=1234;Server=localhost;Port=5432;Database=dbHotel;Integrated Security=true;Pooling=true;");
        }
        
        public DbSet<Hotel> Hotels { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Hotel>().HasKey(x => x.Id);
        }
    }
}
