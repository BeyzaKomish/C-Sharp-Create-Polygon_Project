namespace Project.Models
{
	public class Author
	{

		public int Id { get; set; }
		public string? Name { get; set; }

		// Enable relationship to store the collection of books written by the author
		public ICollection<Book> Books { get; set; } = new List<Book>();
	}
}
