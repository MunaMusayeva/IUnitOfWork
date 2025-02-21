using DAL.SqlServer.Context;
using Domain.Entities;
using Repository.Repositories;

namespace DAL.SqlServer.Infrastructure;

public class SqlProductRepository : BaseSqlRepository, IProductRepository
{
    private readonly AppDbContext _context ;
    public SqlProductRepository(string connectionString, AppDbContext context = null) : base(connectionString)
    {
        _context = context;
    }

    public Task AddAsync(Product product)
    {
        throw new NotImplementedException();
    }

    public bool Delete(int id, int deletedBy)
    {
        throw new NotImplementedException();
    }

    public IQueryable<Product> GetAll()
    {
        throw new NotImplementedException();
    }

    public Task<Product> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public void Update(Product product)
    {
        throw new NotImplementedException();
    }
}
