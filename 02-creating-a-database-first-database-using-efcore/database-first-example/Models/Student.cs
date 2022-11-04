using System;
using System.Collections.Generic;

namespace database_first_example.Models
{
    public partial class Student
    {
        public int StudentId { get; set; }
        public string? Name { get; set; }
        public int? Age { get; set; }
    }
}
