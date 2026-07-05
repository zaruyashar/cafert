using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CAFERT.Data;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace CAFERT.Controllers
{
    [Authorize]
    public class MenuController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MenuController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var menuItems = await _context.MenuItems
                .OrderBy(m => m.SortOrder)
                .ThenBy(m => m.Name)
                .ToListAsync();
            return View(menuItems);
        }
    }
}
