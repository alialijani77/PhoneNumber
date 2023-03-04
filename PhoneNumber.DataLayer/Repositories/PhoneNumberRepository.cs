using Microsoft.EntityFrameworkCore;
using PhoneNumber.DataLayer.Context;
using PhoneNumber.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneNumber.DataLayer.Repositories
{
    public class PhoneNumberRepository : IPhoneNumberRepository
    {
        #region ctor
        private readonly PhoneNumberDbContext _context;

        public PhoneNumberRepository(PhoneNumberDbContext context)
        {
            _context = context;
        }
        #endregion

        #region Create
        public async Task CreatePhoneNumber(Domain.Entities.PhoneNumber phoneNumber)
        {
            _context.phoneNumbers.Add(phoneNumber);
        }
        #endregion

        #region GetById
        public async Task<Domain.Entities.PhoneNumber?> GetPhoneNumberById(long id)
        {
            return await _context.phoneNumbers.FirstOrDefaultAsync(p => p.Id == id);
        }

        #endregion

        #region Save
        public async Task Save()
        {
            _context.SaveChanges();
        }
        #endregion

        #region Update
        public async Task UpdatePhoneNumber(Domain.Entities.PhoneNumber phoneNumber)
        {
            _context.Update(phoneNumber);
        }
        #endregion

        #region GetAll
        public async Task<IReadOnlyCollection<Domain.Entities.PhoneNumber>> GetPhoneNumbers()
        {
            return await _context.phoneNumbers.Where(p => !p.IsDelete).ToListAsync();
        }
		#endregion

	}
}
