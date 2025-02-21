using DAL.SqlServer.Context;
using Dapper;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Repository.Repositories;

namespace DAL.SqlServer.Infrastructure;

public class SqlCustomerRepository(string connectionString, AppDbContext context) : BaseSqlRepository(connectionString), ICustomerRepository
{
    private readonly AppDbContext _context = context;

    public async Task AddAsync(Customer customer)
    {
        var sql = @"INSERT INTO Customers ([Name], [Surname],[CreatedBy]) 
                    VALUES (@Name, @Surname,@CreatedBy)";
        using var conn = OpenConnection();
        await conn.QueryAsync(sql, customer);
    }

    public bool Delete(int id, int deletedBy)
    {
        var checkSql = @"SELECT Id FROM Customers WHERE Id = @id AND IsDeleted=0";

        var sql = @"UPDATE Customers
                    SET IsDeleted=1,
                    DeletedBy = @deletedBy,
                    DeletedDate = GETDATE()
                    WHERE Id=@id";
        using var conn = OpenConnection();
        using var transaction = conn.BeginTransaction();

        var categoryId = conn.ExecuteScalar<int?>(checkSql, id, transaction);

        if (!categoryId.HasValue)
            return false;

        var affectedRows = conn.Execute(sql, new { id, deletedBy }, transaction);
        transaction.Commit();
        return affectedRows > 0;
    }

    public IQueryable<Customer> GetAll()
    {
        return _context.Customers.OrderByDescending(c => c.CreatedDate).Where(c => c.IsDeleted == false);
    }

    public async Task<Customer> GetByIdAsync(int id)
    {
        var sql = @"SELECT C.*
                    FROM Customers AS C
                    WHERE C.Id = @id AND C.IsDeleted =0";

        using var conn = OpenConnection();

        return await conn.QueryFirstOrDefaultAsync<Customer>(sql, new { id });
    }

    public void Update(Customer customer)
    {
        var sql = @"UPDATE Customers
                    SET Name = @Name,
                    SET Surname = @Surname,
                    UpdatedBy = @UpdatedBy,
                    UpdatedDate = GETDATE()
                    WHERE Id = @Id";

        using var conn = OpenConnection();

        conn.Query(sql, customer);
    }
}
