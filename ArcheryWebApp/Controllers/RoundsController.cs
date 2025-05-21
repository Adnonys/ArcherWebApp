using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ArcheryWebApp.Data;
using System.Linq;
using System.Threading.Tasks;

namespace ArcheryWebApp.Controllers
{
    public class RoundsController : Controller
    {
        private readonly ArcheryContext _db;
        public RoundsController(ArcheryContext db) => _db = db;

        public async Task<IActionResult> Details(int id)
        {
            var round = await _db.RoundTable.FindAsync(id);
            if (round == null) return NotFound();

            var ranges = await _db.RangeTable
                .Where(r => r.RoundID == id)
                .OrderBy(r => r.RangeOrder)
                .ToListAsync();

            ViewBag.RoundName = round.RoundName;
            return View(ranges);
        }
    }
}