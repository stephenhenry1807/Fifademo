using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Security.Principal;
using Project.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using System.Collections;

namespace Project.Controllers
    
{
    public class PlayersController : Controller
    {
        private readonly ProjectContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public PlayersController(ProjectContext context,
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
        }



        // GET: Players
        [Authorize]
        //[Authorize(Roles = "Admin")]
        public async Task<IActionResult> Index(string sortOrder, string search)
        {
            Team team = new Team();
            Player player = new Player();

            ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewData["PositionSortParm"] = sortOrder == "position" ? "position_desc" : "position";
            ViewData["RatingSortParm"] = sortOrder == "rating" ? "rating_desc" : "rating";
            ViewData["CardTypeSortParm"] = sortOrder == "cardtype" ? "cardtype_desc" : "cardtype";
            ViewData["GamesPlayedSortParm"] = sortOrder == "gamesplayed" ? "gamesplayed_desc" : "gamesplayed";
            ViewData["GoalsSortParm"] = sortOrder == "goals" ? "goals_desc" : "goals";
            ViewData["GpgSortParm"] = sortOrder == "goalspergame" ? "goalspergame_desc" : "goalspergame";
            ViewData["AssistsSortParm"] = sortOrder == "assists" ? "assists_desc" : "assists";
            ViewData["ApgSortParm"] = sortOrder == "assistspergame" ? "assistspergame_desc" : "assistspergame";
            ViewData["Search"] = search;

            if (_signInManager.IsSignedIn(User))
            {
                if (User.IsInRole("Admin"))
                {
                    string adminq = "SELECT * FROM [Player]";
                    var adq = _context.Player
                        .FromSql(adminq);

                    if (!String.IsNullOrEmpty(search))
                    {
                        adq = adq.Where(s => s.Name.Contains(search));
                    }

                    switch (sortOrder)
                    {
                        case "name_desc":
                            adq = adq.OrderByDescending(s => s.Name);
                            break;
                        case "position":
                            adq = adq.OrderByDescending(s => s.Position);
                            break;
                        case "position_desc":
                            adq = adq.OrderBy(s => s.Position);
                            break;
                        case "rating":
                            adq = adq.OrderByDescending(s => s.Rating);
                            break;
                        case "rating_desc":
                            adq = adq.OrderBy(s => s.Rating);
                            break;
                        case "cardtype":
                            adq = adq.OrderBy(s => s.CardType);
                            break;
                        case "cardtype_desc":
                            adq = adq.OrderByDescending(s => s.CardType);
                            break;
                        case "gamesplayed":
                            adq = adq.OrderByDescending(s => s.GamesPlayed);
                            break;
                        case "gamesplayed_desc":
                            adq = adq.OrderBy(s => s.GamesPlayed);
                            break;
                        case "goals":
                            adq = adq.OrderByDescending(s => s.Goals);
                            break;
                        case "goals_desc":
                            adq = adq.OrderBy(s => s.Goals);
                            break;
                        case "goalspergame":
                            adq = adq.OrderByDescending(s => s.Goalspergame);
                            break;
                        case "goalspergame_desc":
                            adq = adq.OrderBy(s => s.Goalspergame);
                            break;
                        case "assists":
                            adq = adq.OrderByDescending(s => s.Assists);
                            break;
                        case "assists_desc":
                            adq = adq.OrderBy(s => s.Assists);
                            break;
                        case "assistspergame":
                            adq = adq.OrderByDescending(s => s.Assistspergame);
                            break;
                        case "assistspergame_desc":
                            adq = adq.OrderBy(s => s.Assistspergame);
                            break;
                        default:
                            adq = adq.OrderBy(s => s.Name);
                            break;
                    }

                        

                    return View(await adq.AsNoTracking()
                        .ToListAsync());
                }
                else
                {
                    var use = _userManager.GetUserId(User);

                    string query = "SELECT * FROM [Team] AS [p] JOIN [Player] AS [q] ON [p].[Players_ID] = [q].[Player_ID] WHERE [p].[User_ID] = '" + use + "'";
                    var qu = _context.Player
                        .FromSql(query);

                    if (!String.IsNullOrEmpty(search))
                    {
                        qu = qu.Where(s => s.Name.Contains(search));
                    }

                    switch (sortOrder)
                    {
                        case "name_desc":
                            qu = qu.OrderByDescending(s => s.Name);
                            break;
                        case "Position":
                            qu = qu.OrderBy(s => s.Position);
                            break;
                        case "position_desc":
                            qu = qu.OrderByDescending(s => s.Position);
                            break;
                        case "rating":
                            qu = qu.OrderByDescending(s => s.Rating);
                            break;
                        case "rating_desc":
                            qu = qu.OrderBy(s => s.Rating);
                            break;
                        case "cardtype":
                            qu = qu.OrderBy(s => s.CardType);
                            break;
                        case "cardtype_desc":
                            qu = qu.OrderByDescending(s => s.CardType);
                            break;
                        case "gamesplayed":
                            qu = qu.OrderByDescending(s => s.GamesPlayed);
                            break;
                        case "gamesplayed_desc":
                            qu = qu.OrderBy(s => s.GamesPlayed);
                            break;
                        case "goals":
                            qu = qu.OrderByDescending(s => s.Goals);
                            break;
                        case "goals_desc":
                            qu = qu.OrderBy(s => s.Goals);
                            break;
                        case "goalspergame":
                            qu = qu.OrderByDescending(s => s.Goalspergame);
                            break;
                        case "goalspergame_desc":
                            qu = qu.OrderBy(s => s.Goalspergame);
                            break;
                        case "assists":
                            qu = qu.OrderByDescending(s => s.Assists);
                            break;
                        case "assists_desc":
                            qu = qu.OrderBy(s => s.Assists);
                            break;
                        case "assistspergame":
                            qu = qu.OrderByDescending(s => s.Assistspergame);
                            break;
                        case "assistspergame_desc":
                            qu = qu.OrderBy(s => s.Assistspergame);
                            break;
                        default:
                            qu = qu.OrderBy(s => s.Name);
                            break;
                    }

                    return View(await qu.AsNoTracking()
                        .ToListAsync());
                }
            }
            else
            {
                return View();
            }
        }

        
        // GET: Players/Details/5
        [Authorize]
        public async Task<IActionResult> Details(int? id)
        {
            CompareViewModel compareviewmodel = new CompareViewModel();
            

            if (id == null)
            {
                return NotFound();
            }
            if (User.IsInRole("Admin"))
            {
                var player = await _context.Player
               .SingleOrDefaultAsync(m => m.PlayerId == id);
                if (player == null)
                {
                    return NotFound();
                }

                return View(player);
            }
            else
            {
                var use = _userManager.GetUserId(User);
                var details = "SELECT * FROM [Team] AS [p] JOIN [Player] AS [q] ON [p].[Players_ID] = [q].[Player_ID] WHERE [p].[User_ID] = '" + use + "' AND[q].[Player_ID] = " + id;

                var qu = await _context.Player
                        .FromSql(details)
                        .AsNoTracking()
                        .SingleOrDefaultAsync();

                if(qu == null)
                {
                    return NotFound();
                }

                return View(qu);
            }
           
        }

        public async Task<IActionResult> Compare(int? id, int? id2, string user2, int? id3, string user3, int? id4, string user4)
        {
            var viewModel = new CompareViewModel();

            viewModel.AspNetUsers = await _context.AspNetUsers
                  .ToListAsync();

            if (user2 != null)
            {
                
                var details = "SELECT * FROM [Team] AS [p] JOIN [Player] AS [q] ON [p].[Players_ID] = [q].[Player_ID] WHERE [p].[User_ID] = '" + user2 + "'";

                var qu = await _context.Player
                        .FromSql(details)
                        .AsNoTracking()
                        .ToListAsync();

                viewModel.Player2 = qu;
            }

            if (user3 != null)
            {

                var details = "SELECT * FROM [Team] AS [p] JOIN [Player] AS [q] ON [p].[Players_ID] = [q].[Player_ID] WHERE [p].[User_ID] = '" + user3 + "'";

                var qu = await _context.Player
                        .FromSql(details)
                        .AsNoTracking()
                        .ToListAsync();

                viewModel.Player3 = qu;
            }

            if (user4 != null)
            {

                var details = "SELECT * FROM [Team] AS [p] JOIN [Player] AS [q] ON [p].[Players_ID] = [q].[Player_ID] WHERE [p].[User_ID] = '" + user4 + "'";

                var qu = await _context.Player
                        .FromSql(details)
                        .AsNoTracking()
                        .ToListAsync();

                viewModel.Player4 = qu;
            }

            
             if (id != null)
             {
                if (User.IsInRole("Admin"))
                {
                    var use = _userManager.GetUserId(User);
                    var details = "SELECT * FROM [Team] AS [p] JOIN [Player] AS [q] ON [p].[Players_ID] = [q].[Player_ID] WHERE [q].[Player_ID] = " + id;

                    var qu = await _context.Player
                        .FromSql(details)
                        .AsNoTracking()
                        .ToListAsync();
                    viewModel.Player = qu;
                }
                else
                {
                    {
                        var use = _userManager.GetUserId(User);
                        var details = "SELECT * FROM [Team] AS [p] JOIN [Player] AS [q] ON [p].[Players_ID] = [q].[Player_ID] WHERE [p].[User_ID] = '" + use + "' AND[q].[Player_ID] = " + id;

                        var qu = await _context.Player
                                .FromSql(details)
                                .AsNoTracking()
                                .ToListAsync();
                        viewModel.Player = qu;
                    }
                }
            }
            if (id2 != null)
            {
                var details = "SELECT * FROM [Team] AS [p] JOIN [Player] AS [q] ON [p].[Players_ID] = [q].[Player_ID] WHERE [q].[Player_ID] = " + id2;

                var qu = await _context.Player
                        .FromSql(details)
                        .AsNoTracking()
                        .ToListAsync();
                viewModel.Player2display = qu;
            }

            if (id3 != null)
            {
                var details = "SELECT * FROM [Team] AS [p] JOIN [Player] AS [q] ON [p].[Players_ID] = [q].[Player_ID] WHERE [q].[Player_ID] = " + id3;

                var qu = await _context.Player
                        .FromSql(details)
                        .AsNoTracking()
                        .ToListAsync();
                viewModel.Player3display = qu;
            }

            if (id4 != null)
            {
                var details = "SELECT * FROM [Team] AS [p] JOIN [Player] AS [q] ON [p].[Players_ID] = [q].[Player_ID] WHERE [q].[Player_ID] = " + id4;

                var qu = await _context.Player
                        .FromSql(details)
                        .AsNoTracking()
                        .ToListAsync();
                viewModel.Player4display = qu;
            }
            
            return View(viewModel);
        }

        // GET: Players/Create  
        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Players/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PlayerId,FifaPlayerId,Name,Picture,Position,Rating,CardType,GamesPlayed,Goals,Assists,MatchRating,OwnGoals,ShotsOnTarget,ShotsOffTarget,PassesCompletedS,PassesCompletedM,PassesCompletedL,PassesFailedS,PassesFailedM,PassesFailedL,CrossesCompleted,CrossesFailed,KeyPasses,DribblesCompleted,DribblesAttempted,KeyDribbles,OneOnOneDribbles,Fouled,TacklesWon,TacklesAttempted,Fouls,PensConceded,Interceptions,OutOfPosition,Blocks,Clearances,HeadersWon,HeadersLost,GoalsConceded,ShotsCaught,ShotsParried,CrossesCaught,BallsStripped,YellowCards,RedCards,Injuried,ManOfTheMatch")] Player player)
        {
            Team team = new Team();
           
            if (ModelState.IsValid)
            {
                _context.Add(player);
                var inc = player.PlayerId;
                team.UserId = _userManager.GetUserId(User);
                team.PlayersId = inc;
                _context.Team.Add(team);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(player);
        }

        // GET: Players/Edit/5
        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            if (User.IsInRole("Admin"))
            {
                var player = await _context.Player
                .SingleOrDefaultAsync(m => m.PlayerId == id);
                if (player == null)
                {
                    return NotFound();
                }

                return View(player);
            }
            else
            {
                var use = _userManager.GetUserId(User);

                var query = "SELECT * FROM [Team] AS [p] JOIN [Player] AS [q] ON [p].[Players_ID] = [q].[Player_ID] WHERE [p].[User_ID] = '" + use + "' AND[q].[Player_ID] = " + id;

                var qu = await _context.Player
                        .FromSql(query)
                        .AsNoTracking()
                        .SingleOrDefaultAsync();
                if (qu == null)
                {
                    return NotFound();
                }
                return View(qu);

            }
        }

        // POST: Players/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditPlayer(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var playerUpdate = await _context.Player.SingleOrDefaultAsync(s => s.PlayerId == id);
            if (await TryUpdateModelAsync<Player>(playerUpdate, "", s => s.GamesPlayed, s => s.Goals, s => s.Assists, s => s.MatchRating, s => s.OwnGoals, s => s.ShotsOnTarget, s => s.ShotsOffTarget, s => s.PassesCompletedS, s => s.PassesCompletedM, s => s.PassesCompletedL, s => s.PassesFailedS, s => s.PassesFailedM, s => s.PassesFailedL, s => s.CrossesCompleted, s => s.CrossesFailed, s => s.KeyPasses, s => s.DribblesCompleted, s => s.DribblesAttempted, s => s.KeyDribbles, s => s.OneOnOneDribbles, s => s.Fouled, s => s.TacklesWon, s => s.TacklesAttempted, s => s.Fouls, s => s.PensConceded, s => s.Interceptions, s => s.OutOfPosition, s => s.Blocks, s => s.PossessionWon, s => s.PossessionLost, s => s.Clearances, s => s.HeadersWon, s => s.HeadersLost, s => s.GoalsConceded, s => s.ShotsCaught, s => s.ShotsParried, s => s.CrossesCaught, s => s.BallsStripped, s => s.CleanSheets, s => s.YellowCards, s => s.RedCards, s => s.Injuried, s => s.ManOfTheMatch))
            {
                try
                {
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateConcurrencyException)
                {
                    ModelState.AddModelError("", "Unable to save changes. " +
                "Try again, and if the problem persists, " +
                "see your system administrator.");
                }
            }
            return View(playerUpdate);
        }

        // GET: Players/Delete/5
        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            if (User.IsInRole("Admin"))
            {
                var player = await _context.Player
                .SingleOrDefaultAsync(m => m.PlayerId == id);
                if (player == null)
                {
                    return NotFound();
                }

                return View(player);
            }
            else
            {
                var use = _userManager.GetUserId(User);

                var query = "SELECT* FROM [Team] AS [p] JOIN [Player] AS [q] ON [p].[Players_ID] = [q].[Player_ID] WHERE [p].[User_ID] = '" + use + "' AND[q].[Player_ID] = " + id;

                var qu = await _context.Player
                        .FromSql(query)
                        .AsNoTracking()
                        .SingleOrDefaultAsync();
                if(qu == null)
                {
                    return NotFound();
                }
                return View(qu);
            }
        }

        // POST: Players/Delete/5
        [Authorize]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
           
                var player = await _context.Player.SingleOrDefaultAsync(m => m.PlayerId == id);
                var team = await _context.Team.SingleOrDefaultAsync(m => m.PlayersId == id);
                _context.Player.Remove(player);
                _context.Team.Remove(team);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            //}
            //else
            //{
            //    var use = _userManager.GetUserId(User);
            //
              //  var query = "Delete player FROM [Team] AS [p] JOIN [Player] AS [q] ON [p].[Players_ID] = [q].[Player_ID] WHERE [p].[User_ID] = '" + use + "' AND [q].[Player_ID] = " + id;
              //
                //var qu = await _context.Player
                  //      .FromSql(query)
                    //    .AsNoTracking()
                      //  .SingleOrDefaultAsync();
                //return RedirectToAction(nameof(Index));
            //}
        }

        private bool PlayerExists(int id)
        {
            return _context.Player.Any(e => e.PlayerId == id);
        }
    }
}
