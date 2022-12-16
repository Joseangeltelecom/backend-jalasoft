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
    public class BreadRepository : IBreadRepository
    {
        private readonly BakeryFreshBreadContext _context;
        public BreadRepository(BakeryFreshBreadContext context)
        {
            _context = context;
        }

        public async Task<BreadDTO> CreateBread(BreadDTO breadDTO)
        {
            var currentBread = new Bread()
            {
                BreadName = breadDTO.BreadName,
                Price = breadDTO.Price,
            };

            _context.Breads.Add(currentBread);
            await _context.SaveChangesAsync();
            return breadDTO;
        }

        public async Task<IEnumerable<Bread>> GetAllBreads()
        {
            return await _context.Breads.ToListAsync();
        }

        public async Task DeleteBreadById(int id)
        {
            var currentBread = _context.Breads.SingleOrDefault(x => x.BreadId == id);
            _context.Breads.Remove(currentBread);
            await _context.SaveChangesAsync();
        }

        public async Task<Bread> GetBreadById(int id)
        {
            var currentBread = _context.Breads.SingleOrDefaultAsync(x => x.BreadId == id);
            return await currentBread;
        }

        public async Task<List<Bread>> GetAllBreadsByOffice(int id)
        {
            var office = await _context.Breads.Where(x => x.Office.OfficeId == id).ToListAsync();
            List<Bread> breadList = new List<Bread>();
            foreach (var bread in office)
            {
                breadList.Add(bread);
            }
            return breadList;
        }
    }
}