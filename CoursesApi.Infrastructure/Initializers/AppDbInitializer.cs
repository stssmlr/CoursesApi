using CoursesApi.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoursesApi.Infrastructure.Initializers
{
    internal static class AppDbInitializer
    {
        public static async Task SeedCourses(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Courses>().HasData(new Courses[]
                {
                    new Courses() { Id = 1, Title = "English Courses", 
                        Description = "Learn English Language", 
                        FullText = "Learn English Language To A1-C2 Levels Or Improve Your Skills. We are waiting for your come.",
                        AuthorId = 1, CategoryId = 1 },
                    new Courses() { Id = 2, Title = "German Courses",
                        Description = "Learn German Language",
                        FullText = "Learn German Language To A1-C2 Levels Or Improve Your Skills. We are waiting for your come.",
                        AuthorId = 2, CategoryId = 1 },
                    new Courses() { Id = 3, Title = "Polish Courses",
                        Description = "Learn Polish Language",
                        FullText = "Learn Polish Language To A1-C2 Levels Or Improve Your Skills. We are waiting for your come.",
                        AuthorId = 2, CategoryId = 1 },
                    new Courses() { Id = 4, Title = "Chinese Courses",
                        Description = "Learn Chinese Language",
                        FullText = "Learn Chinese Language To A1-C2 Levels Or Improve Your Skills. We are waiting for your come.",
                        AuthorId = 3, CategoryId = 1 },

                }
            );
        }
        public static async Task SeedAuthors(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author>().HasData(new Author[]
                {
                    new Author(){Id = 1,Name="Bob",Surname = "Parsons", Email = "bobmarv@hotmail.vom",Pseudonym="Scott Carol", Age = 29},
                    new Author(){Id = 2,Name="Carolina",Surname = "Lara", Email = "carolinalara@hotmail.vom",Pseudonym="Kristen Josh", Age = 27},
                    new Author(){Id = 3,Name="Edwin",Surname = "Webster", Email = "edwinweb@hotmail.vom",Pseudonym="Tommy Walker", Age = 36},
                    new Author(){Id = 4,Name="Mata",Surname = "Shibster", Email = "matashr@hotmail.vom",Pseudonym="Tom Hanks", Age = 56} ,
                    new Author(){Id = 5,Name="Edgar",Surname = "Cringo", Email = "edgarcr@hotmail.vom",Pseudonym="Lol Tomphson", Age = 26},
                }
             );
        }
        public static async Task SeedCategory(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(new Category[]
                {
                    new Category() { Id = 1, Name = "Languages Courses" , Description = "Courses telling you about Languages." },
                    new Category() { Id = 2, Name = "Sport Courses" , Description = "Courses telling you about Sports." },
                    new Category() { Id = 3, Name = "IT Courses" , Description = "Courses telling you about IT and Programming." },
                }
            );
        }
    }
}
