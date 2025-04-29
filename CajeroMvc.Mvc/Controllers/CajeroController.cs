using CajeroMvc.Application.Services;
using CajeroMvc.Application.ViewModels;
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
        public IActionResult Index(int? dispenserMode, string? message)
        {
            var facturas = _service.GetAll();
            ViewBag.Mode = dispenserMode ?? 3;
            ViewBag.Message = message;
            return View(facturas);
        }

        [HttpPost]
        public IActionResult Index(CreateBillViewModel vm)
        {
            var result = _service.Calculate(vm);

            if (result.Sucess)
            {
                return RedirectToRoute(new 
                { 
                    controller = "Cajero", 
                    Action = "Index", 
                    dispenserMode = (int)_modeService.GetDispenserMode() 
                });
            }
            else
            {
                return RedirectToRoute(new
                {
                    controller = "Cajero",
                    Action = "Index",
                    dispenserMode = (int)_modeService.GetDispenserMode(),
                    message = result.Message
                });
            }
        }
    }
}
