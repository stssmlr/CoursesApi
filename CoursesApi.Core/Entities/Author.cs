using Ardalis.Specification;
using CoursesApi.Core.DTOs;
using CoursesApi.Core.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoursesApi.Core.Entities
{
    public class Author : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Surname { get; set; } = string.Empty;
        public string Pseudonym { get; set; } = string.Empty;
        [EmailAddress]
        public string Email { get; set; } = string.Empty;
        public int Age { get; set; }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            Author other = (Author)obj;
            return Name == other.Name && Surname == other.Surname && Pseudonym == other.Pseudonym && Email == other.Email && Age == other.Age;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Name, Surname, Pseudonym, Email, Age);
        }
    }
}
