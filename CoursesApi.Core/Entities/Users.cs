using CoursesApi.Core.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoursesApi.Core.Entities
{
    public class Users : IEntity
    {
        public int Id { get; set; }
        public DateTime VisitTime { get; set; }
        public string WhatRequest { get; set; } = string.Empty;
        public string Browser { get; set; } = string.Empty;
        public string IPAddress { get; set; } = string.Empty;

    }
}
