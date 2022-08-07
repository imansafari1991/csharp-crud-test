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

    public async Task Delete(Customer entity)
    {
        _context.Customers.Remove(entity);
        await _context.SaveChangesAsync();
    }



    public async Task<Customer?> Get(int id)
    {
        return await _context.Customers.FindAsync(id);
    }

    public async Task<IReadOnlyList<Customer>> GetAll()
    {
        return await _context.Customers.ToListAsync();
    }

    public async Task Update(Customer entity)
    {
        _context.Entry(entity).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }

    public bool IsExists(Customer customer)
    {
        return _context.Customers.Any(p=>p.FirstName==customer.FirstName && p.LastName==customer.LastName && p.DateOfBirth==customer.DateOfBirth);
    }

    public bool IsExists(string email)
    {
        return _context.Customers.Any(p=>p.Email==email);
    }
}