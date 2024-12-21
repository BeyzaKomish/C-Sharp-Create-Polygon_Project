namespace Project.Models
{
    public class Review
    {
        public int Id { get; set; }

        public string? Title { get; set; }   

        public string? Description { get; set; }

        public string? StudentId { get; set; }   

        public virtual Student? Student { get; set; }// Navigation for student 

        public int? BookId { get; set; }

        public virtual Book? Book { get; set; }  // navigation with books 

        // this way we are forming a relationship with revşew to book and student


    }
}
