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


namespace SqlIntro
{
    public class DapperProductRepository
    {
        private readonly string connectionString;
        public DapperProductRepository()
        {
           connectionString = " Server=localhost;Database=adventureworks;Uid=root;Pwd=";
        }
        public IDbConnection Connection
        {
            get
            {
                return new SqlConnection(connectionString);
            }
        }

        public void Add(Product prod)
        {
            using (IDbConnection  db = Connection)
            {
                string update = "SELECT * FROM product";
                db.Open();
            }
        }
    }
}