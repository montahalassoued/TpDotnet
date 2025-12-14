using WebApplication1.Models;
using WebApplication1.Helpers;
namespace WebApplication1.Services
{
    public interface ICustomerService
    {
        Task<PaginatedList<Customer>> GetCustomersPaginatedAsync(int pageNumber, int pageSize);
        Task<List<Customer>> GetAllCustomersAsync();
        Task<Customer> GetCustomerByIdAsync(int id);
        Task AddCustomerAsync(Customer customer);
        Task UpdateCustomerAsync(Customer customer);
        Task DeleteCustomerAsync(Customer customer);
        IEnumerable<Customer> GetSubscribedCustomersWithDiscount();
    }
}
