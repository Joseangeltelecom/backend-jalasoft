using BakeryFreshBread.Core.DTO_s;
using BakeryFreshBread.Core.Entities;
using BakeryFreshBread.Core.Interfaces;
using BakeryFreshBread.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
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

        public async Task<OfficeDTO> CreateOffice(OfficeDTO officeDTO)
        {
            var Currentoffice = new Office()
            {
                OfficeName = officeDTO.OfficeName,
                Capacity = officeDTO.Capacity,
            };

            _context.Offices.Add(Currentoffice);
            await  _context.SaveChangesAsync();
            return  officeDTO;
        }

        public async Task<Office> GetOfficeById(int id)
        {
            return await _context.Offices.SingleOrDefaultAsync(x => x.OfficeId == id);
        }

        public async Task<IEnumerable<Office>> GetOffices()
        {
            return await _context.Offices.ToListAsync();
        }

        public async Task RemoveOfficeById(int id)
        {
            var office = _context.Offices.SingleOrDefault(x => x.OfficeId == id);
            _context.Offices.Remove(office);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Order>> getAllOrdersByOffice(int OfficeId)
        {
            return await _context.Orders.Where(x => x.OfficeId == OfficeId).ToListAsync();
        }
    }
}
