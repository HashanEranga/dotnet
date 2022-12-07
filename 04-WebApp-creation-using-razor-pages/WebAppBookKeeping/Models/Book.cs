using System;
using System.ComponentModel.DataAnnotations;

namespace WebAppBookKeeping.Models
{
    public class Book
    {
        public int Id { get; set; }

        [Required]
        public string? Name { get; set; }

        public BookLang Language { get; set; }

        public string? Author { get; set; }
    }

    public enum BookLang { Sinhala, Tamil, English }

}

