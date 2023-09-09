using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education.Application.DTOs
{
    public class CourseDto
    {
        public Guid CourseId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime? PublishedDate { get; set; }
        public Decimal Price { get; set; }
        public Decimal Hour { get; set; }
        public Decimal HourOne { get; set; }
        public Decimal HourTow { get; set; }
    }
}
