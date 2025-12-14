using WebApplication1.Models;

namespace WebApplication1.Repositories
{
    public interface ICustomerRepository
    {
        IEnumerable<Customer> GetSubscribedCustomersWithDiscount();
        Customer GetCustomerWithMembership(int id);

    }
}

