using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library_NPR321.Models
{
    public class Book
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public required string Title { get; set; }
        [MaxLength]
        public string? Description { get; set; }
        [Required]
        [MaxLength(50)]
        public required string Language { get; set; }
        [Required]
        [MaxLength(50)]
        public required string Genre { get; set; }
        public int PageCount { get; set; }
        public short Year { get; set; }
        [MaxLength(75)]
        public string? Publisher { get; set; }
        [MaxLength]
        public string? Image { get; set; }

        [ForeignKey("Author")]
        public int? AuthorId { get; set; }
        public Author? Author { get; set; }
    }
}
