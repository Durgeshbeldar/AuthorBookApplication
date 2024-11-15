using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AuthorBookApplication.Models
{
    public class Book
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Author")]
        public int? AuthorId { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public Author? Author { get; set; }
        public DateTime DateOfRelease { get; set; }
    }
}
