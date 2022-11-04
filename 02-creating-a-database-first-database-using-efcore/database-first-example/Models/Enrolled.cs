using System;
using System.Collections.Generic;

namespace database_first_example.Models
{
    public partial class Enrolled
    {
        public int StudentId { get; set; }
        public int CourseId { get; set; }
        public int? Grade { get; set; }
    }
}
