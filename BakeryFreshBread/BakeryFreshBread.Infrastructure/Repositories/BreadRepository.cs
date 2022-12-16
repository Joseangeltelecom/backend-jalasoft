using BakeryFreshBread.Core.DTO_s;
using BakeryFreshBread.Core.Entities;
using BakeryFreshBread.Core.Exceptions;
using BakeryFreshBread.Core.Interfaces;
using BakeryFreshBread.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Data;
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
            var bakery = CheckBakery(breadDTO.Office);
            var currentBread = new Bread()
            {
                BreadName = breadDTO.BreadName,
                Price = breadDTO.Price,
                Office = bakery
            };

            _context.Breads.Add(currentBread);
            await _context.SaveChangesAsync();
            return breadDTO;
        }

        //check if the office exist if is not the case throw an exception:
        private Office CheckBakery(OfficeDTO dataBakery)
        {
            var existBakeryOffice = _context.Offices.FirstOrDefault(x => x.OfficeName == dataBakery.OfficeName);
            if (existBakeryOffice == null)
            {
                throw new EntityNotFoundException("Error not found bakery");
            }
            return existBakeryOffice;
        }
        public async Task<IEnumerable<BreadDTO>> GetAllBreads()
        {
            var listBread = await _context.Breads.Include(x => x.Office).ToListAsync();
            var mapper = MapperBread(listBread);
            return mapper;
        }

        public async Task DeleteBreadById(int id)
        {
            var currentBread = _context.Breads.SingleOrDefault(x => x.BreadId == id);
            _context.Breads.Remove(currentBread);
            await _context.SaveChangesAsync();
        }

        public async Task<BreadDTO> GetBreadById(int id)
        {

            var currentBread = await _context.Breads.Include(x => x.Office).SingleOrDefaultAsync(x => x.BreadId == id);

            var bread = new BreadDTO()
            {
                BreadName = currentBread.BreadName,
                Office = new OfficeDTO()
                {
                    Capacity = currentBread.Office.Capacity,
                    OfficeName = currentBread.Office.OfficeName,
                },
                Price = currentBread.Price,
            };
            return bread;
        }

        public async Task<IEnumerable<BreadDTO>> GetAllBreadsByOffice(int id)
        {
            var breadList = await _context.Breads.Include(x => x.Office).Where(x => x.Office.OfficeId == id).ToListAsync();
            return MapperBread(breadList);
        }

        //Map all the bread to breadDTO:
        private IEnumerable<BreadDTO> MapperBread(List<Bread> listBread)
        {
            var breadInfo = new List<BreadDTO>();
            foreach (var bread in listBread)
            {
                breadInfo.Add(new BreadDTO()
                {
                    Office = new OfficeDTO()
                    {
                        Capacity = bread.Office.Capacity,
                        OfficeName = bread.Office.OfficeName,
                    },
                    BreadName = bread.BreadName,
                    Price = bread.Price
                });
            }

            return breadInfo;
        }
    }
}