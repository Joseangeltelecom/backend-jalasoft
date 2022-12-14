using BakeryFreshBread.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BakeryFreshBread.Core.Interfaces
{
    public interface IOfficeRepository
    {
        Task CreateOffice(Office office);
        Task<Office> GetOfficeById(int id);
        Task<IEnumerable<Office>> GetOffices();
        Task RemoveOfficeById(int id);
    }
}
