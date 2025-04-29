using CajeroMvc.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace CajeroMvc.Mvc.Controllers
{
    public class CajeroController : Controller
    {
        private readonly CalculateAmountService _service;
        private readonly DispenserModeService _modeService;

        public CajeroController()
        {
            _service = new CalculateAmountService();
            _modeService = new DispenserModeService();
        }
        public IActionResult Index(int? dispenserMode)
        {
            ViewBag.Mode = dispenserMode;
            return View();
        }

        [HttpPost]
        public IActionResult Index(int monto)
        {
            throw new NotImplementedException();
        }
    }
}
