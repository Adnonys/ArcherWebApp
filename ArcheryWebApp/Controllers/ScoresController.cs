using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ArcheryWebApp.Data;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ArcheryWebApp.Controllers
{
    public class ScoresController : Controller
    {
        private readonly ArcheryContext _db;
        public ScoresController(ArcheryContext db) => _db = db;

        // GET: /Scores?roundId=...&from=...&to=...
        public async Task<IActionResult> Index(int roundId = 0, DateTime? from = null, DateTime? to = null)
        {
            int archerId = 1; // TODO: get from auth
            var query = _db.ScoreTable
                .Include(s => s.Round)
                .Where(s => s.ArcherID == archerId);

            if (roundId != 0)   query = query.Where(s => s.RoundID == roundId);
            if (from.HasValue)  query = query.Where(s => s.DateShot >= from.Value);
            if (to.HasValue)    query = query.Where(s => s.DateShot <= to.Value);

            var scores = await query
                .OrderByDescending(s => s.DateShot)
                .ThenByDescending(s => s.TotalScore)
                .ToListAsync();

            ViewBag.Rounds = new SelectList(_db.RoundTable, "RoundID", "RoundName");
            return View(scores);
        }
    }
}