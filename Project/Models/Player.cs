using Project.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Project.Models
{
    public partial class Player
    {
        public Player()
        {
            Team = new HashSet<Team>();
        }
        public int PlayerId { get; set; }
        [Required]
        [Range(0, 999999999)]
        public int FifaPlayerId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Picture { get; set; }
        [Required]
        public string Position { get; set; }
        [Required]
        [Range(0, 99)]
        public int Rating { get; set; }
        [Required]
        public string CardType { get; set; }
        [Range(0, 10000)]
        public int? GamesPlayed { get; set; }
        [Range(0, 999999)]
        public int? Goals { get; set; }
        [Range(0, 999999)]
        public int? Assists { get; set; }
        [Range(0, 999999)]
        public decimal? MatchRating { get; set; }
        [Range(0, 999999)]
        public int? OwnGoals { get; set; }
        [Range(0, 999999)]
        public int? ShotsOnTarget { get; set; }
        [Range(0, 999999)]
        public int? ShotsOffTarget { get; set; }
        [Range(0, 999999)]
        public int? PassesCompletedS { get; set; }
        [Range(0, 999999)]
        public int? PassesCompletedM { get; set; }
        [Range(0, 999999)]
        public int? PassesCompletedL { get; set; }
        [Range(0, 999999)]
        public int? PassesFailedS { get; set; }
        [Range(0, 999999)]
        public int? PassesFailedM { get; set; }
        [Range(0, 999999)]
        public int? PassesFailedL { get; set; }
        [Range(0, 999999)]
        public int? CrossesCompleted { get; set; }
        [Range(0, 999999)]
        public int? CrossesFailed { get; set; }
        [Range(0, 999999)]
        public int? KeyPasses { get; set; }
        [Range(0, 999999)]
        public int? DribblesCompleted { get; set; }
        [Range(0, 999999)]
        public int? DribblesAttempted { get; set; }
        [Range(0, 999999)]
        public int? KeyDribbles { get; set; }
        [Range(0, 999999)]
        public int? OneOnOneDribbles { get; set; }
        [Range(0, 999999)]
        public int? Fouled { get; set; }
        [Range(0, 999999)]
        public int? TacklesWon { get; set; }
        [Range(0, 999999)]
        public int? TacklesAttempted { get; set; }
        [Range(0, 999999)]
        public int? Fouls { get; set; }
        [Range(0, 999999)]
        public int? PensConceded { get; set; }
        [Range(0, 999999)]
        public int? Interceptions { get; set; }
        [Range(0, 999999)]
        public int? OutOfPosition { get; set; }
        [Range(0, 999999)]
        public int? Blocks { get; set; }
        [Range(0, 999999)]
        public int? PossessionWon { get; set; }
        [Range(0, 999999)]
        public int? PossessionLost { get; set; }
        [Range(0, 999999)]
        public int? Clearances { get; set; }
        [Range(0, 999999)]
        public int? HeadersWon { get; set; }
        [Range(0, 999999)]
        public int? HeadersLost { get; set; }
        [Range(0, 999999)]
        public int? GoalsConceded { get; set; }
        [Range(0, 999999)]
        public int? ShotsCaught { get; set; }
        [Range(0, 999999)]
        public int? ShotsParried { get; set; }
        [Range(0, 999999)]
        public int? CrossesCaught { get; set; }
        [Range(0, 999999)]
        public int? BallsStripped { get; set; }
        [Range(0, 999999)]
        public int? CleanSheets { get; set; }
        [Range(0, 999999)]
        public int? YellowCards { get; set; }
        [Range(0, 999999)]
        public int? RedCards { get; set; }
        [Range(0, 999999)]
        public int? Injuried { get; set; }
        [Range(0, 999999)]
        public int? ManOfTheMatch { get; set; }

        public double? Goalspergame => Math.Round((double)Goals.GetValueOrDefault() / (double)GamesPlayed.GetValueOrDefault(), 2);
        public double? Assistspergame => Math.Round((double)Assists.GetValueOrDefault() / (double)GamesPlayed.GetValueOrDefault(), 2);
        public double? AverageRating => Math.Round((double)MatchRating.GetValueOrDefault() / (double)GamesPlayed.GetValueOrDefault(), 2);
        public double? Goalspercenatge => Math.Round(((double)Goals.GetValueOrDefault() / ((double)ShotsOffTarget.GetValueOrDefault() + (double)ShotsOnTarget.GetValueOrDefault()) * 100), 2);
        public double? Passshortpercentage => Math.Round(((double)PassesCompletedS.GetValueOrDefault() / ((double)PassesCompletedS.GetValueOrDefault() + (double)PassesFailedS.GetValueOrDefault()) * 100), 2);
        public double? Passmidpercentage => Math.Round(((double)PassesCompletedM.GetValueOrDefault() / ((double)PassesCompletedM.GetValueOrDefault() + (double)PassesFailedM.GetValueOrDefault()) * 100), 2);
        public double? Passlongpercentage => Math.Round(((double)PassesCompletedL.GetValueOrDefault() / ((double)PassesCompletedL.GetValueOrDefault() + (double)PassesFailedL.GetValueOrDefault()) * 100), 2);
        public double? Passpercentage => Math.Round(((double)PassesCompletedS.GetValueOrDefault() + (double)PassesCompletedM.GetValueOrDefault() + (double)PassesCompletedL.GetValueOrDefault()) / ((double)PassesCompletedS.GetValueOrDefault() + (double)PassesFailedS.GetValueOrDefault() + (double)PassesCompletedM.GetValueOrDefault() + (double)PassesFailedM.GetValueOrDefault() + (double)PassesCompletedL.GetValueOrDefault() + (double)PassesFailedL.GetValueOrDefault()) * 100, 2);
        public double? Crossacc => Math.Round(((double)CrossesCompleted.GetValueOrDefault() / ((double)CrossesCompleted.GetValueOrDefault() + (double)CrossesFailed.GetValueOrDefault()) * 100), 2);
        public double? Keypasspergame => Math.Round((double)KeyPasses.GetValueOrDefault() / (double)GamesPlayed.GetValueOrDefault(), 2);
        public double? Keydribblepergame => Math.Round((double)KeyDribbles.GetValueOrDefault() / (double)GamesPlayed.GetValueOrDefault(), 2);
        public double? Tacklespercentage => Math.Round(((double)TacklesWon.GetValueOrDefault() / ((double)TacklesAttempted.GetValueOrDefault() + (double)TacklesWon.GetValueOrDefault()) * 100), 2);
        public double? Foulspertackle => Math.Round((double)Fouls.GetValueOrDefault() / ((double)TacklesAttempted.GetValueOrDefault() + (double)TacklesWon.GetValueOrDefault()), 2);
        public double? Goalsconcededpergame => Math.Round((double)GoalsConceded.GetValueOrDefault() / (double)GamesPlayed.GetValueOrDefault(), 2);




        public ICollection<Team> Team { get; set; }
    }
}
