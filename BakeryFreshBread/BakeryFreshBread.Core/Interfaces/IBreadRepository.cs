using BakeryFreshBread.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BakeryFreshBread.Core.Interfaces
{
    public interface IBreadRepository
    {
        Task CreateBread(Bread bread);
        Task<Bread> GetBreadById(int id);
        Task<IEnumerable<Bread>> GetBreads();
        Task RemoveBreadById(int id);
    }
}
