using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WorkshopApp.Models;
using WorkshopApp.Models.ViewModels;

namespace WorkshopApp.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private IWorkshopRepository repository;
    public int PageSize = 4;

    public HomeController(IWorkshopRepository repo) {
        repository = repo;
    }

    public ViewResult Index(string? category, int workshopPage = 1)
        => View(new WorkshopsListViewModel {
            Workshops = repository.Workshops
                .Skip((workshopPage - 1) * PageSize)
                .Take(PageSize),
            PagingInfo = new PagingInfo {
                CurrentPage = workshopPage,
                ItemsPerPage = PageSize,
                TotalItems = repository.Workshops.Count()
            },
            CurrentCategory = category
        });

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
