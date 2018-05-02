using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using MySql.Data;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;
using Dapper;


namespace SqlIntro
{
    public class DapperProductRepository : IProductRepo
    {
        private readonly string _connectionString;

        public DapperProductRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IEnumerable<Product> GetProducts()
        {
            using(var conn = new MySqlConnection(_connectionString))
            {
                conn.Open();
                return conn.Query<Product> ("select ProductId as Id, Name from product");
            }
        }

        public void DeleteProduct(int id)
        {
            using (var conn = new MySqlConnection(_connectionString))
            {
                conn.Open();
                conn.Execute ($"DELETE FROM product WHERE ProductId = @id", new { id });
            }
        }

        public void InsertProduct(Product prod)
        {
            using (var conn = new MySqlConnection(_connectionString))
            {
                conn.Open();
                conn.Execute ("INSERT INTO product (Name) VALUES (gName) ", new {gName = prod.Name});
            }
        }

        public void UpdateProduct(Product prod)
        {
            using (var conn = new MySqlConnection(_connectionString))
            {
                conn.Open();
                conn.Execute ("UPDATE product SET Name=pName WHERE ProductId = (@Id) ", new {pName = prod.Name, @Id = prod.Id});

            }
        }

        public IEnumerable<Product> GetProductWithReview()
        {
            using (var conn = new MySqlConnection(_connectionString))
            {
                conn.Open();
                return conn.Query<Product> (@"SELECT p.Name, pr.Comments
                FROM product as p
                INNER JOIN productreview as pr ON p.ProductId = pr.ProductId;");
            }
        }

        public IEnumerable<Product> GetProductAndReview()
        {
            using (var conn = new MySqlConnection(_connectionString))
            {
                conn.Open();
                return conn.Query<Product> (@"SELECT p.Name, pr.Comments
                FROM product as p
                LEFT JOIN productreview as pr ON p.ProductId = pr.ProductId;");
            }
        }
    }
}
