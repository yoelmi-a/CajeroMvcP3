using CajeroMvc.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace CajeroMvc.Mvc.Controllers
{
    public class DispenserModeController : Controller
    {
        private readonly DispenserModeService _service;

        public DispenserModeController()
        {
            _service = new DispenserModeService();
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(int modo)
        {
            _service.SetDispenserMode(modo);
            return RedirectToRoute(new { controller = "Cajero", Action = "Index", dispenserMode = modo });
        }
    }
}
