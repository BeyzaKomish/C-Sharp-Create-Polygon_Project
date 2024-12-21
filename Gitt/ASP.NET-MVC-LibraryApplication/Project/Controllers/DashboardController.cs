using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Project.Models;
using Project.Data;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Project.Controllers
{
    public class DashboardController : Controller
    {

        private readonly LibraryDbContext _context;
        // create an instance of from the Db context

        public DashboardController(LibraryDbContext context)
        {
            _context = context;
        }

        [HttpGet]
		// Action method in a controller to search for books based on a search term.

		public IActionResult SearchBooks(string searchTerm)
        {
            // retrieve the books from the database
            //Include related entities
            var books = _context.Books
                .Include(b=>b.Genres)
                .Include(b=> b.Authors)
                .Include(b=>b.Categories)
                .Where(b=> string.IsNullOrEmpty(searchTerm) || b.Title.Contains(searchTerm))    // Filters books: if `searchTerm` is null or empty, all books are included; otherwise, it checks if the book title contains the search term.

				.ToList();
            // Store the searchTerm in the ViewBag to make it accessible in the view,
            // to display and filter
            ViewBag.SearchTerm = searchTerm;    

            // View the listbooks along with the retrieved the data 
            return View("ListBooks",books);
        }


		// create action responds to HTTP GET requests.

		[HttpGet]
        public IActionResult Create()
        {
            // Load all the tables from the view to the ViewBag to be used in view
            ViewBag.Genres = _context.Genres.ToList();
            ViewBag.Authors = _context.Authors.ToList();
            ViewBag.Categories = _context.Categories.ToList();

            return View();// return the view
        }

        [HttpPost]
		// Protects the form submission against Cross-Site Request Forgery (CSRF) attacks.

		[ValidateAntiForgeryToken]
        // get action for create that takes the parameter book,genres,Authors and categories 
        public async Task<IActionResult> Create(Book book, int[] GenreIds, int[] AuthorIds, int[] CategoryIds)
        {

			// In the create function 
			// I neeeded to remove the relationship for the student 
            // Because the relationship for the students were giving an error 
            //probably because the create function doesnt need a student relationship
            //thats why I removed it for this action

			if (!ModelState.IsValid)

            { 

                ModelState.Remove("Student");
                ModelState.Remove("StudentId");

            }

            if (ModelState.IsValid)// ıf the model state is valid after validation 
            {
                // If the genreId Received from the parameters arent null
                if (GenreIds != null)
                {
                    // foreach genreID in theh genre array
                    foreach (var genreId in GenreIds)
                    {
                        // check the genre if it exists in the genre table save the genres 
                        var genre = await _context.Genres.FindAsync(genreId);
                        if (genre != null)// and if successfully saved 
                        {
                            book.Genres.Add(genre);//add the genre to the related book variable
                        }
                    }


                }

				// If the AuthorIds Received from the parameters arent null

				if (AuthorIds != null)
                {
					// foreach authorId in theh author array

					foreach (var authorId in AuthorIds)
                    {
						// check the author if it exists in the author table save the authors 

						var author = await _context.Authors.FindAsync(authorId);
                        if (author != null)// and if successfully saved
						{
                            book.Authors.Add(author);//add the author to the related book variable
						}
                    }



                }
				// If the CategoryIds Received from the parameters arent null

				if (CategoryIds != null)
                {
					// foreach categoryId in theh category array

					foreach (var categoryId in CategoryIds)
                    {
						// check the category if it exists in the category table save the categories 

						var category = await _context.Categories.FindAsync(categoryId);
                        if (category != null)// and if successfully saved
                        {
                            book.Categories.Add(category);//add the category to the related book variable
						}
					
                    }



                }

				// Adds the new book to the database context.
				_context.Books.Add(book);
				// Saves the changes to the database asynchronously.

				await _context.SaveChangesAsync();
				// Redirects the user to the "ListBooks" action to view the list of books after creating a new one.

				return RedirectToAction("ListBooks");
            }

			// If the model state is invalid, reloads the genres, authors, and categories for the view.

			ViewBag.Genres = _context.Genres.ToList();
            ViewBag.Authors = _context.Authors.ToList();
            ViewBag.Categories = _context.Categories.ToList();

			// Returns the view with the filtered list of books as the model.

			return View(book);
        }

		// Handles GET request to display the "Create Genre" form.

		[HttpGet]
        public IActionResult CreateGenre()
        {
			// Returns the "Create Genre" view.

			return View();

        }
		// Handles POST request to create a new genre.

		[HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateGenre(Genre genre)
        {
            if(ModelState.IsValid)
            {
				// Adds the new genre to the database context.

				_context.Genres.Add(genre);
				// Saves the changes to the database 
				await _context.SaveChangesAsync();
				// Redirects the user to the home page after successful creation.

				return RedirectToAction("Index", "Home");
            }
            return View(genre);// Returns the view with the current genre data if validation fails.

		}
		// Handles GET request to display the "Create Author" form.

		[HttpGet]
        public IActionResult CreateAuthor()
        {
			// Returns the "Create Author" view.

			return View();

        }
		// Handles POST request to create a new author.

		[HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateAuthor(Author author)
        {
            if (ModelState.IsValid)
            {
				// Adds the new author to the database context.

				_context.Authors.Add(author);
				// Saves the changes to the database 
				await _context.SaveChangesAsync();
				// Redirects the user to the home page after successful creation.
				return RedirectToAction("Index", "Home");
            }
            return View(author); // Returns the view with the current author data if validation fails.

		}

		[HttpGet]
		// Handles GET request to display the "Create Category" form.

		public IActionResult CreateCategory()
        {
            return View();    // Returns the "Create Category" view.


		}
		// Handles POST request to create a new category.

		[HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateCategory(Category category)
        {
            if(ModelState.IsValid)
            {
				// Adds the new category to the database context.
				_context.Categories.Add(category);
				// Saves the changes to the database.
				await _context.SaveChangesAsync();
				// Redirects the user to the home page after successful creation.
				return RedirectToAction("Index", "Home");
            }
            return View(category);  // Returns the view with the current category data if validation fails.
		}

		[HttpGet]
		// Handles GET request to display the "Edit Book" form.

		public async Task<IActionResult> Edit(int id)
        {
			// Retrieves the book with the specified ID, including its related genres,authors,categories.

			var book = await _context.Books
                .Include(b=> b.Genres)
                .Include(b => b.Authors)
                .Include(b=> b.Categories)
                .FirstOrDefaultAsync(b=>b.ID == id);// Finds the first matching book.

			if (book == null)// Check if the book is null
            {
                return NotFound();

            }

            // stores the list of genre,authors and categories for the view
            ViewBag.Genres = _context.Genres.ToList();
            ViewBag.Authors = _context.Authors.ToList();
            ViewBag.Categories = _context.Categories.ToList();

			// Returns the "Edit Book" view with the book data.


			return View(book);
        }



		// Handles POST request to update an existing book.

		[HttpPost]
        public async Task<IActionResult> Edit(Book book, int[] GenreIds, int[] AuthorIds , int[] CategoryIds )
        {
			// Removes certain properties from validation if necessary.

			if (!ModelState.IsValid)
            {

                ModelState.Remove("Student");
                ModelState.Remove("StudentId");

            }


            if (ModelState.IsValid)
            {

				// Retrieves the existing book from the database along with the ıncluding related data .
				var existingBook = await _context.Books
                    .Include(b => b.Genres)
                    .Include(b => b.Authors)
                    .Include(b=> b.Categories)
                    .FirstOrDefaultAsync(b => b.ID == book.ID);// Finds the first matching book.


				// Checks if the book was not found.
				if (existingBook == null)
                {
                    return NotFound();
                }
				// Updates the existing book's properties.
				existingBook.Title = book.Title;
                existingBook.ISBN = book.ISBN;  
                existingBook.PublishedDate = book.PublishedDate;

				// Clears existing relationships before adding new ones.
				existingBook.Genres.Clear();
                existingBook.Authors.Clear();
                existingBook.Categories.Clear();


                // Explained same code in details inthe create action
				// Adds the selected genres to the book.

				foreach (var genreId in GenreIds)
                {
                    var genre = await _context.Genres.FindAsync(genreId);
                    if (genre != null)
                    {
                        existingBook.Genres.Add(genre);
                    }
                }
				// Adds the selected authors to the book.
				foreach (var authorId in AuthorIds)
                {
                    var author = await _context.Authors.FindAsync(authorId);
                    if (author != null)
                    {
                        existingBook.Authors.Add(author);
                    }
                }
				// Adds the selected categories to the book.
				foreach (var categoryId in CategoryIds)
                {
                    var category = await _context.Categories.FindAsync(categoryId);
                    if (category != null)
                    {
                        existingBook.Categories.Add(category);
                    }
                }
				// Saves the changes to the database.
				await _context.SaveChangesAsync();
				// Redirects the user to the book list after successful update.
				return RedirectToAction("ListBooks");
            }
			// Prepares the data in the view if validation fails.
			ViewBag.Genres = _context.Genres.ToList();
            ViewBag.Authors = _context.Authors.ToList();
            ViewBag.Categories = _context.Categories.ToList();

			// Returns the "Edit Book" view with the current book data.
			return View(book);
        }

		// Handles GET request to display the "Delete Book" confirmation view.
		[HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
			// Retrieves the book with the specified ID, including related data.
			var book = await _context.Books
				 .Include(b => b.Genres)
				 .Include(b => b.Authors)
				 .FirstOrDefaultAsync(b => b.ID == id);// Finds the first matching book.


			if (book == null)    // Checks if the book was not found.

			{
				Console.WriteLine("Nope1");

                return NotFound();
            }
			// Prepares the datas in the view.

			ViewBag.Genres = _context.Genres.ToList();
			ViewBag.Authors = _context.Authors.ToList();
			// Returns the "Delete Book" view with the book data.
			return View(book);
        }

		// Handles POST request to delete a book.
		[HttpPost]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
			// Retrieves the book with the specified ID from the database.
			var book = await _context.Books.FindAsync(id);
                
            if(book == null) // Checks if the book was not found.
			{
				Console.WriteLine("Nope2");
                return NotFound();
               
            }
			// Removes the book from the database context.
			_context.Books.Remove(book);
			// Saves the changes to the database.
			await _context.SaveChangesAsync();
			// Redirects the user to the book list after successful deletion.
			return RedirectToAction("ListBooks");
		}

		// List the  books action 
		public IActionResult ListBooks()
        {
			// save the book information along with the corresponding student,genre,author,categories that belongs to the book  

			var books = _context.Books
                .Include(b => b.Student) 
                .Include(b=> b.Genres)
                .Include(b=> b.Authors)
                .Include(b=>b.Categories)
                .ToList();

            return View(books);// return the belonging view with the saved data
		}
        // List the borrowed books action 
        public IActionResult ListBorrowedBooks()
        {
            // saving the username of the user 
			var studentName = User.Identity.Name;
            //check if the saved user exists in the student table 
			var student = _context.Students.FirstOrDefault(b => b.UserName == studentName);
            


            if (student == null)// check if the student is null
			{
				return Unauthorized();
			}

            // save the book information along with the corresponding student,genre,author that belongs to the book  
			var books = _context.Books
                .Include(b=>b.Student)
				.Include(b => b.Genres)
                .Include(b => b.Authors)
		        .Where(b => b.IsBorrowed && b.Student.Id ==student.Id ) // Filter by student ID and IsBorrowed
				.ToList();// list the books

			return View(books);// return the belonging view with the saved data
        }

        // List the catagories action
        public IActionResult ListCategories()
        {
			// save the categories that include the book informations into a variable 
			var categories = _context.Categories
                .Include(c => c.Books)
                .ToList();

            return View(categories);//the view of the list catagories action along with the saved info
		}

        // List reviews action
        public async Task<IActionResult> ListReviews()
        {
            // save the reviews that include the book and student informations into a variable 
            var reviews = await _context.Reviews
                .Include(r=>r.Book)
                .Include(r => r.Student)
                .ToListAsync();
     
            return View(reviews);  //the view of the list reviews action along with the saved info
        }

        // requesting data 
        [HttpGet]
        public async Task<IActionResult> AddReview(int bookId)
        {
            // find the book provided in the parameter
            var book = await _context.Books.FindAsync(bookId);

            if( book == null)// check if null
            {
                return NotFound();
            }

            var review = new Review // save the found book in to an object of type review
            {
                Book = book,
                BookId = bookId
            };

            return View(review);// return the View for the addreview action along with the saved book 
        }

        [HttpPost]
        // The add review action that takes the book Id the title and the descriotion of the review
        public async Task<IActionResult> AddReview(int bookId , string Title ,string Description)
        {
			// save the student name that we get from Identity

			var studentName = User.Identity.Name;

			// check if the saved username exists in the students table

			var student = await _context.Students.FirstOrDefaultAsync(s => s.UserName == studentName);


            if (student == null)// check if the student is null
            {
                Console.WriteLine($"Student with ID {student.StudentID} not found.");
                return NotFound("Student not found.");
            }

            // checkk is the books table contain the book that the parameter provides
            var book = await _context.Books.FirstOrDefaultAsync(b => b.ID == bookId);
            if (book == null)// check if the book is null
            {
                return NotFound("Book not found.");
            }
            var review = new Review// create a review object that is type review
            {
                Title = Title,
                Description = Description,
                StudentId = student.Id,
                BookId = bookId,
            };// save the title , description and the saves student that borrowed the specific book

            try
            {
                // add the review object to the review context table
                _context.Reviews.Add(review);
                // save the changes
                await _context.SaveChangesAsync();

                // return to the list reviews page to see the added review
                return RedirectToAction("ListReviews");

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error:::::::::{ex.Message}");
                return BadRequest("An error occurred while saving the review.");

            }


        }
        // An action for the Librarian dashboard
        public IActionResult LibrarianDashboard()
        {
            if(!User.IsInRole("Librarian"))// If the there isnt a user role librarian 
            {
                return RedirectToAction("AccessDenied", "Home");// return the access denied action
            }
            // return the coreesponding view 
            return View();

        }
		// An action for the Student dashboard

		public IActionResult StudentDashboard()
        {
            if (!User.IsInRole("Student"))// If the there isnt a user role student 
			{
                return RedirectToAction("AccessDenied", "Home");// return the access denied action
			}
			// return the coreesponding view 
			return View();
        }

        [HttpPost]
        // Borrowbook action 
        public IActionResult BorrowBook(int bookId)
        {
			// save a book that saves the student and book details
			// save the book if the book Id in the parameter is the same with an existing books and ,if the book is borrowed is false

			var book = _context.Books
                .Include(b=>b.Student)
                .FirstOrDefault(b => b.ID == bookId && !b.IsBorrowed);
            if(book == null)  { return NotFound(); }// If the book is null return notfound

            // save the student name that we get from Identity
			var studentName = User.Identity.Name;
            // check if the saved username exists in the students table
            var student = _context.Students.FirstOrDefault(b => b.UserName == studentName);

            //Check if the student exits
            if(student == null) {
				Console.WriteLine("No student found for username: " + studentName);
				return Unauthorized(); }  
            // save the Isborrowed to true
            book.IsBorrowed = true;
            book.StudentId= student.Id;
            //and save which student borrowed the book 

            // save the changes
            _context.SaveChanges();
			return RedirectToAction("ListBooks");// redirect the user to Listbooks action
		}

		[HttpPost]
        // The return book action 
        public IActionResult ReturnBook(int bookId)
        {
            // save the book if the book Id in the parameter is the same with an existing books and ,if the book is borrowed is true
			var book = _context.Books.FirstOrDefault(b => b.ID == bookId && b.IsBorrowed);
			if (book == null) { return NotFound(); }// If the book is null return notfound

			book.IsBorrowed = false;// set the book is borrowed to false this way the book will be no longer in the borrowed books list 
			_context.SaveChanges();// save the changes made to the context
			return RedirectToAction("ListBooks");// redirect the user to Listbooks action
		}



    }
}
