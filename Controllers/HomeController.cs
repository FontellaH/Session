using System.Diagnostics;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Session.Models;

namespace Session.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }




    [HttpPost("")]
    public IActionResult CreateName(User user)
    {
        HttpContext.Session.SetString("Name", user.Name);  //storing the users name in session
        return RedirectToAction("Dashboard");
    }




    public IActionResult Dashboard()
    {
        var name = HttpContext.Session.GetString("Name") ?? "";  //Getting the users name from the session and checking if its a empty string 

        var currentNumber = HttpContext.Session.GetInt32("CurrentNumber") ?? 22;  //int32....Getting the number value stored in the session under the CurrentNumber 22

        var model = new User { Name = name, CurrentNumber = currentNumber };  /// made a new model with the users name and current number

        return View( model);
    }


    [HttpPost]
    public IActionResult UpdateNumber(string operation)
    {
        var currentNumber = HttpContext.Session.GetInt32("CurrentNumber") ?? 22; //getting the current number fro the session and turning it to 22

        if (operation == "plus1")
        {
            currentNumber += 1;
        }
        else if (operation == "minus1")
        {
            currentNumber -= 1;
        }
        else if (operation == "multiply2")
        {
            currentNumber *= 2;
        }
        else if (operation == "random")
        {
            var random = new Random();  //making a random number between 1-10
            var randomNumber = random.Next(1, 11);
            currentNumber += randomNumber;
        }
        HttpContext.Session.SetInt32("CurrentNumber", currentNumber);  // this is updating the CurrentNumber
        return RedirectToAction("Dashboard");
    }



    [HttpPost]
    public IActionResult Logout()  //logout Route
    {
        HttpContext.Session.Clear();  // clears the session to log out the user
        return RedirectToAction("Index");
    }

}


