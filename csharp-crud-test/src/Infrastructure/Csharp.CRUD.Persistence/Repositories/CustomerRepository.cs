using Csharp.CRUD.Application.Contracts.Persistence;
using Csharp.CRUD.Domain;
using Microsoft.EntityFrameworkCore;

namespace Csharp.CRUD.Persistence.Repositories;

public class CustomerRepository : ICustomerRepository
{
    private readonly ApplicationDbContext _context;

    public CustomerRepository(ApplicationDbContext context)
    {
        _context = context;
    }


    public async Task<Customer> Add(Customer entity)
    {
       await _context.AddAsync(entity);
       await _context.SaveChangesAsync();
       return entity;

    }

    public Task Delete(Customer entity)
    {
        throw new NotImplementedException();
    }



    public Task<Customer> Get(int id)
    {
        throw new NotImplementedException();
    }

    public Task<IReadOnlyList<Customer>> GetAll()
    {
        throw new NotImplementedException();
    }

    public Task Update(Customer entity)
    {
        throw new NotImplementedException();
    }

    public bool IsExists(Customer customer)
    {
        return _context.Customers.Any(p=>p.FirstName==customer.FirstName && p.LastName==customer.LastName && p.DateOfBirth==customer.DateOfBirth);
    }
}