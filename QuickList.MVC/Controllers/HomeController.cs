using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using QuickList.Domain.Common;

namespace QuickList.MVC.Controllers;

public class HomeController : Controller
{
    /// <summary>
    /// Main page.
    /// </summary>
    /// <returns>Returns View with start page</returns>
    public IActionResult Index()
    {
        return View();
    }

    /// <summary>
    /// Error handler
    /// </summary>
    /// <returns>Returns ErrorView if something went wrong.</returns>
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}