﻿using PhoneNumber.Application.Services.Interfaces;
using PhoneNumber.Domain.Interfaces;
using PhoneNumber.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneNumber.Application.Services.Implementions
{
	public class PhoneNumberService : IPhoneNumberService
	{
		private readonly IPhoneNumberRepository _phoneNumberRepository;

        #region ctor
        public PhoneNumberService(IPhoneNumberRepository phoneNumberRepository)
        {
            _phoneNumberRepository = phoneNumberRepository;
        }
        #endregion

        #region CreateOrUpdate
        public async Task<bool> CreateOrEditPhoneNumber(CreateOrEditPhoneNumberViewModel createOrEditPhoneNumber)
        {
            if (createOrEditPhoneNumber.Id == 0)
            {
                var phoneNumbercreate = new PhoneNumber.Domain.Entities.PhoneNumber();
                phoneNumbercreate.Name= createOrEditPhoneNumber.Name;
                phoneNumbercreate.Family = createOrEditPhoneNumber.Family;
                phoneNumbercreate.Email= createOrEditPhoneNumber.Email;
                phoneNumbercreate.Address = createOrEditPhoneNumber.Address;
                
                await _phoneNumberRepository.CreatePhoneNumber(phoneNumbercreate);
                await _phoneNumberRepository.Save();
                return true;
            }

            var phoneNumberedit = await _phoneNumberRepository.GetPhoneNumberById(createOrEditPhoneNumber.Id);

            if (phoneNumberedit == null) return false;

            phoneNumberedit.Name = createOrEditPhoneNumber.Name;
            phoneNumberedit.Family = createOrEditPhoneNumber.Family;
            phoneNumberedit.Email = createOrEditPhoneNumber.Email;
            phoneNumberedit.Address = createOrEditPhoneNumber.Address;

            await _phoneNumberRepository.UpdatePhoneNumber(phoneNumberedit);
            await _phoneNumberRepository.Save();
            return true;
        }

        public async Task<CreateOrEditPhoneNumberViewModel> GetPhoneNumberForloadPhoneNumberIdmodalbody(long PhoneNumberId)
        {
            var result = await _phoneNumberRepository.GetPhoneNumberById(PhoneNumberId);

            if(result == null)
            {
                return new CreateOrEditPhoneNumberViewModel { Id = 0 };
            }

            return new CreateOrEditPhoneNumberViewModel
            {
                Id = result.Id,
                Name = result.Name,
                Family = result.Family,
                Email = result.Email,
                Address = result.Address
            };
        }
        #endregion
    }
}
