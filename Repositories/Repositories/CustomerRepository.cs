using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly ApplicationDbContext _db;

        public CustomerRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public IEnumerable<Customer> GetSubscribedCustomersWithDiscount()
        {
            return _db.Customers
                    .Include(c => c.MembershipType)
                    .Where(c => c.IsSubscribed && c.MembershipType.DiscountRate > 10)
                    .ToList();
        }
        public Customer GetCustomerWithMembership(int id)
        {
            return _db.Customers
                .Include(c => c.MembershipType)
                .FirstOrDefault(c => c.Id == id);
}

    }
}
