using System;

namespace SqlIntro
{
    class Program
    {
        static void Main(string[] args)
        {
            var connectionString = " Server=localhost;Database=adventureworks;Uid=root;Pwd=";
            var repo = new ProductRepository(connectionString);

            foreach (var prod in repo.GetProducts())
            {
                Console.WriteLine("Product Name:" + prod.Name);
            }

            var testDap = new DapperProductRepository(connectionString);
            foreach (var test in testDap.GetProducts())

            Console.ReadLine();
        }
    }
}
