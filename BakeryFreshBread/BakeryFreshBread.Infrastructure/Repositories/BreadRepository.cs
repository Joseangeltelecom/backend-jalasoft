using BakeryFreshBread.Core.Entities;
using BakeryFreshBread.Core.Exceptions;
using BakeryFreshBread.Core.Interfaces;
using BakeryFreshBread.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
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

        async public Task<IEnumerable<Bread>> GetBreads()
        {
            return await _context.Breads.ToListAsync();
        }
        async public Task CreateBread(Bread bread)
        {
            _context.Breads.Add(bread);
            await _context.SaveChangesAsync();
        }

        async public Task<Bread> GetBreadById(int id)
        {
            var CurrentBred = _context.Breads.FirstOrDefaultAsync(bread => bread.BreadId == id);
            if (CurrentBred != null)
            {
                return await CurrentBred;
            }
            else
            {
                throw new EntityNotFoundException("Bread not found");
            }
        }

        async public Task RemoveBreadById(int id)
        {
            var CurrentBread = await GetBreadById(id);
            if (CurrentBread != null)
            {
                _context.Breads.Remove(CurrentBread);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new EntityNotFoundException("Bread not found");
            }
        }
    }
}   