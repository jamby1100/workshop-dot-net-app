using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WorkshopApp.Models;
using WorkshopApp.Models.ViewModels;
using Microsoft.AspNetCore.Identity;

namespace WorkshopApp.Controllers;

public class WorkshopController : Controller
{
    private readonly ILogger<WorkshopController> _logger;
    private IWorkshopRepository workshopRepository;
    private IChallengeRepository challengeRepository;

    private UserManager<IdentityUser> _userManager;

    public int PageSize = 4;

    public WorkshopController(IWorkshopRepository wrepo, IChallengeRepository crepo, UserManager<IdentityUser> userManager) {
        workshopRepository = wrepo;
        challengeRepository = crepo;
        _userManager = userManager;
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
        Console.WriteLine("And the user is...");
        Console.WriteLine(this.User);
        Console.WriteLine("And the user id is...");
        Console.WriteLine(_userManager.GetUserId(User));



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
                Challenges = challengeRepository.Challenges.Where(p => p.Workshop.WorkshopId == 1),
                UserDisplay = new UserDisplayViewModel {
                    UserId = _userManager.GetUserId(User),
                    UserName = _userManager.GetUserName(User),
                    UserEmail = ""
                } 
            }
        );
    }

    [HttpPost]
    public IActionResult StartWorkshop(Workshop workshop) {
        // workshop.start()
        return RedirectToPage($"/workshops/{workshop.WorkshopId}");
    }

}