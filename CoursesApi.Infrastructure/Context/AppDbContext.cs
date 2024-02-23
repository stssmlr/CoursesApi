using CoursesApi.Core.Entities;
using CoursesApi.Infrastructure.Initializers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoursesApi.Infrastructure.Context
{
    internal class AppDbContext : DbContext
    {
        public AppDbContext() : base() { }
        public AppDbContext(DbContextOptions options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Author>()
               .HasIndex(b => b.Pseudonym).IsUnique(true);

            modelBuilder.SeedCourses();
            modelBuilder.SeedAuthors();
            modelBuilder.SeedCategory();
            modelBuilder.SeedUsers();


        }
        public DbSet<Courses> Courses { get; set; }
        public DbSet<Courses> Author { get; set; }
        public DbSet<Courses> Category { get; set; }
        public DbSet<Users> Users { get; set; }

    }
}
