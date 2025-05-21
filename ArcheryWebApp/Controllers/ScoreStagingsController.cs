using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ArcheryWebApp.Data;
using ArcheryWebApp.Models;
using System.Threading.Tasks;

namespace ArcheryWebApp.Controllers
{
    public class ScoreStagingsController : Controller
    {
        private readonly ArcheryContext _db;
        public ScoreStagingsController(ArcheryContext db) => _db = db;

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Rounds    = new SelectList(_db.RoundTable, "RoundID", "RoundName");
            ViewBag.Equipment = new SelectList(_db.Equipment, "EquipmentID", "EquipmentName");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ScoreStaging model)
        {
            model.IsPractice    = true;
            model.IsCompetition = false;
            model.ArcherID      = 1; // TODO: current user

            if (ModelState.IsValid)
            {
                _db.ScoreStaging.Add(model);
                await _db.SaveChangesAsync();
                return RedirectToAction("Index", "Scores");
            }

            ViewBag.Rounds    = new SelectList(_db.RoundTable, "RoundID", "RoundName");
            ViewBag.Equipment = new SelectList(_db.Equipment, "EquipmentID", "EquipmentName");
            return View(model);
        }
    }
}