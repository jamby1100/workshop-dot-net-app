using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WorkshopApp.Models;
using WorkshopApp.Models.ViewModels;

namespace WorkshopApp.Controllers;

public class WorkshopController : Controller
{
    private readonly ILogger<WorkshopController> _logger;
    private IWorkshopRepository workshopRepository;
    private IChallengeRepository challengeRepository;
    public int PageSize = 4;

    public WorkshopController(IWorkshopRepository wrepo, IChallengeRepository crepo) {
        workshopRepository = wrepo;
        challengeRepository = crepo;
    }


    [HttpGet("/workshops/{workshopId}")]
    public ViewResult DisplayOneWorkshop(string workshopId) {
        return View(new OneWorkshopView {
            WorkshopObject = workshopRepository.Workshops.Where(p => p.WorkshopId.ToString() == workshopId).FirstOrDefault(),
            Challenges = challengeRepository.Challenges.Where(p => p.Workshop.WorkshopId.ToString() == workshopId)
        });
    }
    
    [HttpGet("/workshops/{workshopId}/challenges/{challengeId}")]
    public ViewResult DisplayOneChallenge(int workshopId, int challengeId) {
        return View(new OneWorkshopView {
            WorkshopObject = workshopRepository.Workshops.Where(p => p.WorkshopId == workshopId).FirstOrDefault(),
            Challenges = challengeRepository.Challenges.Where(p => p.ChallengeId == challengeId)
        });
    }

    [HttpGet("/workshops")]
    [Authorize]
    public ViewResult DisplayAllWorkshops(int workshopPage = 1) {
        return View(
            new WorkshopsListViewModel {
                Workshops = workshopRepository.Workshops
                    .Skip((workshopPage - 1) * PageSize)
                    .Take(PageSize),
                PagingInfo = new PagingInfo {
                    CurrentPage = workshopPage,
                    ItemsPerPage = PageSize,
                    TotalItems = workshopRepository.Workshops.Count()
                },
                Challenges = challengeRepository.Challenges.Where(p => p.Workshop.WorkshopId == 1)
            }
        );
    }

    [HttpPost]
    public IActionResult StartWorkshop(Workshop workshop) {
        // workshop.start()
        return RedirectToPage($"/workshops/{workshop.WorkshopId}");
    }

}