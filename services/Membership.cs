using WebApplication1.Models;
using WebApplication1.Repositories.GenericRepo;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebApplication1.Services
{
    public class MembershipService : IMembershipService
    {
        private readonly IGenericRepository<MembershipType> _membershipRepo;

        public MembershipService(IGenericRepository<MembershipType> membershipRepo)
        {
            _membershipRepo = membershipRepo;
        }

        public async Task<List<MembershipType>> GetAllAsync()
        {
            return await _membershipRepo.GetAllAsync();
        }

        public async Task<MembershipType> GetByIdAsync(int id)
        {
            return await _membershipRepo.GetByIdAsync(id);
        }
    }
}
