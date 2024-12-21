using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Project.Data.SeedData;
using Project.Models;

namespace Project.Data
{
    public class LibraryDbContext : IdentityDbContext<User>

    {

        public LibraryDbContext(DbContextOptions<LibraryDbContext> options ): base(options) 
        {
            
        }

       

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

	


            builder.Entity<User>()
			.ToTable("AspNetUsers")
            .HasDiscriminator<string>("UserType")
            .HasValue<User>("User")
            .HasValue<Librarian>("Librarian")
            .HasValue<Student>("Student");


            builder.Entity<Book>().HasData(BookSeedData.GetBooks());
            builder.Entity<Genre>().HasData(GenreSeedData.GetGenre());
			builder.Entity<Author>().HasData(AuthorSeedData.GetAuthor());
			builder.Entity<Category>().HasData(CategorySeedData.GetCategory());	


		

			builder.Entity<Book>()
				.HasMany(b => b.Authors)
				.WithMany(b => b.Books)
				.UsingEntity(j => j.HasData(
								// C# Programming - Programming
								new { BooksID = 1, AuthorsId = 1 },
								new { BooksID = 1, AuthorsId = 2 },
								// Introduction to Algorithms - Programming
								new { BooksID = 2, AuthorsId = 8},
								// Action and Romance Code - Programming, Action, Romance
								new { BooksID = 3, AuthorsId = 2 },
								new { BooksID = 3, AuthorsId = 4 },
								new { BooksID = 3, AuthorsId = 5 },
								// Design Patterns - Programming
								new { BooksID = 4, AuthorsId = 3 },
								// Effective Java - Programming
								new { BooksID = 5, AuthorsId = 2 },
								// You Don't Real JS - Programming
								new { BooksID = 6, AuthorsId = 3 },
								// The Pragmatic Action - Programming, Action
								new { BooksID = 7, AuthorsId = 2 },
								new { BooksID = 7, AuthorsId = 5 },
								// Fake Design Patterns - Programming
								new { BooksID = 8, AuthorsId = 7 },
								// Python Love - Programming, Romance
								new { BooksID = 9, AuthorsId = 7 },
								new { BooksID = 9, AuthorsId = 4 },
								// The Mythical History of Month - History
								new { BooksID = 10, AuthorsId = 1 },
								new { BooksID = 10, AuthorsId = 6 }
	));

			builder.Entity<Book>()
                .HasMany(b=>b.Genres)
                .WithMany(b=>b.Books)
                .UsingEntity(j=> j.HasData(
								// C# Programming - Programming
								new { BooksID = 1, GenresId = 1 },
								new { BooksID = 1, GenresId = 2 },
								// Introduction to Algorithms - Programming
								new { BooksID = 2, GenresId = 2 },
								// Action and Romance Code - Programming, Action, Romance
								new { BooksID = 3, GenresId = 2 },
								new { BooksID = 3, GenresId = 4 },
								new { BooksID = 3, GenresId = 5 },
								// Design Patterns - Programming
								new { BooksID = 4, GenresId = 3 },
								// Effective Java - Programming
								new { BooksID = 5, GenresId = 2 },
								// You Don't Real JS - Programming
								new { BooksID = 6, GenresId = 3 },
								// The Pragmatic Action - Programming, Action
								new { BooksID = 7, GenresId = 2 },
								new { BooksID = 7, GenresId = 5 },
								// Fake Design Patterns - Programming
								new { BooksID = 8, GenresId = 2 },
								// Python Love - Programming, Romance
								new { BooksID = 9, GenresId = 2 },
								new { BooksID = 9, GenresId = 4 },
								// The Mythical History of Month - History
								new { BooksID = 10, GenresId = 1 },
								new { BooksID = 10, GenresId = 6 }
	));


			builder.Entity<Book>()
				.HasMany(b => b.Categories)
				.WithMany(b => b.Books)
				.UsingEntity(j => j.HasData(
					new {BooksID =1, CategoriesId = 1},
					new {BooksID =1, CategoriesId = 2},
					new { BooksID = 2, CategoriesId = 1 },
					new { BooksID = 2, CategoriesId = 2 },
					new { BooksID = 3, CategoriesId = 2 },
					new { BooksID = 3, CategoriesId = 3 },
					new { BooksID = 4, CategoriesId = 3 },
					new { BooksID = 5, CategoriesId = 3 },
					new { BooksID = 6, CategoriesId = 1 },
					new { BooksID = 7, CategoriesId = 1 },
					new { BooksID = 7, CategoriesId = 2 },
					new { BooksID = 8, CategoriesId = 1},
					new { BooksID = 9, CategoriesId = 3 },
					new { BooksID = 10, CategoriesId = 2}
					));


			builder.Entity<Review>()
				.HasOne(r => r.Student)
				.WithMany(r => r.Reviews)
				.HasForeignKey(r => r.StudentId)
                .OnDelete(DeleteBehavior.Cascade);



            builder.Entity<Review>()
				.HasOne(r=>r.Book)
				.WithMany(b=>b.Reviews)
				.HasForeignKey(r=>r.BookId)
			    .OnDelete(DeleteBehavior.Cascade);


        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Genre> Genres { get; set; }

		public DbSet<Author> Authors { get; set; }

		public DbSet<Category> Categories { get; set; }	
		public DbSet<User> Users {  get; set; }

		public DbSet<Student> Students { get; set; }

		public DbSet<Librarian> Librarian { get; set; }

		public DbSet<Review> Reviews { get; set; }	

    }
}
