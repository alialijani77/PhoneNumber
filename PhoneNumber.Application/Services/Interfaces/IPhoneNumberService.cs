using PhoneNumber.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneNumber.Application.Services.Interfaces
{
	public interface IPhoneNumberService
	{
		Task<bool> CreateOrEditPhoneNumber(CreateOrEditPhoneNumberViewModel createOrEditPhoneNumber);

		Task<CreateOrEditPhoneNumberViewModel> GetPhoneNumberForloadPhoneNumberIdmodalbody(long PhoneNumberId);

		Task<IReadOnlyCollection<Domain.Entities.PhoneNumber>> GetPhoneNumbers();

		Task<bool> DeletePhone(long PhoneNumberId);

	}
}
