﻿using CoursesApi.Core.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoursesApi.Core.DTOs
{
    public class InsertCoursesDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string FullText { get; set; } = string.Empty;
        public int CategoryId { get; set; }
        public int AuthorId { get; set; }
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            InsertCoursesDto other = (InsertCoursesDto)obj;
            return Title == other.Title && Description ==  other.Description && AuthorId == other.AuthorId && CategoryId == other.CategoryId && FullText == other.FullText;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Title, Description, FullText, AuthorId, CategoryId);
        }
    }
}
