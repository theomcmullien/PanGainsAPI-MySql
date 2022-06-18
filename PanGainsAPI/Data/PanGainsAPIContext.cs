#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PanGainsAPI.Models;

namespace PanGainsAPI.Data
{
    public class PanGainsAPIContext : DbContext
    {
        public PanGainsAPIContext (DbContextOptions<PanGainsAPIContext> options) : base(options)
        {

        }
        public DbSet<PanGainsAPI.Models.Account> Account { get; set; }
        public DbSet<PanGainsAPI.Models.ChallengeStats> ChallengeStats { get; set; }
        public DbSet<PanGainsAPI.Models.CompletedWorkout> CompletedWorkout { get; set; }
        public DbSet<PanGainsAPI.Models.DaysWorkedOut> DaysWorkedOut { get; set; }
        public DbSet<PanGainsAPI.Models.Exercise> Exercise { get; set; }
        public DbSet<PanGainsAPI.Models.Folder> Folder { get; set; }
        public DbSet<PanGainsAPI.Models.Leaderboard> Leaderboard { get; set; }
        public DbSet<PanGainsAPI.Models.Routine> Routine { get; set; }
        public DbSet<PanGainsAPI.Models.Set> Set { get; set; }
        public DbSet<PanGainsAPI.Models.Social> Social { get; set; }
        public DbSet<PanGainsAPI.Models.Statistics> Statistics { get; set; }
        public DbSet<PanGainsAPI.Models.UserAuth> UserAuth { get; set; }
        public DbSet<PanGainsAPI.Models.YourExercise> YourExercise { get; set; }
        public DbSet<PanGainsAPI.Models.Challenges>? Challenges { get; set; }
        

    }
}
