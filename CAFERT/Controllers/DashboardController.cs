using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CAFERT.Data;
using CAFERT.Models;
using System.Threading.Tasks;
using System.Linq;

namespace CAFERT.Controllers
{
    public class DashboardController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DashboardController(ApplicationDbContext context)
        {
            _context = context;
        }

        // ==========================================
        // OVERVIEW
        // ==========================================
        public async Task<IActionResult> Index()
        {
            ViewBag.TotalMenuItems = await _context.MenuItems.CountAsync();
            ViewBag.FeaturedItemsCount = await _context.MenuItems.CountAsync(m => m.IsFeatured);
            ViewBag.TotalTeamMembers = await _context.TeamMembers.CountAsync();
            
            return View();
        }

        // ==========================================
        // MENU CRUD
        // ==========================================
        public async Task<IActionResult> MenuItems()
        {
            var items = await _context.MenuItems
                .OrderBy(m => m.SortOrder)
                .ThenBy(m => m.Name)
                .ToListAsync();
            return View(items);
        }

        [HttpGet]
        public IActionResult CreateMenuItem()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateMenuItem(MenuItem item)
        {
            if (ModelState.IsValid)
            {
                _context.MenuItems.Add(item);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(MenuItems));
            }
            return View(item);
        }

        [HttpGet]
        public async Task<IActionResult> EditMenuItem(int id)
        {
            var item = await _context.MenuItems.FindAsync(id);
            if (item == null)
            {
                return NotFound();
            }
            return View(item);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditMenuItem(int id, MenuItem item)
        {
            if (id != item.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(item);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.MenuItems.Any(e => e.Id == item.Id))
                    {
                        return NotFound();
                    }
                    throw;
                }
                return RedirectToAction(nameof(MenuItems));
            }
            return View(item);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteMenuItem(int id)
        {
            var item = await _context.MenuItems.FindAsync(id);
            if (item != null)
            {
                _context.MenuItems.Remove(item);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(MenuItems));
        }

        // ==========================================
        // TEAM CRUD
        // ==========================================
        public async Task<IActionResult> TeamMembers()
        {
            var members = await _context.TeamMembers
                .OrderBy(m => m.SortOrder)
                .ToListAsync();
            return View(members);
        }

        [HttpGet]
        public IActionResult CreateTeamMember()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateTeamMember(TeamMember member)
        {
            if (ModelState.IsValid)
            {
                _context.TeamMembers.Add(member);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(TeamMembers));
            }
            return View(member);
        }

        [HttpGet]
        public async Task<IActionResult> EditTeamMember(int id)
        {
            var member = await _context.TeamMembers.FindAsync(id);
            if (member == null)
            {
                return NotFound();
            }
            return View(member);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditTeamMember(int id, TeamMember member)
        {
            if (id != member.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(member);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.TeamMembers.Any(e => e.Id == member.Id))
                    {
                        return NotFound();
                    }
                    throw;
                }
                return RedirectToAction(nameof(TeamMembers));
            }
            return View(member);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteTeamMember(int id)
        {
            var member = await _context.TeamMembers.FindAsync(id);
            if (member != null)
            {
                _context.TeamMembers.Remove(member);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(TeamMembers));
        }
    }
}
