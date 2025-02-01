using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WorkshopApp.Models;
using WorkshopApp.Models.ViewModels;

namespace WorkshopApp.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private IWorkshopRepository workshopRepository;
    private IChallengeRepository challengeRepository;
    public int PageSize = 4;

    public HomeController(IWorkshopRepository wrepo, IChallengeRepository crepo) {
        workshopRepository = wrepo;
        challengeRepository = crepo;
    }

    public ViewResult Index(string? category, int workshopPage = 1) {
        return View(
            // new WorkshopsListViewModel {
            //     Workshops = workshopRepository.Workshops
            //         .Skip((workshopPage - 1) * PageSize)
            //         .Take(PageSize),
            //     PagingInfo = new PagingInfo {
            //         CurrentPage = workshopPage,
            //         ItemsPerPage = PageSize,
            //         TotalItems = workshopRepository.Workshops.Count()
            //     },
            //     Challenges = challengeRepository.Challenges.Where(p => p.Workshop.WorkshopId == 1)
            // }
        );

        // challengeRepository.Challenges.Where(p => p.Workshop.WorkshopId == 1)
    }



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
