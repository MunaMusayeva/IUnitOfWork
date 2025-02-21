using Repository.Repositories;

namespace Repository.Common;

public interface IUnitOfWork
{
    public ICustomerRepository CustomerRepository { get; }
    public IProductRepository ProductRepository { get; }
}
