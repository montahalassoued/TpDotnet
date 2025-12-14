using WebApplication1.Models;
using WebApplication1.Repositories.GenericRepo;
using WebApplication1.Repositories;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Helpers;

namespace WebApplication1.Services
{
    public class CustomerService: ICustomerService
    {
         private readonly IGenericRepository<Customer> _customerRepo;
        private readonly ICustomerRepository _customerRepoSpecific;
        public CustomerService(IGenericRepository<Customer> customerRepo, ICustomerRepository customerRepoSpecific)
        {
            _customerRepo = customerRepo;
            _customerRepoSpecific = customerRepoSpecific;
        }
         public async Task<PaginatedList<Customer>> GetCustomersPaginatedAsync(int pageNumber, int pageSize)
        {
           var query = _customerRepo.GetAll()
                              .Include(c => c.MembershipType) 
                              .OrderBy(c => c.Id);
           return await PaginatedList<Customer>.CreateAsync(query, pageNumber, pageSize);}
        public async Task<List<Customer>> GetAllCustomersAsync()
        {
            return await _customerRepo.GetAllAsync();
        }
        public async Task<Customer> GetCustomerByIdAsync(int id)
        {
            return await Task.Run(() => _customerRepoSpecific.GetCustomerWithMembership(id));
            }
        public async Task AddCustomerAsync(Customer customer)
        {
            await _customerRepo.AddAsync(customer);
        }
        public async Task UpdateCustomerAsync(Customer customer)
        {
            await _customerRepo.UpdateAsync(customer);
        }
        public async Task DeleteCustomerAsync(Customer customer)
        {
            await _customerRepo.DeleteAsync(customer);
        }
        public IEnumerable<Customer> GetSubscribedCustomersWithDiscount()
        {
            return _customerRepoSpecific.GetSubscribedCustomersWithDiscount();
        }
    }
}
