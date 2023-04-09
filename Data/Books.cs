using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
namespace BookApplication2.Data

{
    public class Book
    {
        [Required]

        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;
        public Decimal Price { get; set; }
        public int CategoryId { get; set; }
        public int? PublisherId { get; set; }
        public virtual Category? Category { get; set; }
        public virtual Publisher? Publisher { get; set; }
    }
    public class Category
    {
        public int Id { get; set; }

        [MaxLength(50)]
        public string Name { get; set; } = string.Empty;
        public virtual List<Book>? Books { get; set; } = new List<Book>();

    }

    public class Publisher
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public virtual List<Book>? Books { get; set; }
    }



}

