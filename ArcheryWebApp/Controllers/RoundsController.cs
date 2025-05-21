using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ArcheryWebApp.Data;
using ArcheryWebApp.Models;
using System.Linq;
using System.Threading.Tasks;

namespace ArcheryWebApp.Controllers
{
    public class RoundsController : Controller
    {
        private readonly ArcheryContext _db;

        public RoundsController(ArcheryContext db)
        {
            _db = db;
        }

        // GET: /Rounds
        public async Task<IActionResult> Index()
        {
            var rounds = await _db.RoundTable.ToListAsync();
            return View(rounds);
        }

        // GET: /Rounds/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var round = await _db.RoundTable.FindAsync(id);
            if (round == null)
                return NotFound();

            // Lấy danh sách ranges theo thứ tự tăng dần
            var ranges = await _db.Ranges
                .Where(r => r.RoundID == id)
                .OrderBy(r => r.RangeOrder)
                .ToListAsync();

            ViewBag.Round = round;
            return View(ranges);
        }
    }
}