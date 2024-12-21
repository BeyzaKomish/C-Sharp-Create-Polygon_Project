namespace Project.Models
{
    public class Librarian : User// The librarian is a child entity of User
    {
        public string? EmployeeID { get; set; }  

        public string? Department {  get; set; } 
    }
}
