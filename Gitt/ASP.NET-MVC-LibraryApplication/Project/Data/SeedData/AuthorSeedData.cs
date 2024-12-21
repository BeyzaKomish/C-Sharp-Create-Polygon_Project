using Project.Models;

namespace Project.Data.SeedData
{
	public class AuthorSeedData
	{

		// Static method that returns a List of Author objects.
		// The List<Author> contains predefined author data that can be used for seeding or populating a database.
		public static List<Author> GetAuthor()
		{
			// Return a new list of Author objects with predefined author data.

			return new List<Author>
			{
				// Each Author object has an Id and Name property.
				new Author { Id = 1, Name = "J.R.R. Tolkien" },
				new Author { Id = 2, Name = "Agatha Christie" },
				new Author { Id = 3, Name = "Haruki Murakami" },
				new Author { Id = 4, Name = "Isaac Asimov" },
				new Author { Id = 5, Name = "Mark Twain" },
				new Author { Id = 6, Name = "Ernest Hemingway" },
				new Author { Id = 7, Name = "Virginia Woolf" },
				new Author { Id = 8, Name = "Emily Brontë" }



			};
		}
	}
}
