using System.Data;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;

namespace ORM_Dapper
{
    public class Program
    {
        static void Main(string[] args)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            string connString = config.GetConnectionString("DefaultConnection");

            IDbConnection conn = new MySqlConnection(connString);
            
            var depRepo = new DapperDepartmentRepository(conn);
            
            depRepo.InsertDepartment("Guitars");
            
            var departments = depRepo.GetAllDepartments();

            foreach (var department in departments)
            {
                Console.WriteLine($"Name: {department.Name}, ID: {department.DepartmentID}");
            }
            
            Console.WriteLine($"\n\n");

            var repo = new DapperProductRepository(conn);
            
            repo.CreateProduct("Fender", 2.99, 5);

            var products = repo.GetAllProducts();

            foreach (var product in products)
            {
                Console.WriteLine($"{product.Name} | {product.Price} | {product.CategoryID}");
            }
            
            
        }
    }
}
