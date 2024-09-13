using KWA_Djole.Business.Dtos;
using KWA_Djole.Business.Interfaces;
using KWA_Djole.Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace KWA_Djole.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;
        private readonly IShoppingService _shoppingService;
        public UserController(SignInManager<User> signInManager, UserManager<User> userManager, IShoppingService shoppingService)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _shoppingService = shoppingService;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            try
            {
                await _signInManager.SignOutAsync();
                return Json(new { success = true, message = "Uspešno ste se odjavili." });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }

        [HttpGet]
        public async Task<IActionResult> Profile()
        {
            var user = await _userManager.GetUserAsync(User);
            return View(user);
        }

        [HttpPost]
        public async Task<IActionResult> AddProductToCart(int productId)
        {
            try
            {
                var user = await _userManager.GetUserAsync(User);
                var result = await _shoppingService.AddShoppingItemToCart(user.Id, productId);
                return Json(new { success = result, message = result ? "Proizvod je dodat u korpu." : "Greška prilikom dodavanja proizvoda u korpu." });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }
        [HttpGet]
        public async Task<IActionResult> Cart()
        {
            CustomerCartDto model = new CustomerCartDto();
            var user = await _userManager.GetUserAsync(User);
            model.Items = await _shoppingService.GetCustomerCart(user.Id);
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> RemoveItemFromCart(int id, bool removeAllOfSameType = false)
        {
            try
            {
                var user = await _userManager.GetUserAsync(User);
                await _shoppingService.RemoveShoppingItemFromCart(user.Id, id, removeAllOfSameType);
                return Json(new { success = true, message = "Proizvod je uspešno obrisan iz korpe." });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }

        [HttpPost]
        public async Task<IActionResult> OrderItems()
        {
            try
            {
                var user = await _userManager.GetUserAsync(User);
                var result = await _shoppingService.OrderItems(user.Id);
                return Json(new { success = result, message = result ? "Uspešno ste naručili proizvode." : "Greška prilikom naručivanja proizvoda." });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }
        [HttpGet]
        public async Task<IActionResult> Orders()
        {
            var user = await _userManager.GetUserAsync(User);
            var orders = await _shoppingService.GetCustomerOrders(user.Id);
            return View(orders);
        }
        [HttpPost]
        public async Task<IActionResult> RateOrderItem(int orderItemId, int rating, string comment)
        {
            try
            {
                var user = await _userManager.GetUserAsync(User);
                var result = await _shoppingService.RateOrderItem(user.Id, orderItemId, rating, comment);
                return Json(new { success = result, message = result ? "Uspešno ste ocenili proizvod." : "Greška prilikom ocenjivanja proizvoda." });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }
    }
}