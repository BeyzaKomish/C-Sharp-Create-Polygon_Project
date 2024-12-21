
namespace Project.Models
{
    public class Book
    {
        public int ID { get; set; }
        public string? Title { get; set; }

        public string? ISBN { get; set; }

        public DateTime PublishedDate { get; set; }

        public string? Author { get; set; }


		public bool IsBorrowed { get; set; }

        public string? StudentId { get; set; }
		// Navigation property for the `Student` who borrowed the book. The `virtual` keyword allows for lazy loading in Entity Framework (EF).
		public virtual Student Student { get; set; }

		// Navigation property representing a collections associated with the book.
		public ICollection<Genre> Genres { get; set; } = new List<Genre>();

        public ICollection<Author> Authors { get; set; } = new List<Author>();

        public ICollection<Category> Categories { get; set; } = new List<Category>();

        public ICollection<Review> Reviews { get; set; } = new List<Review>(); // Navigation property



    }
}
