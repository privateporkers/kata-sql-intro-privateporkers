using System;

namespace SqlIntro
{
    class Program
    {
        static void Main(string[] args)
        {
            /*foreach (var prod in repo.GetProductWithReview())
            {
                Console.WriteLine($"Product Name: {prod.Name}  Reviews:  {prod.Comments}");
            }*/

            //DapperChoice();
            dapperCrudChoice(DapperChoice());
        }

        public static string DapperChoice()
        {
            var answ = " ";
            Console.WriteLine("Would you like to Create(C), Delete(D), Update(U), or get all(A)?");
            while( !(answ == "u" || answ == "c" || answ == "d" || answ == "a"))
            {
                answ = Console.ReadLine().ToLower();
                if(answ == "u" || answ == "c" || answ == "d" || answ == "a")
                {
                    break;
                }
                Console.WriteLine("That is not one of the options! Please pick one");
            }

            return answ;
        }

        public static void dapperCrudChoice(string str)
        {
            var prod = new Product();
            var connectionString = " Server=localhost;Database=adventureworks;Uid=root;Pwd=";

            Console.WriteLine("Do you want to use Dapper? (y or n)");
            var dap = Console.ReadLine();

            IProductRepo repo;

            if(dap == "y")
            {
                repo = new ProductRepository(connectionString);
            }
            else
            { 
            repo = new DapperProductRepository(connectionString);
            }

            if(str == "u")
            {
                Console.WriteLine("What ID do you want to specify?");
                prod.Id = Convert.ToInt32( Console.ReadLine() );

                Console.WriteLine("What would you like to rename this product?");
                prod.Name = Console.ReadLine();

                repo.UpdateProduct(prod);
            }

            if(str == "c")
            {
                Console.WriteLine("What is your product called?");
                prod.Name = Console.ReadLine();

                repo.InsertProduct(prod);
            }

            if(str == "d")
            {
                Console.WriteLine("What Id would you like to delete?");
                var num = Convert.ToInt32(  Console.ReadLine() );

                repo.DeleteProduct(num);
            }

            if(str == "a")
            {
                repo.GetProducts();
            }
        }
    }
}
