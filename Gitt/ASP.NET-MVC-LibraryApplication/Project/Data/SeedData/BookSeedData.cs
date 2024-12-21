using Project.Models;

namespace Project.Data.SeedData
{
    public class BookSeedData
    {
        // I have explained the similar codes int the AuthorSeed data 
        public static List<Book> GetBooks()
        {
            return new List<Book>
            {
                new Book
                {
                    ID = 1,
                    Title = "C# programming",
                    ISBN =  "1234567890",
                    PublishedDate = new DateTime(2020,1,1),
                    Author = "John Doe",
                    IsBorrowed = false


                },

                new Book
                {
                    ID = 2,
                    Title = "Introduction to Algorithms",
                    ISBN = "9876543210",
                    PublishedDate = new DateTime(2019, 6, 15),
                    Author = "Thomas H. Cormen",
					 IsBorrowed = false
				},

                new Book
                {
                    ID = 3,
                    Title = "Action and Romance Code",
                    ISBN = "1122334455",
                    PublishedDate = new DateTime(2008, 8, 1),
                    Author = "Robert C. Martin",
					 IsBorrowed = false
				},

                new Book
                {
                    ID = 4,
                    Title = "Design Patterns: Elements of Reusable Object-Oriented Software",
                    ISBN = "6677889900",
                    PublishedDate = new DateTime(1994, 10, 21),
                    Author = "Erich Gamma",
					 IsBorrowed = false
				},

                new Book
                {
                    ID = 5,
                    Title = "Effective Java",
                    ISBN = "4433221100",
                    PublishedDate = new DateTime(2018, 1, 6),
                    Author = "Joshua Bloch",
					 IsBorrowed = false
				},

                new Book
                {
                    ID = 6,
                    Title = "You Don't Real JS",
                    ISBN = "3344556677",
                    PublishedDate = new DateTime(2015, 7, 15),
                    Author = "Kyle Simpson",
                     IsBorrowed = false
                },

                new Book
                {
                    ID = 7,
                    Title = "The Pragmatic Action",
                    ISBN = "9988776655",
                    PublishedDate = new DateTime(1999, 10, 20),
                    Author = "Andrew Hunt",
					 IsBorrowed = false
				},

                new Book
                {
                    ID = 8,
                    Title = "Fake Design Patterns",
                    ISBN = "5566778899",
                    PublishedDate = new DateTime(2004, 10, 25),
                    Author = "Eric Freeman",
					 IsBorrowed = false
				},

                new Book
                {
                    ID = 9,
                    Title = "Python Love",
                    ISBN = "4455667788",
                    PublishedDate = new DateTime(2015, 11, 15),
                    Author = "Eric Matthes",
					 IsBorrowed = false
				},

                new Book
                {
                    ID = 10,
                    Title = "The Mythical History of Month",
                    ISBN = "7788990011",
                    PublishedDate = new DateTime(1975, 8, 1),
                    Author = "Frederick P. Brooks Jr.",
					 IsBorrowed = false
				}



                };
        }   
    }
}
