using BakeryFreshBread.Core.Entities;
using System;
using System.Threading.Tasks;

namespace BakeryFreashBreadFrontend
{
    public class Program
    {
    static async Task Main(string[] args)
        {
            var offices = await API.GetList<Office>("https://localhost:5001/api/offices");
            foreach (var office in offices)
            {
                Console.WriteLine(office.OfficeId);
                Console.WriteLine(office.OfficeName);
                Console.WriteLine(office.Capacity);
            }
        }
    }
}
