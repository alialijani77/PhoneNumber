using PhoneNumber.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneNumber.Domain.Interfaces
{
	public interface IPhoneNumberRepository
	{
		Task CreatePhoneNumber(PhoneNumber.Domain.Entities.PhoneNumber phoneNumber);

		Task<PhoneNumber.Domain.Entities.PhoneNumber?> GetPhoneNumberById(long id);

		Task Save();

		Task UpdatePhoneNumber(PhoneNumber.Domain.Entities.PhoneNumber phoneNumber);
	}
}
