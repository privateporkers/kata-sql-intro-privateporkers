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
            conn.Query ($"DELETE FROM product WHERE ProductId = {id}");
            }
        }

        public void InsertProduct(string Name)
        {
            using (var conn = new MySqlConnection(_connectionString))
            {
                var cmd = conn.CreateCommand();
                conn.Open();
                conn.Query ("INSERT INTO product (Name) VALUES ('@name')");
                cmd.Parameters.AddWithValue("@name", Name);
            }
        }

        public void UpdateProduct(string ProductName, int ProductId)
        {
            using (var conn = new MySqlConnection(_connectionString))
            {
                var cmd = conn.CreateCommand();
                conn.Open();
                conn.Query ("UPDATE product SET Name=('@pName') WHERE ProductId = (@pId) ");
                cmd.Parameters.AddWithValue("pName", ProductName);
                cmd.Parameters.AddWithValue("pId", ProductId);

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
