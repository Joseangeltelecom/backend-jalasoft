using BakeryFreshBread.Core.DTO_s;
using BakeryFreshBread.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BakeryFreshBread.Core.Interfaces
{
    public interface IBreadRepository
    {
        Task<BreadDTO> CreateBread(BreadDTO breadDTO);
        Task<BreadDTO> GetBreadById(int id);
        Task<IEnumerable<BreadDTO>> GetAllBreads();
        Task DeleteBreadById(int id);
        Task<IEnumerable<BreadDTO>> GetAllBreadsByOffice(int id);
    }
}
