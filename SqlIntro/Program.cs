using System;

namespace SqlIntro
{
    class Program
    {
        static void Main(string[] args)
        {
            var connectionString = " Server=localhost;Database=adventureworks;Uid=root;Pwd=";
            var repo = new DapperProductRepository(connectionString);

            foreach (var prod in repo.GetProductAndReview())
            {
                Console.WriteLine($"Product Name: {prod.Name}  Reviews:  {prod.Comments}");
            }

            //repo.DeleteProduct(316);
            //repo.InsertProduct();

            //repo.InsertProduct("Davids");




            Console.ReadLine();
        }
    }
}
