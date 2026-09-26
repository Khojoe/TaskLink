using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskLink.Data;
using TaskLink.Models;

namespace TaskLink.Controllers
{
    [Authorize]
    public class ProviderController : Controller
    {
        private readonly AppDbContext _db;
        private readonly UserManager<ApplicationUser> _userManager;

        public ProviderController(AppDbContext db, UserManager<ApplicationUser> userManager)
        {
            _db = db;
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null) return Challenge();

            // If profile already exists, redirect to view it
            var existing = await _db.ProviderProfiles.FirstOrDefaultAsync(p => p.UserId == user.Id);
            if (existing != null)
                return RedirectToAction("MyProfile");

            return View(new ProviderProfile());
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProviderProfile model)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null) return Challenge();

            if (!ModelState.IsValid) return View(model);

            model.UserId = user.Id;
            model.CreatedAt = DateTime.UtcNow;

            _db.ProviderProfiles.Add(model);
            await _db.SaveChangesAsync();

            TempData["Success"] = "Profile created successfully!";
            return RedirectToAction("MyProfile");
        }

        public async Task<IActionResult> MyProfile()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null) return Challenge();

            var profile = await _db.ProviderProfiles
                .Include(p => p.User)
                .FirstOrDefaultAsync(p => p.UserId == user.Id);

            if (profile == null)
                return RedirectToAction("Create");

            return View(profile);
        }
    }
}
