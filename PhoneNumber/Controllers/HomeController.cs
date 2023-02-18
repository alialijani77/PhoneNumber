using Microsoft.AspNetCore.Mvc;
using PhoneNumber.Application.Services.Implementions;
using PhoneNumber.Application.Services.Interfaces;
using System.Diagnostics;

namespace PhoneNumber.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPhoneNumberService _phoneNumberService;

        public HomeController(IPhoneNumberService phoneNumberService)
        {
            _phoneNumberService = phoneNumberService;
        }

        public async Task<IActionResult> Index()
        {
            return View();
        }

        [HttpGet("load-PhoneNumberId-modal-body")]
        public async Task<IActionResult> loadPhoneNumberIdmodalbody(long PhoneNumberId)
        {
            var result = await _phoneNumberService.GetPhoneNumberForloadPhoneNumberIdmodalbody(PhoneNumberId);
            return PartialView("_PhoneNumberModal", result);
        }

    }
}