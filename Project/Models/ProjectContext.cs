using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Project.Models
{
    public partial class ProjectContext : DbContext
    {
        public virtual DbSet<AspNetRoleClaims> AspNetRoleClaims { get; set; }
        public virtual DbSet<AspNetRoles> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaims> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogins> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUserRoles> AspNetUserRoles { get; set; }
        public virtual DbSet<AspNetUsers> AspNetUsers { get; set; }
        public virtual DbSet<AspNetUserTokens> AspNetUserTokens { get; set; }
        public virtual DbSet<Player> Player { get; set; }
        public virtual DbSet<Team> Team { get; set; }

        public ProjectContext(DbContextOptions<ProjectContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AspNetRoleClaims>(entity =>
            {
                entity.HasIndex(e => e.RoleId);

                entity.Property(e => e.RoleId).IsRequired();

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetRoleClaims)
                    .HasForeignKey(d => d.RoleId);
            });

            modelBuilder.Entity<AspNetRoles>(entity =>
            {
                entity.HasIndex(e => e.NormalizedName)
                    .HasName("RoleNameIndex");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name).HasMaxLength(256);

                entity.Property(e => e.NormalizedName).HasMaxLength(256);
            });

            modelBuilder.Entity<AspNetUserClaims>(entity =>
            {
                entity.HasIndex(e => e.UserId);

                entity.Property(e => e.UserId).IsRequired();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserClaims)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserLogins>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });

                entity.HasIndex(e => e.UserId);

                entity.Property(e => e.UserId).IsRequired();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserLogins)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserRoles>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.RoleId });

                entity.HasIndex(e => e.RoleId);

                entity.HasIndex(e => e.UserId);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.RoleId);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUsers>(entity =>
            {
                entity.HasIndex(e => e.NormalizedEmail)
                    .HasName("EmailIndex");

                entity.HasIndex(e => e.NormalizedUserName)
                    .HasName("UserNameIndex")
                    .IsUnique();

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Email).HasMaxLength(256);

                entity.Property(e => e.NormalizedEmail).HasMaxLength(256);

                entity.Property(e => e.NormalizedUserName).HasMaxLength(256);

                entity.Property(e => e.UserName).HasMaxLength(256);
            });

            modelBuilder.Entity<AspNetUserTokens>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });
            });

            modelBuilder.Entity<Player>(entity =>
            {
                entity.Property(e => e.PlayerId).HasColumnName("Player_ID");

                entity.Property(e => e.Assists).HasDefaultValueSql("((0))");

                entity.Property(e => e.BallsStripped)
                    .HasColumnName("Balls_Stripped")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Blocks).HasDefaultValueSql("((0))");

                entity.Property(e => e.CardType)
                    .IsRequired()
                    .HasColumnName("Card_Type")
                    .HasMaxLength(30);

                entity.Property(e => e.Clearances).HasDefaultValueSql("((0))");

                entity.Property(e => e.CleanSheets)
                    .HasColumnName("Clean_Sheets")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.CrossesCaught)
                    .HasColumnName("Crosses_Caught")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.CrossesCompleted)
                    .HasColumnName("Crosses_Completed")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.CrossesFailed)
                    .HasColumnName("Crosses_Failed")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.DribblesAttempted)
                    .HasColumnName("Dribbles_Attempted")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.DribblesCompleted)
                    .HasColumnName("Dribbles_Completed")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.FifaPlayerId).HasColumnName("Fifa_Player_ID");

                entity.Property(e => e.Fouled).HasDefaultValueSql("((0))");

                entity.Property(e => e.Fouls).HasDefaultValueSql("((0))");

                entity.Property(e => e.GamesPlayed)
                    .HasColumnName("Games_Played")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Goals).HasDefaultValueSql("((0))");

                entity.Property(e => e.GoalsConceded)
                    .HasColumnName("Goals_Conceded")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.HeadersLost)
                    .HasColumnName("Headers_Lost")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.HeadersWon)
                    .HasColumnName("Headers_Won")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Injuried).HasDefaultValueSql("((0))");

                entity.Property(e => e.Interceptions).HasDefaultValueSql("((0))");

                entity.Property(e => e.KeyDribbles)
                    .HasColumnName("Key_Dribbles")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.KeyPasses)
                    .HasColumnName("Key_Passes")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.ManOfTheMatch)
                    .HasColumnName("Man_Of_The_Match")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.MatchRating)
                    .HasColumnName("Match_Rating")
                    .HasColumnType("decimal(10, 1)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.OneOnOneDribbles)
                    .HasColumnName("One_On_One_Dribbles")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.OutOfPosition)
                    .HasColumnName("Out_Of_Position")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.OwnGoals)
                    .HasColumnName("Own_Goals")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.PassesCompletedL)
                    .HasColumnName("Passes_Completed_L")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.PassesCompletedM)
                    .HasColumnName("Passes_Completed_M")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.PassesCompletedS)
                    .HasColumnName("Passes_Completed_S")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.PassesFailedL)
                    .HasColumnName("Passes_Failed_L")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.PassesFailedM)
                    .HasColumnName("Passes_Failed_M")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.PassesFailedS)
                    .HasColumnName("Passes_Failed_S")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.PensConceded)
                    .HasColumnName("Pens_Conceded")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Picture)
                    .IsRequired()
                    .HasMaxLength(300);

                entity.Property(e => e.Position)
                    .IsRequired()
                    .HasColumnType("nchar(3)");

                entity.Property(e => e.PossessionLost)
                    .HasColumnName("Possession_Lost")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.PossessionWon)
                    .HasColumnName("Possession_Won")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.RedCards)
                    .HasColumnName("Red_Cards")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.ShotsCaught)
                    .HasColumnName("Shots_Caught")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.ShotsOffTarget)
                    .HasColumnName("Shots_Off_Target")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.ShotsOnTarget)
                    .HasColumnName("Shots_On_Target")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.ShotsParried)
                    .HasColumnName("Shots_Parried")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.TacklesAttempted)
                    .HasColumnName("Tackles_Attempted")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.TacklesWon)
                    .HasColumnName("Tackles_Won")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.YellowCards)
                    .HasColumnName("Yellow_Cards")
                    .HasDefaultValueSql("((0))");
            });

            modelBuilder.Entity<Team>(entity =>
            {
                entity.HasKey(e => new { e.PlayersId, e.UserId });

                entity.Property(e => e.PlayersId).HasColumnName("Players_ID");

                entity.Property(e => e.UserId).HasColumnName("User_ID");

                entity.HasOne(d => d.Player)
                    .WithMany(p => p.Team)
                    .HasForeignKey(d => d.PlayersId)
                    .HasConstraintName("FK_Team_Player");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Team)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_Team_AspNetUsers");
            });
        }
    }
}
