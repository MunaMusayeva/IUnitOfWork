using DAL.SqlServer.Context;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Repository.Repositories;

namespace DAL.SqlServer.Infrastructure;

public class SqlProductRepository(AppDbContext context) :IProductRepository
{
    private readonly AppDbContext _context = context;

    public async Task AddAsync(Product product)
    {
        await _context.Products.AddAsync(product);
        await _context.SaveChangesAsync();
    }

    public async Task Remove(int id)
    {
        var product = await _context.Products.FirstOrDefaultAsync(u => u.Id == id);
        product.IsDeleted = true;
        product.DeletedDate = DateTime.Now;
        product.DeletedBy = 0;
    }

    public IQueryable<Product> GetAll()
    {
        return _context.Products;
    }

    public async Task<Product> GetByIdAsync(int id)
    {
        return (await _context.Products.FirstOrDefaultAsync(u => u.Id == id))!;
    }

    public void Update(Product product)
    {
        product.UpdatedDate = DateTime.Now;
        _context.Update(product);
    }
}
