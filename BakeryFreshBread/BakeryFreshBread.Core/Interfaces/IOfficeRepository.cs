using BakeryFreshBread.Core.DTO_s;
using BakeryFreshBread.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BakeryFreshBread.Core.Interfaces
{
    public interface IOfficeRepository
    {
        Task<OfficeDTO> CreateOffice(OfficeDTO officeDTO);
        Task<Office> GetOfficeById(int id);
        Task<IEnumerable<Office>> GetOffices();
        Task RemoveOfficeById(int id);
        Task<List<Order>> getAllOrdersByOffice(int OfficeId);
    }
}
