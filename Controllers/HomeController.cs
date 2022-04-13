using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Mvc.Longrunning.Lib;
using Mvc.Longrunning.Models;

namespace Mvc.Longrunning.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IDisposableTaskPerformer _taskPerformer;


    public HomeController(ILogger<HomeController> logger, IDisposableTaskPerformer taskPerformer)
    {
        _logger = logger;
        _taskPerformer = taskPerformer;
    }

    public IActionResult Index()
    {
        var task = Task.Run(() =>
        {
            for (var i = 0; i < 50; i++)
            {
                System.Console.WriteLine("Long running task using simple writeline");
                System.Threading.Thread.Sleep(1000);
            }
        });
        return View();
    }

    public IActionResult Privacy()
    {
        Task.Run(() =>
        {
            for (var i = 0; i < 50; i++)
            {
                this._taskPerformer.PerformSomeTask();
                System.Threading.Thread.Sleep(1000);
            }
        });
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
