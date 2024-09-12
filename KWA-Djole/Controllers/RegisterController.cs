using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KWA_Djole.Controllers
{
    [AllowAnonymous]
    public class RegisterController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}