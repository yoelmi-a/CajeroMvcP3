using CajeroMvc.Application.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

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
            var options = new List<SelectListItem>
            {
                new SelectListItem {Value = "1", Text = "Billetes de Mil Y Doscientos"},
                new SelectListItem {Value = "2", Text = "Billetes de Quinientos Y Cien"},
                new SelectListItem {Value = "3", Text = "Eficiente"}
            };
            ViewBag.Options = new SelectList(options, "Value", "Text", (int)_service.GetDispenserMode());
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
