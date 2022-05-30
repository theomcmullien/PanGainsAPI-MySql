#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PanGainsAPI.Data;
using PanGainsAPI.Models;

namespace PanGainsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class LeaderboardStatsController : ControllerBase
    {
        private readonly PanGainsAPIContext _context;

        public LeaderboardStatsController(PanGainsAPIContext context)
        {
            _context = context;
        }

        // GET: api/LeaderboardStats/5
        [HttpGet("{leaderboardDate}")]
        public async Task<ActionResult<IEnumerable<ChallengeStats>>> GetLeaderboardStats(DateTime leaderboardDate)
        {
            IEnumerable<ChallengeStats> challengeStatsList = await _context.ChallengeStats.ToListAsync();
            IEnumerable<Leaderboard> leaderboardList = await _context.Leaderboard.ToListAsync();

            int leaderboardID = leaderboardList.Where(l => l.LeaderboardDate.Month == leaderboardDate.Month && l.LeaderboardDate.Year == leaderboardDate.Year).Select(l => l.LeaderboardID).First();

            ChallengeStats[] challengeStats = challengeStatsList.Where(c => c.LeaderboardID == leaderboardID).ToArray();

            if (challengeStats == null) return NotFound();

            return challengeStats;
        }
    }
}
