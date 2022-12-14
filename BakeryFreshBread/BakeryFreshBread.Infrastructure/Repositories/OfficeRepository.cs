using BakeryFreshBread.Core.Entities;
using BakeryFreshBread.Core.Exceptions;
using BakeryFreshBread.Core.Interfaces;
using BakeryFreshBread.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BakeryFreshBread.Infrastructure.Repositories
{
    public class OfficeRepository : IOfficeRepository
    {
        private readonly BakeryFreshBreadContext _context;
        public OfficeRepository(BakeryFreshBreadContext context)
        {
            _context = context;
        }
        async public Task CreateOffice(Office office)
        {
            _context.Offices.Add(office);
            await _context.SaveChangesAsync();
        }

        async public Task<IEnumerable<Office>> GetOffices()
        {
            return await _context.Offices.ToListAsync();
        }

        async public Task<Office> GetOfficeById(int id)
        {
            var CurrentOffice = _context.Offices.FirstOrDefaultAsync(office => office.OfficeId == id);
            if (CurrentOffice != null)
            {
                return await CurrentOffice;
            }
            else
            {
                throw new EntityNotFoundException("Office not found");
            }
        }

        async public Task RemoveOfficeById(int id)
        {

            var CurrentOffice = _context.Offices.SingleOrDefault(office => office.OfficeId == id);

            //var CurrentOffice = await GetOfficeById(id);
            if (CurrentOffice != null)
            {
                _context.Offices.Remove(CurrentOffice);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new EntityNotFoundException("Office not found");
            }
        }




}
}
