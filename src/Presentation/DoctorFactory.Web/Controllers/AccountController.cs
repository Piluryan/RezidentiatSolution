using System.Diagnostics;
using DoctorFactory.Domain.Entities.Identity;
using DoctorFactory.Domain.ViewModels.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace DoctorFactory.Web.Controllers;

public class AccountController : Controller
{
    private readonly ILogger<AccountController> _logger;
    private readonly SignInManager<User> _signInManager;

    public AccountController(ILogger<AccountController> logger, SignInManager<User> signInManager)
    {
        _logger = logger;
        _signInManager = signInManager;
    }

    public IActionResult Login()
    {
        ViewBag.Title = "Log In";

        var timer = Stopwatch.StartNew();

        _logger.LogInformation("Calling LogIn");

        try
        {
            return View();
        }
        catch (InvalidOperationException error)
        {
            _logger.LogWarning("Error on request handling {error}", error);
            return BadRequest($"Error on request handling {error.Message}");
        }
        finally
        {
            _logger.LogInformation("Request handled in  {timeout}", timer.Elapsed);
        }
    }

    public IActionResult SignUp()
    {
        ViewBag.Title = "Sign Up";

        var timer = Stopwatch.StartNew();

        _logger.LogInformation("Calling SignUp");

        try
        {
            return View(new SignUpViewModel());
        }
        catch (InvalidOperationException error)
        {
            _logger.LogWarning("Error on request handling {error}", error);
            return BadRequest($"Error on request handling {error.Message}");
        }
        finally
        {
            _logger.LogInformation("Request handled in  {timeout}", timer.Elapsed);
        }
    }
}
