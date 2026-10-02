using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskLink.Data;
using TaskLink.Models;

namespace TaskLink.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _db;

        public HomeController(AppDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Search(string? query, string? location)
        {
            var results = _db.ProviderProfiles
                .Include(p => p.User)
                .Where(p => p.IsAvailable);

            if (!string.IsNullOrWhiteSpace(query))
                results = results.Where(p => p.Trade.ToLower().Contains(query.ToLower()));

            if (!string.IsNullOrWhiteSpace(location))
                results = results.Where(p => p.Location.ToLower().Contains(location.ToLower()));

            var vm = new SearchViewModel
            {
                Query = query,
                Location = location,
                Results = await results.ToListAsync()
            };

            return View(vm);
        }

        public async Task<IActionResult> ProviderDetail(int id)
        {
            var profile = await _db.ProviderProfiles
                .Include(p => p.User)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (profile == null) return NotFound();

            return View(profile);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() => View();
    }
}
