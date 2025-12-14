using WebApplication1.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebApplication1.Services
{
    public interface IMembershipService
    {
        Task<List<MembershipType>> GetAllAsync();
        Task<MembershipType> GetByIdAsync(int id);
    }
}
