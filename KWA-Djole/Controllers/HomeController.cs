using AutoMapper;
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
        private readonly IMapper _mapper;
        public HomeController(ILogger<HomeController> logger, UserManager<User> userManager, SignInManager<User> signInManager, IShoppingService shoppingService, IMapper mapper)
        {
            _logger = logger;
            _userManager = userManager;
            _signInManager = signInManager;
            _shoppingService = shoppingService;
            _mapper = mapper;
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
                return Json(new { success = false, message = "Korisnik ne postoji" });
            }
            else
            {
                var result = await _signInManager.PasswordSignInAsync(user, model.Password, false, false);
                if (!result.Succeeded)
                {
                    return Json(new { success = false, message = "Pogrešna šifra, pokušajte ponovo" });
                }
            }
            return Json(new { success = true });
        }

        [HttpGet]
        public async Task<IActionResult> Register()
        {
            RegisterDto model = new RegisterDto();
            model.Genres = await _shoppingService.GetAllGenres();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterDto model)
        {
            if (!ModelState.IsValid)
            {
                return Json(new { success = false, message = "Unesite sve potrebne podatke." });
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
                return Json(new { success = false, message = "Šifra mora sadržati makar 8 karaktera, jedno veliko i malo slovo kao i poseban karakter." });
            }
            if (model.SelectedGenres != null)
            {
                var genres = model.SelectedGenres.Select(x => x.Id).ToList();
                await _shoppingService.AddUserGenres(user.Id, genres);
            }
            return Json(new { success = true });
        }

        [HttpGet]
        public async Task<IActionResult> ProductDetails(int id)
        {
            var product = await _shoppingService.GetShoppingItem(id);
            product.IsDetailsPage = true;
            return View(product);
        }

        [HttpPost]
        public async Task<IActionResult> GetAllItemsFiltered(FilterDto filters)
        {
            var items = await _shoppingService.GetShoppingItems();
            return Json(items);
        }

        [HttpPost]
        public async Task<IActionResult> GetShoppingItemsFiltered(FilterDto filter)
        {
            try
            {
                var items = await _shoppingService.GetShoppingItemsFiltered(filter);
                return Json(items);
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetItemPartial(int id)
        {
            var item = await _shoppingService.GetShoppingItem(id);
            return PartialView("_ShoppingItem", item);
        }
    }
}