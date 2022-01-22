using Education.Domain.Validations;
using System.ComponentModel.DataAnnotations;

namespace Education.Domain
{
    public class Course
    {
        [Key]
        public Guid CourseId { get; set; }
        [Required]
        [StringLength(100)]
        public string Title { get; set; }
        [Required]
        [StringLength(200)]
        public string Description { get; set; }
        [DataType(DataType.Date)]
        [DateInFuture]
        public DateTime? PublishedDate { get; set; }
        [DataType(DataType.Date)]
        public DateTime? CreatedDate { get; set; }
        public Decimal Price { get; set; }


    }
}