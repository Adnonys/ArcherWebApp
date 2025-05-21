using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ArcheryWebApp.Data;
using ArcheryWebApp.Models;
using ArcheryWebApp.ViewModels;  


namespace ArcheryWebApp.Controllers
{
    public class ArchersController : Controller
    {
        private readonly ArcheryContext _db;
        private const int PageSize = 25;

        public ArchersController(ArcheryContext db)
        {
            _db = db;
        }

        // GET: /Archers?page=1&searchTerm=...
        public async Task<IActionResult> Index(string searchTerm, int page = 1)
        {
            if (page < 1) page = 1;

            var query = _db.ArcherTable
                           .Include(a => a.DefaultEquipment)
                           .AsQueryable();

            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                query = query.Where(a =>
                    a.FirstName.Contains(searchTerm) ||
                    a.LastName.Contains(searchTerm));
            }

            var totalCount = await query.CountAsync();
            var archers = await query
                .OrderBy(a => a.LastName)
                .ThenBy(a => a.FirstName)
                .Skip((page - 1) * PageSize)
                .Take(PageSize)
                .ToListAsync();

            var vm = new ArcherListViewModel {
                Archers    = archers,
                SearchTerm = searchTerm,
                PageNumber = page,
                TotalPages = (int)Math.Ceiling(totalCount / (double)PageSize)
            };

            return View(vm);
        }

        // GET: /Archers/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var archer = await _db.ArcherTable
                .Include(a => a.DefaultEquipment)
                .FirstOrDefaultAsync(a => a.ArcherID == id);
            if (archer == null) return NotFound();
            return View(archer);
        }

        #region Create
                    
        // GET: /Archers/Create
        public IActionResult Create()
        {
            ViewBag.Classes = new SelectList(_db.ClassTable, "ClassID", "ClassName");
            ViewBag.Divisions = new SelectList(_db.DivisionTable, "DivisionID", "DivisionName");
            ViewBag.Equipments = new SelectList(_db.Equipment, "EquipmentID", "EquipmentName");
            return View(new ArcherCreateVm());
        }

// POST: /Archers/Create
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ArcherCreateVm vm)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Classes = new SelectList(_db.ClassTable, "ClassID", "ClassName", vm.ClassID);
                ViewBag.Divisions = new SelectList(_db.DivisionTable, "DivisionID", "DivisionName", vm.DefaultDivisionID);
                ViewBag.Equipments = new SelectList(_db.Equipment, "EquipmentID", "EquipmentName", vm.DefaultEquipmentID);
                return View(vm);
            }

            var archer = new Archer
            {
                // Không cần gán ArcherID, sẽ được tự động sinh
                FirstName = vm.FirstName,
                LastName = vm.LastName,
                Gender = vm.Gender,
                DOB = vm.DOB,
                ClassID = vm.ClassID,
                DefaultDivisionID = vm.DefaultDivisionID,
                DefaultEquipmentID = vm.DefaultEquipmentID,
                IsActive = true
            };

            _db.ArcherTable.Add(archer);  // Vẫn giữ tên DbSet là ArcherTable
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


        #endregion

        // GET: /Archers/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var archer = await _db.ArcherTable.FindAsync(id);
            if (archer == null) return NotFound();
            ViewBag.Equipments = new SelectList(_db.Equipment,
               "EquipmentID", "EquipmentName", archer.DefaultEquipmentID);
            return View(archer);
        }

        // POST: /Archers/Edit/5
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Archer archer)
        {
            if (id != archer.ArcherID) return BadRequest();
            if (ModelState.IsValid)
            {
                _db.Entry(archer).State = EntityState.Modified;
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Equipments = new SelectList(_db.Equipment,
               "EquipmentID", "EquipmentName", archer.DefaultEquipmentID);
            return View(archer);
        }

        // GET: /Archers/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var archer = await _db.ArcherTable
                .Include(a => a.DefaultEquipment)
                .FirstOrDefaultAsync(a => a.ArcherID == id);
            if (archer == null) return NotFound();
            return View(archer);
        }

        // POST: /Archers/Delete/5
        [HttpPost, ActionName("Delete"), ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var archer = await _db.ArcherTable.FindAsync(id);
            if (archer != null)
            {
                _db.ArcherTable.Remove(archer);
                await _db.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
