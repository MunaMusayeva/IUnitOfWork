using Domain.Entities;
using Repository.Repositories;

namespace DAL.SqlServer.Infrastructure;

public class SqlCustomerRepository : BaseSqlRepository, ICustomerRepository
{
    public SqlCustomerRepository(string connectionString) : base(connectionString)
    {
    }

    public Task AddAsync(Customer customer)
    {
        throw new NotImplementedException();
    }

    public bool Delete(int id, int deletedBy)
    {
        throw new NotImplementedException();
    }

    public IQueryable<Customer> GetAll()
    {
        throw new NotImplementedException();
    }

    public Task<Customer> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public void Update(Customer customer)
    {
        throw new NotImplementedException();
    }
}
