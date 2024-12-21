using Project.Models;

namespace Project.Data.SeedData
{
    public class GenreSeedData
	{        // I have explained the similar codes int the AuthorSeed data 

		public static List<Genre> GetGenre()
        {
            return new List<Genre>
            {

			    new Genre { Id = 1, Name = "Science" },
		        new Genre { Id = 2, Name = "Programming" },
		        new Genre { Id = 3, Name = "Science Fiction" },
				new Genre { Id = 4, Name = "Romance" },
				new Genre { Id = 5, Name = "Action" },
				new Genre { Id = 6, Name = "History" }


			};
        }   
    }
}
