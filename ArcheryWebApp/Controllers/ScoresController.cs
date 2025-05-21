using ArcheryWebApp.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

public class ScoresController : Controller
{
    private readonly ArcheryContext _db;

    public ScoresController(ArcheryContext db)
    {
        _db = db;
    }

    // GET: /Scores?archerId=1&roundId=0&from=2023-01-01&to=2023-12-31
    public async Task<IActionResult> Index(int archerId, int roundId = 0, DateTime? from = null, DateTime? to = null)
    {
        // Nếu không có archerId, chuyển về trang Archers
        if (archerId <= 0)
            return RedirectToAction("Index", "Archers");

        // Lấy thông tin archer để hiển thị tên
        var archer = await _db.ArcherTable.FindAsync(archerId);
        if (archer == null)
            return NotFound();

        ViewBag.ArcherName = $"{archer.FirstName} {archer.LastName}";
        ViewBag.ArcherId = archerId;

        // Query điểm số theo filter
        var query = _db.ScoreTable
            .Include(s => s.Round)
            .Where(s => s.ArcherID == archerId);

        if (roundId > 0)
            query = query.Where(s => s.RoundID == roundId);

        if (from.HasValue)
            query = query.Where(s => s.DateShot >= from.Value);

        if (to.HasValue)
            query = query.Where(s => s.DateShot <= to.Value);

        var scores = await query
            .OrderByDescending(s => s.DateShot)
            .ThenByDescending(s => s.TotalScore)
            .ToListAsync();

        // Lấy danh sách rounds cho dropdown filter
        ViewBag.Rounds = new SelectList(await _db.RoundTable.ToListAsync(), "RoundID", "RoundName", roundId);
        ViewBag.FromDate = from?.ToString("yyyy-MM-dd");
        ViewBag.ToDate = to?.ToString("yyyy-MM-dd");

        return View(scores);
    }
}