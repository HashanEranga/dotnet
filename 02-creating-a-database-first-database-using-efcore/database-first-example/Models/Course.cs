using System;
using System.Collections.Generic;

namespace database_first_example.Models
{
    public partial class Course
    {
        public int CourseId { get; set; }
        public string? CourseName { get; set; }
        public int? Credits { get; set; }
    }
}
