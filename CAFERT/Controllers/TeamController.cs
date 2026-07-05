using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CAFERT.Data;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace CAFERT.Controllers
{
    [Authorize]
    public class TeamController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TeamController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var teamMembers = await _context.TeamMembers
                .OrderBy(m => m.SortOrder)
                .ToListAsync();
            return View(teamMembers);
        }
    }
}
