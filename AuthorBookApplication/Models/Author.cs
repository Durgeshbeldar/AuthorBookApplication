using System.ComponentModel.DataAnnotations;

namespace AuthorBookApplication.Models
{
    public class Author
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        // Navigation Property
        public  List<Book> Books { get; set; }
        public  AuthorDetails AuthorDetails { get; set; }

    }
}
