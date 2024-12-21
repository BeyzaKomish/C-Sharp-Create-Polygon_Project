namespace Project.Models
{
    public class Student : User// The librarian is a child entity of User
	{
        public string StudentID { get; set; }
        public string GPA { get; set; }

		// Navigation property representing a collections associated with the stydent.
		public virtual ICollection<Book> BorrowedBooks { get; set; }

        public ICollection<Review> Reviews { get; set; } = new List<Review>(); // Navigation property


    }
}
