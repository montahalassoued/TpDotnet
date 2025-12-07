using WebApplication1.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using WebApplication1.Services;

namespace WebApplication1.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ApplicationDbContext _db;

        public CustomerService(ApplicationDbContext db)
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
    }
}
