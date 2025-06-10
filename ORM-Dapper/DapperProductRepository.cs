using System.Data;
using Dapper;

namespace ORM_Dapper;

public class DapperProductRepository : IProductRepository
{
    private readonly IDbConnection _connection;

    public DapperProductRepository(IDbConnection conn)
    {
        _connection = conn;
    }
    
    public IEnumerable<Product> GetAllProducts()
    {
        return _connection.Query<Product>("SELECT * FROM products;");
    }

    public void CreateProduct(string name, double price, int categoryID)
    {
        throw new NotImplementedException();
    }
}