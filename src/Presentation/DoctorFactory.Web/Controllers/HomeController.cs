using System.Diagnostics;
using DoctorFactory.DAL.Context;
using DoctorFactory.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace DoctorFactory.Web.Controllers;

public class HomeController : Controller
{
    private readonly ICourse _courses;
    private readonly ILogger<HomeController> _logger;

    public HomeController(ICourse courses, ILogger<HomeController> logger)
    {
        _courses = courses;
        _logger = logger;
    }

    public IActionResult Index()
    {
        _logger.LogInformation("Calling home index");

        var timer = Stopwatch.StartNew();

        try
        {
            var categories = _courses.GetCourseCategories();
            for (int i = 0; i < categories.Count(); i++)
            {
                
            }
            ViewBag.Categories = categories;

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
}
