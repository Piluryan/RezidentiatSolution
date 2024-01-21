using Microsoft.AspNetCore.Mvc;

namespace DoctorFactory.Web.Controllers;

public class HomeController : Controller
{
    public IActionResult Index() => View();
}
