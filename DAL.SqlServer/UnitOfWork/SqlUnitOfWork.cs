using DAL.SqlServer.Context;
using DAL.SqlServer.Infrastructure;
using Repository.Repositories;

namespace DAL.SqlServer.UnitOfWork;

public class SqlUnitOfWork(string connectionString, AppDbContext context)
{
    private readonly string _connectionString = connectionString;
    private readonly AppDbContext _context = context;
    
    public SqlCustomerRepository _customerRepository;
    public SqlProductRepository _productRepository;

    public ICustomerRepository CustomerRepository => _customerRepository ?? new SqlCustomerRepository(_connectionString, _context);

    public IProductRepository ProductRepository => _productRepository ?? new SqlProductRepository(_context);
}
