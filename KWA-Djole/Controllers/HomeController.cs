using KWA_Djole.Business.Dtos;
using KWA_Djole.Business.Interfaces;
using KWA_Djole.Data.Models;
using KWA_Djole.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace KWA_Djole.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IShoppingService _shoppingService;
        public HomeController(ILogger<HomeController> logger, UserManager<User> userManager, SignInManager<User> signInManager, IShoppingService shoppingService)
        {
            _logger = logger;
            _userManager = userManager;
            _signInManager = signInManager;
            _shoppingService = shoppingService;
        }

        public async Task<IActionResult> Index()
        {
            var user = User?.Identity?.Name;
            var homeData = await _shoppingService.GetHomeData(user);
            return View(homeData);
        }

        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        public async Task<IActionResult> Authenticate(LoginDto model)
        {
            if (!ModelState.IsValid)
            {
                return Json(new { success = false });
            }
            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user == null)
            {
                TempData["Success"] = "False";
                TempData["Message"] = "Korisnik ne postoji";
            }
            else
            {
                var result = await _signInManager.PasswordSignInAsync(user, model.Password, false, false);
                if (!result.Succeeded)
                {
                    TempData["Success"] = "False";
                    TempData["Message"] = "Pogrešna šifra, pokušajte ponovo";
                    return Json(new { });
                }
            }
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterDto model)
        {
            if (!ModelState.IsValid)
            {
                return Json(new { success = false });
            }
            var user = new User
            {
                UserName = model.Email,
                Email = model.Email,
                FirstName = model.FirstName,
                LastName = model.LastName,
                PhoneNumber = model.PhoneNumber,
                Address = model.Address
            };
            var result = await _userManager.CreateAsync(user, model.Password);
            if (!result.Succeeded)
            {
                TempData["Success"] = "False";
                TempData["Message"] = "Greška prilikom registracije";
                return Json(new { success = false });
            }
            return RedirectToAction("Index", "Home");
        }
        [HttpGet]
        public async Task<IActionResult> ProductDetails(int id)
        {
            var product = await _shoppingService.GetShoppingItem(id);
            product.IsDetailsPage = true;
            return View(product);
        }
    }
}