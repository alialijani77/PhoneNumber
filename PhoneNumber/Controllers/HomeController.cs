using Microsoft.AspNetCore.Mvc;
using PhoneNumber.Application.Services.Implementions;
using PhoneNumber.Application.Services.Interfaces;
using PhoneNumber.Domain.ViewModels;
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
			var result = await _phoneNumberService.GetPhoneNumbers();
			return View(result);
		}

		[HttpGet("load-PhoneNumberId-modal-body")]
		public async Task<IActionResult> loadPhoneNumberIdmodalbody(long PhoneNumberId)
		{
			var result = await _phoneNumberService.GetPhoneNumberForloadPhoneNumberIdmodalbody(PhoneNumberId);
			return PartialView("_PhoneNumberModal", result);
		}

		[HttpPost("submit-phonenumber")]
		public async Task<IActionResult> CreateOrEditPhoneNumber(CreateOrEditPhoneNumberViewModel phoneNumberViewModel)
		{
			var result = await _phoneNumberService.CreateOrEditPhoneNumber(phoneNumberViewModel);

			if (result)
			{
				return new JsonResult(new { status = "success" });
			}
			else
			{
				return new JsonResult(new { status = "error" });
			}
		}

		[HttpGet("DeletePhone")]
		public async Task<IActionResult> DeletePhone(long PhoneNumberId)
		{
			var result = await _phoneNumberService.DeletePhone(PhoneNumberId);

			if (result)
			{
				return new JsonResult(new { status = "success" });
			}
			else
			{
				return new JsonResult(new { status = "error" });
			}
		}


	}
}