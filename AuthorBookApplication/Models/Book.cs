using System.ComponentModel.DataAnnotations;

namespace AuthorBookApplication.Models
{
    public class Book
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        public double Price { get; set; }

        public DateTime DateOfRelease { get; set; }
    }
}
