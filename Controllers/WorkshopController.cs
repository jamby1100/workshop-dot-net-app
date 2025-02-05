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
    private IChallengeProgressRepository challengeProgressRepository;
    private IHintRepository hintRepository;
    private IHintProgressRepository hintProgressRepository;
    private IPointsLedgerEntryRepository pointsLedgerEntryRepository;

    private UserManager<IdentityUser> _userManager;

    public int PageSize = 4;

    public WorkshopController(
        IWorkshopRepository wrepo, 
        IChallengeRepository crepo, 
        UserManager<IdentityUser> userManager, 
        IWorkshopProgressRepository wprgRepo,
        IChallengeProgressRepository chlgRepo,
        IHintRepository hintRepo,
        IHintProgressRepository hintPrgRepo,
        IPointsLedgerEntryRepository ptsLdgrRepo) {

            workshopRepository = wrepo;
            challengeRepository = crepo;
            _userManager = userManager;
            workshopProgressRepository = wprgRepo;
            challengeProgressRepository = chlgRepo;
            hintRepository = hintRepo;
            hintProgressRepository = hintPrgRepo;
            pointsLedgerEntryRepository = ptsLdgrRepo;
    }


    [HttpGet("/workshops/{workshopId}")]
    public ViewResult DisplayOneWorkshop(int workshopId) {
        string userId = _userManager.GetUserId(User); // && p.UserId == userId
        WorkshopProgress? userWp = workshopProgressRepository.WorkshopProgresses.Where(p => p.Workshop.WorkshopId == workshopId && p.UserId == userId).FirstOrDefault();
        Workshop? workshopObj = workshopRepository.Workshops.Where(p => p.WorkshopId == workshopId).FirstOrDefault();
        // HintProgress? hintWp = hintProgressRepository.HintProgresses.Where(p => p.WorkshopId == workshopId).FirstOrDefault();

        Console.WriteLine("And the userWp is...");
        Console.WriteLine(userWp);

        Console.WriteLine("And this is it!!");
        Console.WriteLine(workshopId);
        Console.WriteLine(challengeProgressRepository.ChallengeProgresses.Where(cp => cp.Workshop.WorkshopId == workshopId).Count());

        IEnumerable<Challenge> challenges = challengeRepository.Challenges.Where(p => p.Workshop.WorkshopId == workshopId);
        Dictionary<int,Challenge> ChallengeDict = new Dictionary<int,Challenge>();
        IEnumerable<ChallengeProgress> challengeProgressList = challengeProgressRepository.ChallengeProgresses.Where(cp => cp.Workshop.WorkshopId == workshopId && cp.UserId == userId);

        foreach (Challenge ch in challenges) {
            ChallengeDict[ch.ChallengeId] = ch;
        };

        return View(new OneWorkshopView {
            WorkshopObject = workshopObj,
            ChallengeProgressList = challengeProgressList,
            WorkshopProgressObject = userWp,
            WorkshopId = workshopId,
            ChallengesDictionary = ChallengeDict,
            // HintProgressOne = hintWp
        });
    }
    
    [HttpGet("/workshops/{workshopId}/challenges/{challengeId}")]
    [Authorize]
    public ViewResult DisplayOneChallenge(int workshopId, int challengeId) {
        string userId = "c91607c4-3903-482d-b1c7-25bcc13d4696"; // && p.UserId == userId
        WorkshopProgress? userWp = workshopProgressRepository.WorkshopProgresses.Where(p => p.Workshop.WorkshopId == workshopId && p.UserId == userId).FirstOrDefault();
        Workshop? workshopObj = workshopRepository.Workshops.Where(p => p.WorkshopId == workshopId).FirstOrDefault();
        ChallengeProgress? userChlg = challengeProgressRepository.ChallengeProgresses.Where(p => p.Challenge.ChallengeId == challengeId && p.UserId == userId).FirstOrDefault();
        
        IEnumerable<HintProgress> hintProgressList = hintProgressRepository.HintProgresses.Where(p => p.Hint.ChallengeId == challengeId && p.UserId == userId);
        IEnumerable<Hint> hintList = hintRepository.Hints.Where(p => p.ChallengeId == challengeId);

        Dictionary<int,Hint> hintDict = new Dictionary<int,Hint>();

        Console.WriteLine("And the hint ids are...");
        foreach (var h in hintList) {
            Console.WriteLine(h.HintId);
            hintDict.Add(h.HintId, h);
        };

        Console.WriteLine("====");

        foreach (var h in hintProgressList) {
            Console.WriteLine(h.HintProgressId.ToString(), "-", h.HintId);
        }

        Console.WriteLine("And this is the hint progresses");
        Console.WriteLine(hintProgressList);
        Console.WriteLine("And the hintDict is");
        Console.WriteLine(hintDict.Keys);


        return View(new OneWorkshopView {
            WorkshopObject = workshopObj,
            Challenges = challengeRepository.Challenges.Where(p => p.ChallengeId == challengeId),
            WorkshopProgressObject = userWp,
            ChallengeProgressObject = userChlg,
            ChallengeId = challengeId,
            WorkshopId = workshopId,
            HintProgressList = hintProgressList,
            HintDictionary = hintDict
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
        Workshop? workshopObj = workshopRepository.Workshops.Where(p => p.WorkshopId == workshopId).FirstOrDefault();
        string? userId = _userManager.GetUserId(User);

        IEnumerable<Challenge> challenges = challengeRepository.Challenges.Where(p => p.Workshop.WorkshopId == workshopId);

        foreach (Challenge ch in challenges) {
            ChallengeProgress challengeProgressObj = new ChallengeProgress {
                UserId = _userManager.GetUserId(User),
                Workshop = workshopObj,
                Challenge = ch,
                ChallengeStatus = "pending"
            };

            challengeProgressRepository.CreateChallengeProgress(challengeProgressObj);
        }

        WorkshopProgress workshopProgressObject = new WorkshopProgress {
            UserId = _userManager.GetUserId(User),
            Workshop = workshopObj
        };

        workshopProgressRepository.CreateWorkshopProgress(workshopProgressObject);

        return Redirect($"/workshops/{workshopId}");
    }

    [HttpPost("/displayHintForChallenge")]
    [Authorize]
    public IActionResult DisplayHintsForChallenge(int challengeId, int workshopId) {
        Challenge? chlg = challengeRepository.Challenges.Where(p => p.ChallengeId == challengeId).FirstOrDefault();
        IEnumerable<Hint> hints = hintRepository.Hints.Where(p => p.ChallengeId == challengeId);

        foreach (Hint h in hints) {
            HintProgress hintProgressObj = new HintProgress {
                UserId = _userManager.GetUserId(User),
                Hint = h,
                HintStatus = "pending"
            };

            hintProgressRepository.CreateHintProgress(hintProgressObj);
        };

        return Redirect($"/workshops/{workshopId}/challenges/{challengeId}");

    }

    [HttpPost("/buyThisHint")]
    [Authorize]
    public IActionResult BuyThisHint(int challengeId, int workshopId, int HintId) {
        string? userId = _userManager.GetUserId(User);

        HintProgress? hintProgressObj = hintProgressRepository.HintProgresses.Where(p => p.HintId == HintId && p.UserId == userId).FirstOrDefault();
        hintProgressObj.HintStatus = "bought";

        hintProgressRepository.SaveHintProgress(hintProgressObj);

        return Redirect($"/workshops/{workshopId}/challenges/{challengeId}");
    }


    [HttpPost("/workWithHints")]
    [Authorize]
    public IActionResult WorkWithHints(int workshopId) {
        Workshop? workshopObj = workshopRepository.Workshops.Where(p => p.WorkshopId == workshopId).FirstOrDefault();
        string? userId = _userManager.GetUserId(User);

        Console.WriteLine("And the workshopId");
        Console.WriteLine(workshopObj);
        Console.WriteLine(workshopObj.Name);
        Console.WriteLine("--");

        IEnumerable<Hint> hints = hintRepository.Hints.Where(p => p.Workshop.WorkshopId == workshopId);
        IList <HintProgress> hintProgressList = new List<HintProgress>();

        foreach (Hint h in hints) {
            HintProgress hintProgressObj = new HintProgress {
                UserId = _userManager.GetUserId(User),
                Hint = h,
                HintStatus = "pending"
            };

            hintProgressList.Add(hintProgressObj);
        };

        Console.WriteLine("And preprocess wise");
        Console.WriteLine(hintProgressList);
        Console.WriteLine(hints);
        Console.WriteLine(hints.Count());
        Console.WriteLine(hintProgressList);
        Console.WriteLine(hintProgressList.Count());

        hintProgressRepository.BatchCreateHintProgress(hintProgressList);


        return Redirect($"/workshops/{workshopId}");
    }

    [HttpPost("/submitChallenge")]
    [Authorize]
    public IActionResult SubmitChallenge(int workshopId, int challengeId) {
        Workshop workshopObj = workshopRepository.Workshops.Where(p => p.WorkshopId == workshopId).FirstOrDefault();
        Challenge challengeObj = challengeRepository.Challenges.Where(p => p.ChallengeId == challengeId).FirstOrDefault();
        string? userId = _userManager.GetUserId(User);

        ChallengeProgress? chPrg = challengeProgressRepository.ChallengeProgresses.Where(
            p => p.Challenge.ChallengeId == challengeId && p.UserId == userId)
            .FirstOrDefault();

        if (chPrg == null) {
            Console.WriteLine("Error");
        } else {
            Console.WriteLine("It is now pending...");

            chPrg.ChallengeStatus = "submitted";
            challengeProgressRepository.SaveChallengeProgress(chPrg);
        }
        return Redirect($"/workshops/{workshopId}/challenges/{challengeId}");
    }

    [HttpPost("/resubmitChallenge")]
    [Authorize]
    public IActionResult ResubmitChallenge(int workshopId, int challengeId) {
        Console.WriteLine("And the user is...");
        Console.WriteLine(this.User);
        Console.WriteLine("And the user id is...");
        Console.WriteLine(_userManager.GetUserId(User));
        string? userId = _userManager.GetUserId(User);

        ChallengeProgress? chPrg = challengeProgressRepository.ChallengeProgresses.Where(
            p => p.Challenge.ChallengeId == challengeId && p.UserId == userId)
            .FirstOrDefault();

        if (chPrg == null) {
            Console.WriteLine("Error");
        } else {
            Console.WriteLine("It is now pending...");

            chPrg.ChallengeStatus = "pending";
            challengeProgressRepository.SaveChallengeProgress(chPrg);
        }

        return Redirect($"/workshops/{workshopId}/challenges/{challengeId}");
    }

}