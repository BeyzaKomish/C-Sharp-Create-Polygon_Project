using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Project.Data;
using Project.Models;
using Project.ViewModels;

namespace Project.Controllers
{
    
    public class AccountController : Controller
    {
		// a class for managing user sign in operations and were creating an instance of it 
		private readonly SignInManager<User> signInManager;
		// this is an instance of the class that manages user related operation slike creating,deleting, and updating users 
		private readonly UserManager<User> userInManager;


		// Initializes the instances 
		public AccountController(SignInManager<User> signInManager, UserManager<User> userInManager,LibraryDbContext context)
		{
			this.signInManager = signInManager;
			this.userInManager = userInManager;
		}

		//request data from login 
		public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
		//send data to the server for processing or modification.
		public async Task<IActionResult> Login(LoginVM model)
        {
            if (ModelState.IsValid)// If the model is valid proceed
            {
				// sign the user and save the username , password ,remember me toggle   
                var result = await signInManager.PasswordSignInAsync(model.Username!, model.Password!, model.RememberMe, false);

				// If the result succedds
                if (result.Succeeded) // proceed with home
                {
                    return RedirectToAction("Index", "Home");
                }
				// If the model gives an error give an error
                ModelState.AddModelError("","Invalid Login Attempt");
				// return the View model if the model is valid.
                return View(model);
            }
			// or else return the blank login view
            return View(model);
        }

		//request data from register 

		public IActionResult Register()
        {
            return View();
        }


		//send data to the server for processing or modification.

		[HttpPost]
		public async Task<IActionResult> Register(RegisterVM model)
		{
			if (ModelState.IsValid)
			{

				// Check if the username already exists
				var existingUser = await userInManager.FindByNameAsync(model.Username);
				if (existingUser != null)
				{
					ModelState.AddModelError("", "Username already exists.");
					return View(model);
				}

				// Create the Student object (inherits from User)
				Student user = new Student()
				{
					Name = model.Username,
					UserName = model.Username, // Identity will automatically set NormalizedUserName
					Email = model.Email,
					Adress = model.Adress, // Add student-specific properties here
					StudentID = "SIB0010", // You can dynamically assign the StudentID or generate it
					GPA = "2.5", // Example GPA
					UserType = "Student" // Or any other properties you need to assign
				};

				// Create the user in the Identity system
				var result = await userInManager.CreateAsync(user, model.Password!);

				if (result.Succeeded)
				{

					// Add the user to the "Student" role
					await userInManager.AddToRoleAsync(user, "Student");

					// Sign in the user
					await signInManager.SignInAsync(user, isPersistent: false);
					return RedirectToAction("Index", "Home");
				}

				// Handle any errors
				foreach (var error in result.Errors)
				{
					ModelState.AddModelError("", error.Description);
				}
			}

			return View(model);
		}


		// log the user out 
		public async Task<IActionResult> Logout()
        {
			// with the signout function from the sign in manager class
            await signInManager.SignOutAsync();
            return RedirectToAction("Index","Home");
        }
    }
}
