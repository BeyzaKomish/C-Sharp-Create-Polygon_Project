using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Project.Models;
using System.Diagnostics;

namespace Project.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
		// The ILogger interface is used for logging information, warnings, errors, etc.

		private readonly ILogger<HomeController> _logger;
		// The UserManager<T> class is provided by ASP.NET Core Identity to handle user-related operations.
		private readonly UserManager<User> _userManager;

		// The constructor initializes two parameters: an ILogger<HomeController> instance for logging and a UserManager<User> instance for user management.
		public HomeController(ILogger<HomeController> logger,UserManager<User> userManager)
        {
            _logger = logger;
            _userManager = userManager;

        }

        public async Task<IActionResult> Index()
        {
            // getting the user from the user manager and assigning it to a variable
            var user = await _userManager.GetUserAsync(User);
			if (user == null)
			{
				// if the user is null If there is no user then direct the user to the login action that is in the account controller
				return RedirectToAction("Login", "Account");
			}


            // If the user is in role librarian 
			if (await _userManager.IsInRoleAsync(user, "Librarian"))
            {
                //direct to the librarian dashboard that is in the Dashboard controller 
                return RedirectToAction("LibrarianDashboard", "Dashboard");
            }
            // else if the user is a student
            else if (await _userManager.IsInRoleAsync(user, "Student"))
            {
				//direct to the student dashboard that is in the Dashboard controller 
				return RedirectToAction("StudentDashboard", "Dashboard");
            }
            //If none of the options work then direct to the accessdenied action in the home controller
            return RedirectToAction("AccessDenied", "Home");
        }

		public async Task<IActionResult> UserInfo()
		{
			var user = await _userManager.GetUserAsync(User);

			if (user == null)
			{
                return RedirectToAction("Login", "Account");
			}
            // Displaying the Info props according to the role
            // If the user is in role librarian 
            if (await _userManager.IsInRoleAsync(user, "Librarian"))
			{
				var librarian = user as Librarian;
				ViewData["Librarian"] = librarian;
			}
			// else if the user is a student
			else if (await _userManager.IsInRoleAsync(user, "Student"))
			{
				var student = user as Student;
				ViewData["Student"] = student;
			}
			return View(user);

		}




		// default actions that comes with the applications
		
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
