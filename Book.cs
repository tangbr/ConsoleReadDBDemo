using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Console26App1
{
    public class Book
    {

        private Book() { }

        public Book(string title, string publisher)
        {
            Title = title;
            Publisher = publisher;
        }

        public int BookId { get; set; }
        [Required]
        [StringLength(50)]
        public string Title { get; set; }
        [StringLength(30)]
        public string Publisher { get; set; }
    }
}
