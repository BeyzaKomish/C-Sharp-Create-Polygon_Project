using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyModel;
using Project.Models;

namespace Project.Data.SeedData
{
    public class UserSeedData
    {

		// Initialize method is static and asynchronous. It will seed data (users and roles) into the database.
		// It takes IServiceProvider, UserManager<User>, and RoleManager<IdentityRole> as parameters for interacting with the services.
		public static async Task Initialize(IServiceProvider serviceProvider,UserManager<User> userManager,RoleManager<IdentityRole> roleManager)
        {

            // arary of roles Librarian an student
            var roles = new[] { "Librarian", "Student" };
            foreach (var role in roles)// for every role
            {
                if (!await roleManager.RoleExistsAsync(role))// If the user doesnt exist
                {
                    // create the role of it doesnt exist usşng the IDentity role class 
                    await roleManager.CreateAsync(new IdentityRole(role));
                }

            }

			// a list of librarians with predefined data: Name, UserName, Email, and other details.

			var librarians =new[]
            {
                new Librarian { Name = "librarian1",
                UserName = "librarian1",
                Email = "librarian1@gmail.com",
                Adress = "###Student Department Library",
                EmployeeID = "LIB001",
                Department = "Main Library" ,
                UserType = "Librarian"},
                new Librarian { Name = "librarian2",
                UserName = "librarian2",
                Email = "librarian2@gmail.com",
                Adress = "###Science Department Library",
                EmployeeID = "LIB002",
                Department = "Science Library" ,
                UserType = "Librarian"},
                    new Librarian { Name = "librarian3",
                UserName = "librarian3",
                Email = "librarian3@gmail.com",
                Adress = "###Arts Department Library",
                EmployeeID = "LIB003",
                Department = "Art Library" ,
                UserType = "Librarian"},

            };
			// Loop through each librarian and check if the user already exists by their username.
			foreach (var librarian in librarians)
            {
				// If librarian doesn't exist, create the user.
				if ( await userManager.FindByNameAsync(librarian.UserName) == null)
                {
					// Create the librarian user with a password.
					var result = await userManager.CreateAsync(librarian, "password123");
                    if(result.Succeeded)
                    {
						// If user creation is successful, add them to the "Librarian" role.
						await userManager.AddToRoleAsync(librarian, "Librarian");
                    }
                }
            }

			// a list of students with predefined data: Name, UserName, Email, and other details.

			var students = new[]
            {
                new Student { Name = "student1", UserName = "student1", Email = "student1@gmail.com", Adress = "###", StudentID = "SIB001", GPA = "2.5" , UserType = "Student" },
                new Student { Name = "student2", UserName = "student2", Email = "student2@gmail.com", Adress = "$$$", StudentID = "SIB002", GPA = "3.0" ,UserType = "Student"},
                new Student { Name = "student3", UserName = "student3", Email = "student3@gmail.com", Adress = "#$#", StudentID = "SIB003", GPA = "3.5" ,UserType = "Student"},
                new Student { Name = "student4", UserName = "student4", Email = "student4@gmail.com", Adress = "&&&", StudentID = "SIB004", GPA = "3.8" ,UserType = "Student"},
                new Student { Name = "student5", UserName = "student5", Email = "student5@gmail.com", Adress = "^^^", StudentID = "SIB005", GPA = "4.0" ,UserType = "Student"}

            };

			// Loop through each student and check if the user already exists by their username.
			foreach (var student in students)
            {
				// If student doesn't exist, create the user.
				if (await userManager.FindByNameAsync(student.UserName) == null)
                {
                    var result = await userManager.CreateAsync(student, "password123");
					// If user creation is successful, add them to the "Student" role.
					if (result.Succeeded)
                     {
                        await userManager.AddToRoleAsync(student, "Student"); ;

                     }
                }



            }
                  



                

            
    }    }
}
