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

    private IWorkshopProgressRepository workshopProgressRepository;

    private UserManager<IdentityUser> _userManager;

    public int PageSize = 4;

    public WorkshopController(
        IWorkshopRepository wrepo, 
        IChallengeRepository crepo, 
        UserManager<IdentityUser> userManager, 
        IWorkshopProgressRepository wprgRepo) {

            workshopRepository = wrepo;
            challengeRepository = crepo;
            _userManager = userManager;
            workshopProgressRepository = wprgRepo;
    }


    [HttpGet("/workshops/{workshopId}")]
    public ViewResult DisplayOneWorkshop(int workshopId) {
        string userId = _userManager.GetUserId(User); // && p.UserId == userId
        WorkshopProgress? userWp = workshopProgressRepository.WorkshopProgresses.Where(p => p.Workshop.WorkshopId == workshopId).FirstOrDefault();
        Workshop? workshopObj = workshopRepository.Workshops.Where(p => p.WorkshopId == workshopId).FirstOrDefault();

        Console.WriteLine("And the userWp is...");
        Console.WriteLine(userWp);

        return View(new OneWorkshopView {
            WorkshopObject = workshopRepository.Workshops.Where(p => p.WorkshopId == workshopId).FirstOrDefault(),
            Challenges = challengeRepository.Challenges.Where(p => p.Workshop.WorkshopId == workshopId),
            WorkshopProgressObject = userWp
        });
    }
    
    [HttpGet("/workshops/{workshopId}/challenges/{challengeId}")]
    [Authorize]
    public ViewResult DisplayOneChallenge(int workshopId, int challengeId) {
        string userId = "c91607c4-3903-482d-b1c7-25bcc13d4696"; // && p.UserId == userId
        WorkshopProgress? userWp = workshopProgressRepository.WorkshopProgresses.Where(p => p.Workshop.WorkshopId == 1).FirstOrDefault();
        Workshop? workshopObj = workshopRepository.Workshops.Where(p => p.WorkshopId == workshopId).FirstOrDefault();

        return View(new OneWorkshopView {
            WorkshopObject = workshopObj,
            Challenges = challengeRepository.Challenges.Where(p => p.ChallengeId == challengeId),
            WorkshopProgressObject = userWp
        });
    }

    [HttpGet("/workshops")]
    [Authorize]
    public ViewResult DisplayAllWorkshops(int workshopPage = 1) {
        string userId = _userManager.GetUserId(User);

        Console.WriteLine("And the user is...");
        Console.WriteLine(this.User);
        Console.WriteLine("And the user id is...");
        Console.WriteLine(userId);



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
                    UserId = userId,
                    UserName = _userManager.GetUserName(User),
                    UserEmail = "",
                }
            }
        );
    }

    [HttpPost("/start")]
    [Authorize]
    public IActionResult Start(int workshopId) {
        // workshop.start()
        Console.WriteLine("Confirming start");
        Console.WriteLine(workshopId);
        Workshop workshopObj = workshopRepository.Workshops.Where(p => p.WorkshopId == workshopId).FirstOrDefault();
        Console.WriteLine(workshopObj);
        Console.WriteLine(workshopObj.Name);

        Console.WriteLine("And the user is...");
        Console.WriteLine(this.User);
        Console.WriteLine("And the user id is...");
        Console.WriteLine(_userManager.GetUserId(User));

        WorkshopProgress workshopProgressObject = new WorkshopProgress {
            UserId = _userManager.GetUserId(User),
            Workshop = workshopObj
        };

        workshopProgressRepository.CreateWorkshopProgress(workshopProgressObject);
        // workshopObj.Start(_userManager.GetUserId(User));

        return RedirectToPage($"/workshops/{workshopId}");
    }

    [HttpPost("/submitChallenge")]
    [Authorize]
    public IActionResult SubmitChallenge(int workshopId, int challengeId) {
        return RedirectToPage($"/workshops/{workshopId}/challenges/{challengeId}");
    }

}